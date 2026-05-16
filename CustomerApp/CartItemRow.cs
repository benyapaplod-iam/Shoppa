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
    public partial class CartItemRow : UserControl
    {
        private CartForm? _parentForm;
        public CartItemRow()
        {
            InitializeComponent();

            // ตั้งค่าจุดยึดคอนโทรลให้ขยับตามการขยายหน้าจอ
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPlus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinus.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // ผูก Event ปุ่มกด (ป้องกันการผูกซ้ำซ้อน)
            btnPlus.Click -= btnPlus_Click;
            btnPlus.Click += btnPlus_Click;

            btnMinus.Click -= btnMinus_Click;
            btnMinus.Click += btnMinus_Click;

            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;

            checkBox1.CheckedChanged += (s, e) => { _parentForm?.CalculateTotal(); };
        }
        public void SetParent(CartForm form)
        {
            _parentForm = form;
        }

        // --- Properties สำหรับรับส่งข้อมูล ---
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title { get { return lblTitle.Text; } set { lblTitle.Text = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description { get { return lblDescription.Text; } set { lblDescription.Text = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Quantity { get { return lblQuantity.Text; } set { lblQuantity.Text = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Price { get { return lblPrice.Text; } set { lblPrice.Text = value; } }
        // เพิ่ม Property นี้เพื่อเก็บ ID สินค้าจาก Database
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ProductId { get; set; }
        // เพิ่ม Property นี้ในไฟล์ CartItemRow.cs
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSelected
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImageUrl
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    try { pictureBoxItem.Load(value); } catch { }
                }
            }
        }

        // 1. ปุ่มบวกสินค้า (+)
        private void btnPlus_Click(object? sender, EventArgs e)
        {
            var item = CartManager.Items.FirstOrDefault(i => i.Title == this.Title);
            if (item != null)
            {
                item.Quantity++; // เพิ่มในระบบ
                this.Quantity = item.Quantity.ToString(); // อัปเดตตัวเลขบนหน้าจอ
                _parentForm?.CalculateTotal();
            }
        }

        // 2. ปุ่มลดสินค้า (-)
        private void btnMinus_Click(object? sender, EventArgs e)
        {
            var item = CartManager.Items.FirstOrDefault(i => i.Title == this.Title);
            if (item != null)
            {
                item.Quantity--; // ลดในระบบ

                if (item.Quantity <= 0)
                {
                    // ถ้าเหลือน้อยกว่าหรือเท่ากับ 0 ให้ลบทิ้งเหมือนปุ่ม Delete
                    RemoveThisItem(item);
                }
                else
                {
                    this.Quantity = item.Quantity.ToString(); // อัปเดตตัวเลขบนหน้าจอ
                }
            }
            _parentForm?.CalculateTotal();
        }

        // 3. ปุ่มลบรายการ (ลบทั้งหมด)
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            var item = CartManager.Items.FirstOrDefault(i => i.Title == this.Title);
            if (item != null)
            {
                RemoveThisItem(item);
            }
            _parentForm?.CalculateTotal();
        }
        // อย่าลืมผูก Event ให้ CheckBox ใน Constructor ของ CartItemRow ด้วยครับ
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _parentForm?.CalculateTotal();
        }

        // ฟังก์ชันช่วยสำหรับการลบข้อมูลทั้งในระบบและหน้าจอ
        private void RemoveThisItem(CartItemModel item)
        {
            CartManager.Items.Remove(item); // ลบออกจาก List ใน CartManager
            this.Dispose(); // ลบแถว UserControl นี้ออกจากหน้าจอ
        }
    }
}