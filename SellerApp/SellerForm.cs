using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shoppa.Data.Models;

namespace SellerApp
{
    public partial class SellerForm : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string ApiUrl = "https://localhost:7186/api/v1/Order";

        public SellerForm()
        {
            InitializeComponent();
            // เรียกโหลดข้อมูลตอนเปิดหน้า

            // เวลา resize form ให้จัดกลางใหม่
            flowOrders.Resize += (s, e) => CenterCards();

            this.Shown += async (s, e) => await LoadOrders();
        }
        private async Task LoadOrders()
        {
            flowOrders.Controls.Clear();
            try
            {
                var orders = await _httpClient.GetFromJsonAsync<List<Order>>(ApiUrl);
                if (orders != null)
                {
                    // กรองเงื่อนไข: จ่ายแล้ว (Paid), ยังไม่ส่ง (Not Shipping), สถานะยืนยันแล้ว (Confirm)
                    var filteredOrders = orders.Where(o =>
                        o.PaymentStatus == "Paid" &&
                        o.ShippingStatus == "Not Shipping" &&
                        o.OrderStatus == "Confirmed"
                    ).ToList();

                    foreach (var order in filteredOrders)
                    {
                        string bodyText = string.Join(Environment.NewLine,
                            order.Orderitems.Select(oi => $"{oi.Product?.ProductName} x{oi.Quantity}"));

                        SellerControl card = new SellerControl();
                        // ส่ง Method LoadOrders ไปเป็น Callback เพื่อให้ลูกสั่ง Refresh พ่อได้
                        card.SetData(order.OrderId, bodyText, async () => await LoadOrders());

                        flowOrders.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void CenterCards()
        {
            if (flowOrders.Controls.Count == 0)
                return;

            Control card = flowOrders.Controls[0];

            int cardWidth =
                card.Width +
                card.Margin.Left +
                card.Margin.Right;

            // จำนวน card ต่อแถว
            int perRow =
                flowOrders.ClientSize.Width / cardWidth;

            if (perRow < 1)
                perRow = 1;

            // ความกว้างรวม
            int totalWidth =
                perRow * cardWidth;

            // ระยะซ้าย
            int leftPadding =
                (flowOrders.ClientSize.Width - totalWidth) / 2;

            if (leftPadding < 0)
                leftPadding = 0;

            flowOrders.Padding =
                new Padding(leftPadding, 10, 0, 10);
        }

        private async void label1_Click(object sender, EventArgs e)
        {
            await LoadOrders();
        }
    }
}