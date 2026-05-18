using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CustomerApp
{
    public partial class Customer : Form
    {
        // 1. เพิ่ม HttpClient สำหรับดึงข้อมูลจาก API
        private static readonly HttpClient client = new HttpClient();
        private List<ProductModel> allProducts = new List<ProductModel>();
        public Customer()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // ผูก Event ว่าพอเปิดหน้าฟอร์มนี้ขึ้นมา ให้วิ่งไปดึงข้อมูล API ทันที
            this.Load += Customer_Load;
            // ผูกเหตุการณ์เมื่อมีการพิมพ์ในช่องค้นหา (textBox1)
            this.textBox1.TextChanged += TextBox1_TextChanged;

            flowLayoutPanel1.Resize += flowLayoutPanel1_Resize;
        }

        private async void Customer_Load(object? sender, EventArgs e)
        {

            GraphicsPath path1 = new GraphicsPath();
            path1.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Region = new Region(path1);

            GraphicsPath path2 = new GraphicsPath();
            path2.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Region = new Region(path2);

            // 2. ตั้งค่ากล่องสินค้า
            flowLayoutPanel1.AutoScroll = true;

            // 3. เริ่มดึงข้อมูลจาก API (เรียกแค่ "ครั้งเดียว")
            await LoadProductsFromApi();
        }
        // 3. ฟังก์ชันดักจับการพิมพ์
        private void TextBox1_TextChanged(object? sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.ToLower(); // รับคำค้นหาและทำเป็นตัวพิมพ์เล็ก
            FilterProducts(searchTerm);
        }
        // 4. ฟังก์ชันสำหรับการกรองและการแสดงผลสินค้า
        private void FilterProducts(string searchTerm)
        {
            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();

            var filteredList = allProducts.Where(p =>
                string.IsNullOrEmpty(searchTerm) ||
                (p.Name != null && p.Name.ToLower().Contains(searchTerm))
            ).ToList();

            // 2. สร้างกล่องพักของ (List) เพื่อเตรียมการ์ดไว้ก่อน
            List<Control> cardsToAdd = new List<Control>();

            foreach (var item in filteredList)
            {
                ProductCard card = new ProductCard();
                card.ProductId = item.Id;
                card.Title = item.Name ?? "Unknown";
                card.Price = $"${item.Price}";
                card.ImageUrl = item.ImageUrl ?? "";
                card.Description = item.Description ?? "No description available.";
                card.Margin = new Padding(15);

                // เอาการ์ดไปพักไว้ใน List ก่อน ยังไม่ Add ลงจอ
                cardsToAdd.Add(card);
            }

            // 3. โยนการ์ดทั้งหมดลงกล่องในคำสั่งเดียว! 
            flowLayoutPanel1.Controls.AddRange(cardsToAdd.ToArray());

            CenterProducts();

            // 4. สั่งให้หน้าจอกลับมาทำงานและวาดทุกอย่างขึ้นมาพร้อมกัน
            flowLayoutPanel1.ResumeLayout();
        }
        private void flowLayoutPanel1_Resize(object? sender, EventArgs e)
        {
            // เมื่อหน้าจอเปลี่ยนขนาด ให้คำนวณการจัดกลางใหม่
            CenterProducts();
        }

        private void CenterProducts()
        {
            // เช็กก่อนว่ามีการ์ดสินค้าอยู่ข้างในไหม ถ้าไม่มีก็ไม่ต้องทำอะไร
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                // 1. ดึงขนาดของการ์ด 1 ใบ (กว้าง + ระยะขอบซ้ายขวา)
                int cardWidth = flowLayoutPanel1.Controls[0].Width + flowLayoutPanel1.Controls[0].Margin.Left + flowLayoutPanel1.Controls[0].Margin.Right;

                // 2. คำนวณว่าใน 1 แถวของจอตอนนี้ วางการ์ดได้สูงสุดกี่ใบ
                int columns = flowLayoutPanel1.ClientSize.Width / cardWidth;

                if (columns == 0) return;

                // 3. คำนวณหา "พื้นที่ว่างที่เหลือ" ด้านขวามือ
                int leftoverSpace = flowLayoutPanel1.ClientSize.Width - (columns * cardWidth);

                // 4. เอาพื้นที่ว่างมาหาร 2 แล้วดันให้เป็น Padding ด้านซ้าย (เพื่อผลักให้กริดมาอยู่ตรงกลางพอดี)
                int leftPadding = leftoverSpace / 2;

                // อัปเดต Padding ของกล่องหลัก (ซ้าย, บน, ขวา, ล่าง)
                flowLayoutPanel1.Padding = new Padding(leftPadding, 20, 0, 20);
            }
        }

        // 3. ฟังก์ชันดึงข้อมูล API 
        private async Task LoadProductsFromApi()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                string apiUrl = "https://localhost:7186/api/v1/Product/products";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var products = JsonSerializer.Deserialize<List<ProductModel>>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    // Card
                    if (products != null)
                    {

                        allProducts = products;

                        // สั่งให้โปรแกรมสร้างการ์ดโดยดึงข้อมูลจาก allProducts (ส่งค่าว่างเพื่อให้โชว์ทั้งหมดในตอนแรก)
                        FilterProducts("");

                    }
                }
                else
                {
                    MessageBox.Show($"ไม่สามารถดึงข้อมูลได้ (Status: {response.StatusCode})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เชื่อมต่อ Server ไม่ได้ กรุณาเปิด ShoppaServer ไว้ด้วย\n\nError: " + ex.Message);
            }
        }    

       

        private void pictureBox1_Click(object? sender, EventArgs e)
        {
            CartForm cart = new CartForm();
            cart.WindowState = this.WindowState;

            //ถ้าปิดหน้าตะกร้า ให้ปิดโปรแกรม
            cart.FormClosed += (s, args) =>
            {
                this.WindowState = cart.WindowState;
                this.Show(); 
            };

            cart.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            StatusForm sf = new StatusForm();
            sf.WindowState = this.WindowState;
            sf.FormClosed += (s, args) =>
            {
                this.WindowState = sf.WindowState; 
                this.Show(); 
            };

            sf.Show();
            this.Hide();
        }
    }
    
}


    // Class รับข้อมูล
    public class ProductModel
    {
        [JsonPropertyName("productId")]
        public int Id { get; set; }
        [JsonPropertyName("productName")]
        public string? Name { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }
    }
