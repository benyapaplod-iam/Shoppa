using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Shoppa.Data.Models;

namespace DeliveryStaffApp
{
    public partial class DeliveryForm : Form
    {
        public DeliveryForm()
        {
            InitializeComponent();
            //LoadOrders();
            this.Shown += (s, e) => LoadOrders();

            flowPanel.Resize += (s, e) => CenterCards();

        }

        private async void LoadOrders()
        {
            flowPanel.SuspendLayout();
            flowPanel.Controls.Clear();

            try
            {
                string hiddenPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "hidden_orders.txt"
                );

                List<int> hiddenOrders = new List<int>();

                if (File.Exists(hiddenPath))
                {
                    hiddenOrders = File.ReadAllLines(hiddenPath)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(int.Parse)
                        .ToList();
                }

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:7186/api/v1/order";

                    var response = await client.GetAsync(apiUrl);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("โหลดข้อมูลไม่สำเร็จ");
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();

                    var orders = JsonConvert.DeserializeObject<List<Order>>(json);

                    if (orders == null)
                        return;

                    orders = orders
                        .Where(o => !hiddenOrders.Contains(o.OrderId))
                        .OrderBy(o => o.OrderId)
                        .ToList();

                    foreach (var order in orders)
                    {
                        var card = new OrderCard(order);

                        card.OnDataChanged += () =>
                        {
                            ShowToast(
                                $"Order #{order.OrderId}",
                                "Order status updated successfully"
                            );
                        };

                        flowPanel.Controls.Add(card);
                    }
                }

                CenterCards();
            }
            finally
            {
                flowPanel.ResumeLayout(true);  // render ทีเดียวจบ
            }
        }


        //TOAST NOTIFICATION 
        private void ShowToast(string title, string message)
        {
            Form toast = new Form();
            toast.FormBorderStyle = FormBorderStyle.None;
            toast.BackColor = Color.FromArgb(40, 40, 40);
            toast.Size = new Size(350, 60);
            toast.StartPosition = FormStartPosition.Manual;
            toast.ShowInTaskbar = false;
            toast.TopMost = true;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.ForeColor = Color.White;
            lblTitle.Padding = new Padding(0, 3, 0, 0);
            lblTitle.Font = new Font("Cambria", 16, FontStyle.Bold);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 25;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            Label lblMsg = new Label();
            lblMsg.Text = message;
            lblMsg.ForeColor = Color.White;
            lblMsg.Padding = new Padding(0, 0, 0, 5);
            lblMsg.Font = new Font("Cambria", 14);
            lblMsg.Dock = DockStyle.Fill;
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;

            toast.Controls.Add(lblMsg);
            toast.Controls.Add(lblTitle);


            // POSITION FUNCTION
            void UpdatePosition()
            {
                toast.Location = new Point(
                    this.Right - toast.Width - 20,
                    this.Bottom - toast.Height - 40
                );
            }

            this.LocationChanged += (s, e) => UpdatePosition();
            this.SizeChanged += (s, e) => UpdatePosition();

            UpdatePosition();
            toast.Show();

            // AUTO CLOSE
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 2500;

            t.Tick += (s, e) =>
            {
                t.Stop();
                toast.Close();
                toast.Dispose();
                t.Dispose();
            };

            t.Start();
        }

        private void CenterCards()
        {
            if (flowPanel.Controls.Count == 0)
                return;

            Control card = flowPanel.Controls[0];

            int cardWidth = card.Width + card.Margin.Left + card.Margin.Right;

            // จำนวน card ที่ใส่ได้ต่อแถว
            int perRow = flowPanel.ClientSize.Width / cardWidth;

            if (perRow < 1)
                perRow = 1;

            // ความกว้างรวมของ card ใน 1 แถว
            int totalWidth = perRow * cardWidth;

            // ระยะซ้าย
            int leftPadding = (flowPanel.ClientSize.Width - totalWidth) / 2;

            if (leftPadding < 0)
                leftPadding = 0;

            flowPanel.Padding = new Padding(leftPadding, 10, 0, 10);
        }

        private void lbShoppa_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}