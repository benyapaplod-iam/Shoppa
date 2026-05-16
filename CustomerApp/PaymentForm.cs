using QRCoder;
using Shoppa.Data.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerApp
{
    public partial class PaymentForm : Form
    {
        private int orderId;
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string ApiBaseUrl = "https://localhost:7186/api/v1/Order";

        public PaymentForm(int orderId)
        {
            InitializeComponent();
            this.orderId = orderId;

            // เรียกโหลดข้อมูลทันทีที่ Form แสดงผล
            this.Shown += async (s, e) => await LoadOrderData();
        }

        private async Task LoadOrderData()
        {
            try
            {
                var order = await _httpClient.GetFromJsonAsync<Order>($"{ApiBaseUrl}/{orderId}");

                if (order != null)
                {
                    txtPrice.Text = $"Total : {order.TotalPrice:N2} บาท";
                    GenerateQR($"ORDER_ID:{order.OrderId}|TOTAL:{order.TotalPrice}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}");
            }
        }

        private async void btnPayment_Click(object sender, EventArgs e)
        {
            var updateData = new
            {
                orderId = this.orderId,
                paymentStatus = "Paid",
                orderStatus = "Confirmed"
            };

            var response = await _httpClient.PostAsJsonAsync($"{ApiBaseUrl}/update-status", updateData);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("ชำระเงินเรียบร้อยแล้ว!");
                CartManager.Items.Clear();
                PaymentCompleteForm completeForm = new PaymentCompleteForm();

                completeForm.WindowState = this.WindowState;
                completeForm.Show();

                this.Close();
            }
        }

        // --- ส่วนของ QR Code ---
        private void GenerateQR(string text)
        {
            using QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qr = new QRCode(data);
            Bitmap img = qr.GetGraphic(10);
            pictureQR.Image = img;
        }
    }
}