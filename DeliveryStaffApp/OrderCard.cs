using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Shoppa.Data.Models;

namespace DeliveryStaffApp
{
    public partial class OrderCard : UserControl
    {
        private readonly int _orderId;

        public event Action? OnDataChanged;

        public OrderCard(Order order)
        {
            InitializeComponent();
            
            BackColor = Color.White;

            _orderId = order.OrderId;

            lbOrderId.Text = $"Order #{order.OrderId}";

            if (order.Orderitems != null && order.Orderitems.Any())
            {
                lbBodyText.Text = string.Join(Environment.NewLine,
                    order.Orderitems.Select(i =>
                        $"{i.Product.ProductName} x{i.Quantity}"
                    ));
            }
            else
            {
                lbBodyText.Text = "No items";
            }
            
            cmbStatus.SelectedItem = order.ShippingStatus;
            
        }

        public void UpdateStatus(string status)
        {
            cmbStatus.SelectedItem = status;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select status");
                return;
            }

            string newStatus = cmbStatus.SelectedItem?.ToString() ?? "";

            using (HttpClient client = new HttpClient())
            {
                string apiUrl =
                    $"https://localhost:7186/api/v1/order/{_orderId}/status";

                var body = new
                {
                    ShippingStatus = newStatus
                };

                string jsonBody = JsonConvert.SerializeObject(body);

                var content = new StringContent(
                    jsonBody,
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    UpdateStatus(newStatus);

                    OnDataChanged?.Invoke();
                }
                else
                {
                    MessageBox.Show("Update failed");
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"Completed Order #{_orderId} ?",
                "Confirm",  
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            // บันทึก order id ลงไฟล์
            string hiddenPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "hidden_orders.txt"
            );

            File.AppendAllText(
                hiddenPath,
                _orderId + Environment.NewLine
            );

            // เอาออกจากหน้าจอ
            this.Parent?.Controls.Remove(this);

            this.Dispose();
        }
    }
}