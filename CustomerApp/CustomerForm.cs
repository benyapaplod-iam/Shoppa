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

            // 3. เริ่มดึงข้อมูลจาก API (เรียกแค่ "ครั้งเดียว" พอครับ)
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

            // 3. โยนการ์ดทั้งหมดลงกล่องในคำสั่งเดียว! (เร็วกว่าเยอะมาก)
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

       
        // โค้ดส่วนวาดหน้าจอ (UI) คงไว้เหมือนเดิม
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            logoShopa = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(156, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(530, 25);
            textBox1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Location = new Point(52, 80);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(713, 317);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources._2849824_basket_buy_market_multimedia_shop_shopping_store_107977;
            pictureBox1.Location = new Point(710, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackColor = Color.White;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.truck_icon_136081;
            pictureBox2.Location = new Point(760, 26);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Tomato;
            panel1.Controls.Add(logoShopa);
            panel1.Location = new Point(-3, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(844, 418);
            panel1.TabIndex = 5;
            // 
            // logoShopa
            // 
            logoShopa.BackColor = Color.Transparent;
            logoShopa.Cursor = Cursors.Hand;
            logoShopa.Font = new Font("Cambria", 24.9504948F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoShopa.ForeColor = Color.White;
            logoShopa.Location = new Point(15, 14);
            logoShopa.Name = "logoShopa";
            logoShopa.Size = new Size(138, 47);
            logoShopa.TabIndex = 5;
            logoShopa.Text = "Shoppa";
            // 
            // Customer
            // 
            ClientSize = new Size(834, 409);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            MinimumSize = new Size(850, 400);
            Name = "Customer";
            Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }


        private void flowLayoutPanel1_Paint(object? sender, PaintEventArgs e) { }

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
