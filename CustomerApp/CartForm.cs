using Shoppa.Data.Models;
using Shoppa.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerApp
{
    public partial class CartForm : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public CartForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // ตั้งค่า FlowLayoutPanel ให้พร้อมใช้งาน
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            checkBoxAll.CheckedChanged += CheckBoxAll_CheckedChanged;

            btnOrderPurchase.Click -= btnOrderPurchase_Click;
            btnOrderPurchase.Click += btnOrderPurchase_Click;
            // เปลี่ยนจาก Load เป็น Shown เพื่อให้หน้าต่างกางออกเต็มที่ก่อนคำนวณขนาด 
            this.Shown += CartForm_Shown;
        }
        private void logoShopa_Click(object sender, EventArgs e)
        {
            // เมื่อคลิกที่โลโก้ ให้กลับไปหน้าหลัก
            this.Close();
        }
        private void CheckBoxAll_CheckedChanged(object? sender, EventArgs e)
        {
            // 1. ดูว่าช่อง All ถูกติ๊ก หรือ ปลดออก
            bool isChecked = checkBoxAll.Checked;

            // 2. วนลูปหาคอนโทรลลูกทั้งหมดที่อยู่ใน flowLayoutPanel1
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                // 3. เช็กว่าเป็น CartItemRow ใช่หรือไม่
                if (control is CartItemRow row)
                {
                    // 4. สั่งให้ติ๊กตามช่อง All
                    row.IsSelected = isChecked;
                }
            }
        }
        public void CalculateTotal()
        {
            decimal total = 0;

            // วนลูปดูทุกแถวสินค้าใน flowLayoutPanel1
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CartItemRow row)
                {
                    // คำนวณเฉพาะรายการที่ "ติ๊กถูก" เท่านั้น
                    if (row.IsSelected)
                    {
                        // แปลงราคาจาก String เป็น Decimal (ตัดเครื่องหมาย $ ออกถ้ามี)
                        string priceText = row.Price.Replace("$", "").Replace(",", "");
                        decimal price = 0;
                        decimal.TryParse(priceText, out price);

                        // แปลงจำนวนเป็นตัวเลข
                        int qty = 0;
                        int.TryParse(row.Quantity, out qty);

                        total += (price * qty);
                    }
                }
            }

            // แสดงผลที่ Label (ใส่คอมม่าและทศนิยม 2 ตำแหน่ง)
            lblTotalPrice.Text = total.ToString("#,##0.00");
        }
        private void CartForm_Shown(object? sender, EventArgs e)
        {
            RefreshCartUI();
        }

        private void RefreshCartUI()
        {
            flowLayoutPanel1.Controls.Clear();

            if (CartManager.Items.Count == 0)
            {
                Label emptyLabel = new Label
                {
                    Text = "ไม่มีสินค้าในตะกร้า",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Regular)
                };
                flowLayoutPanel1.Controls.Add(emptyLabel);
                return;
            }

            foreach (var item in CartManager.Items)
            {
                CartItemRow row = new CartItemRow();
                row.ProductId = item.ProductId;
                row.Title = item.Title;
                row.Description = item.Description;
                row.Price = $"${item.Price}";
                row.Quantity = item.Quantity.ToString();
                row.ImageUrl = item.ImageUrl;
                row.SetParent(this);

                row.Width = flowLayoutPanel1.ClientSize.Width - 25;


                flowLayoutPanel1.Controls.Add(row);
            }
            CalculateTotal();
        }

        // เมื่อมีการยืดหน้าจอ ให้ปรับความกว้างของแถวทั้งหมดตาม
        private void CartForm_Resize(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CartItemRow row)
                {
                    row.Width = flowLayoutPanel1.ClientSize.Width - 25;
                }
            }
        }

        private void lblLogo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnOrderPurchase_Click(object? sender, EventArgs e)
        {
            var selectedRows = flowLayoutPanel1.Controls.OfType<CartItemRow>()
                                .Where(r => r.IsSelected).ToList();

            if (selectedRows.Count == 0) { MessageBox.Show("กรุณาเลือกสินค้า"); return; }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // เตรียมข้อมูลส่งไป API
                var items = selectedRows.Select(r => new CartItemFlat
                {
                    ProductId = r.ProductId,
                    Quantity = int.Parse(r.Quantity)
                }).ToList();

                // ยิง API (ใช้ HttpClient ตัวเดิมที่ใช้ใน PaymentForm)
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7186/api/v1/Order/checkout", items);

                if (response.IsSuccessStatusCode)
                {
                    // รับค่า OrderId ที่ API สร้างให้
                    var result = await response.Content.ReadFromJsonAsync<CheckoutResponse>();
                    //MessageBox.Show("ได้เลข Order ID: " + result.OrderId);
                    PaymentForm payment = new PaymentForm(result.OrderId);
                    payment.WindowState = this.WindowState;
                    payment.Show();
                    this.Hide();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("สั่งซื้อไม่สำเร็จ: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        // Class 
        public class CheckoutResponse {

            [JsonPropertyName("orderId")]
            public int OrderId { get; set; } } 
    }
    
}