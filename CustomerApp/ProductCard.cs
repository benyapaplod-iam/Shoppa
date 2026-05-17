using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerApp
{
    public partial class ProductCard : UserControl
    {
        // 1. ประกาศตัวแปร
        private int _currentQuantity = 0;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ProductId { get; set; }
        public ProductCard()
        {
            InitializeComponent();

            // เปิดโหมดลดการกระพริบของรูปภาพ
            this.DoubleBuffered = true;

            // ตั้งค่าเริ่มต้นให้ Label โชว์เลข 0 ทันทีตอนโหลดหน้าจอ
            lblQuantity.Text = _currentQuantity.ToString();

            // 1. สั่งล้าง Event เดิมทิ้งไปก่อน (จะได้ไม่เบิ้ล)
            btnMinus.Click -= btnMinus_Click;
            btnPlus.Click -= btnPlus_Click;
            btnAdd.Click -= btnAdd_Click;

            // 2. สั่งผูก Event เข้าไปใหม่ (รับประกันว่าปุ่มจะทำงานแค่ 1)
            btnMinus.Click += btnMinus_Click;
            btnPlus.Click += btnPlus_Click;
            btnAdd.Click += btnAdd_Click;
        }

        // ==========================================
        // ส่วนที่ 1: การจัดการปุ่ม + และ -
        // ==========================================

        private void btnPlus_Click(object? sender, EventArgs e)
        {
            _currentQuantity++; // บวก 1
            lblQuantity.Text = _currentQuantity.ToString(); // อัปเดตหน้าจอ
        }

        private void btnMinus_Click(object? sender, EventArgs e)
        {
            if (_currentQuantity > 0) // ป้องกันไม่ให้ติดลบ
            {
                _currentQuantity--; // ลบ 1
                lblQuantity.Text = _currentQuantity.ToString(); // อัปเดตหน้าจอ
            }
        }    

        // ==========================================
        // ส่วนที่ 2: ช่องทางรับส่งข้อมูล (Properties)
        // ==========================================

        public int SelectedQuantity
        {
            get { return _currentQuantity; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Price
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        private string _currentImageUrl = "";

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            // ดักไว้ก่อน: ถ้าจำนวนเป็น 0 หรือติดลบ ไม่ให้กดเพิ่มลงตะกร้า
            if (_currentQuantity <= 0)
            {
                // 👇 เรียกใช้ Toast แจ้งเตือนมุมขวาล่างแทน MessageBox
                Toast.Show("กรุณาเพิ่มจำนวนสินค้าก่อนกด Add", this.FindForm());
                return;
            }

            // 1. แปลงราคาที่เป็นตัวหนังสือให้กลับเป็นตัวเลข
            decimal productPrice = 0;
            string cleanPrice = lblPrice.Text.Replace("$", "").Replace(",", "");
            decimal.TryParse(cleanPrice, out productPrice);

            // 2. จัดของเตรียมส่งเข้าตะกร้า
            CartItemModel item = new CartItemModel
            {
                ProductId = this.ProductId,
                Title = lblTitle.Text,
                Description = lblDescription.Text,
                Price = productPrice,
                ImageUrl = _currentImageUrl,
                Quantity = _currentQuantity
            };

            CartManager.AddToCart(item);

            // 👇 เรียกใช้ Toast แจ้งเตือนว่าเพิ่มของสำเร็จ
            Toast.Show($"เพิ่ม {lblTitle.Text} \nจำนวน {_currentQuantity} ชิ้น ลงตะกร้าเรียบร้อย!", this.FindForm());

            // 4. คืนค่าจำนวนกลับเป็น 0
            _currentQuantity = 0;
            lblQuantity.Text = "0";
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImageUrl
        {
            get { return _currentImageUrl; }
            set
            {
                _currentImageUrl = value;
                if (!string.IsNullOrEmpty(value))
                {
                    try
                    {
                        pictureBox1.LoadAsync(value); // โหลดแบบไม่ให้จอค้าง
                    }
                    catch (Exception ex)
                    {
                        // ถ้าโหลดรูปพัง ก็ให้มันปล่อยผ่านไป ไม่ต้องเด้งเตือนกวนใจลูกค้า
                        Console.WriteLine("โหลดรูปไม่ได้ เพราะ: " + ex.Message);
                    }
                }
            }
        }
    }

    // ==========================================
    // ตัวสร้างการแจ้งเตือนมุมขวาล่าง (Toast Notification)
    // ต้องวางไว้นอก Class ProductCard แต่อยู่ใน Namespace เดียวกัน
    // ==========================================
    public static class Toast
    {
        // 👇 เพิ่ม Form parentForm เข้ามาในวงเล็บ เพื่อรับตำแหน่งของหน้าต่างโปรแกรม
        public static void Show(string message, Form? parentForm = null)
        {
            Form toast = new Form();
            toast.FormBorderStyle = FormBorderStyle.None;
            toast.BackColor = Color.FromArgb(40, 40, 40);
            toast.ForeColor = Color.White;
            toast.Size = new Size(350, 60);
            toast.TopMost = true;
            toast.ShowInTaskbar = false;
            toast.StartPosition = FormStartPosition.Manual;

            Label lbl = new Label();
            lbl.Text = message;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            toast.Controls.Add(lbl);

            // 👇 เปลี่ยนมาคำนวณพิกัดมุมขวาล่าง จาก "หน้าต่างโปรแกรม (parentForm)" แทน
            if (parentForm != null)
            {
                int x = parentForm.Location.X + parentForm.Width - toast.Width - 20;
                int y = parentForm.Location.Y + parentForm.Height - toast.Height - 20;
                toast.Location = new Point(x, y);
            }

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 2500;
            t.Tick += (s, e) => {
                t.Stop();
                toast.Close();
            };

            toast.Show();
            t.Start();
        }
    }
}
