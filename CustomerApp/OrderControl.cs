using Shoppa.Data.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CustomerApp
{
    public partial class OrderControl : UserControl
    {
        private Order _order;

        public OrderControl(Order order)
        {
            InitializeComponent();
            _order = order;

            // ให้ Card ยืดเต็มพื้นที่ด้านบน
            this.Dock = DockStyle.Top;
            this.DoubleBuffered = true; 

            // ตั้งค่า FlowLayoutPanel ภายใน Card
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Padding = new Padding(15);
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.flowLayoutPanel1.Resize += FlowLayoutPanel1_Resize;

            RenderOrderDetails();
        }

        private void FlowLayoutPanel1_Resize(object? sender, EventArgs e)
        {
            flowLayoutPanel1.SuspendLayout();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                // เช็กว่าของข้างในคือการ์ด OrderItemControl ใช่ไหม
                if (control is OrderItemControl item)
                {
                    // สั่งการ์ดลูกให้กว้างเท่ากล่องแม่ (หักระยะขอบออกประมาณ 25px ให้ดูสวย)
                    item.Width = flowLayoutPanel1.ClientSize.Width - 25;
                }
            }

            flowLayoutPanel1.ResumeLayout();
        }

        private void RenderOrderDetails()
        {
            // 1. เช็คว่ามีสินค้าหรือไม่
            bool hasItems = _order != null && _order.Orderitems != null && _order.Orderitems.Any();

            if (!hasItems)
            {
                this.Visible = false;
                this.Height = 0;
                flowLayoutPanel1.Controls.Clear();
                return;
            }

            // 2. ถ้ามีสินค้า: ให้กลับมาแสดงผล
            this.Visible = true;
            flowLayoutPanel1.Visible = true;

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            Label lblHeader = new Label
            {
                Text = $"Order ID: #{_order.OrderId}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 45),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 10)
            };
            flowLayoutPanel1.Controls.Add(lblHeader);

            // --- สร้างรายการสินค้า ---
            foreach (var item in _order.Orderitems)
            {
                OrderItemControl itemUI = new OrderItemControl(
                    item.Product?.ProductName ?? "Unknown Product",
                    item.Quantity,
                    item.Price,
                    _order.OrderStatus ?? "Pending",
                    item.Product?.ImageUrl ?? ""
                );
                itemUI.Width = flowLayoutPanel1.Width - flowLayoutPanel1.Padding.Horizontal;
                flowLayoutPanel1.Controls.Add(itemUI);
            }

            // --- สร้าง Footer (ป้ายแคปซูลพอดีตัวหนังสือ) ---

            // สร้าง Label ก่อนเพื่อหาความกว้างที่เหมาะสม
            Label lblTotalText = new Label
            {
                Text = $"รายการทั้งหมด: {_order.Orderitems.Count} รายการ  |  ยอดรวมสุทธิ: {_order.TotalPrice:N2} บาท",
                Font = new Font("Leelawadee UI", 11, FontStyle.Bold),
                ForeColor = Color.Tomato,
                AutoSize = true // ให้คำนวณความกว้างเอง
            };

            // สร้างกรอบแคปซูล ให้กว้างตาม Label + ระยะขอบ
            Panel footerContainer = new Panel
            {
                BackColor = Color.White,
                Width = lblTotalText.PreferredWidth + 50,
                Height = 45, // ปรับความสูงให้ดูเป็นป้ายสวยๆ
                Margin = new Padding(0, 10, 0, 15)
            };

            // จัดตำแหน่งตัวหนังสือให้อยู่ตรงกลางกรอบพอดี
            lblTotalText.Location = new Point(25, (footerContainer.Height - lblTotalText.PreferredHeight) / 2);
            footerContainer.Controls.Add(lblTotalText);

            // ตัดขอบมน (โค้ดนี้จะอัปเดตอัตโนมัติเวลายืดหดจอ)
            footerContainer.SizeChanged += (s, e) => {
                Panel p = (Panel)s;
                if (p.Width > 0 && p.Height > 0)
                {
                    using (var path = GetCapsulePath(p.ClientRectangle))
                    {
                        p.Region = new Region(path);
                    }
                }
            };

            flowLayoutPanel1.Controls.Add(footerContainer);

            AdjustHeight(); // อย่าลืมเรียก AdjustHeight ให้มันปรับความสูงของ Card ทั้งหมด
            flowLayoutPanel1.ResumeLayout();
        }

        private System.Drawing.Drawing2D.GraphicsPath GetCapsulePath(Rectangle rect)
        {
            float diameter = rect.Height;
            RectangleF arc = new RectangleF(rect.X, rect.Y, diameter, diameter);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // วาดส่วนโค้งซ้าย
            path.AddArc(arc, 90, 180);
            // วาดส่วนโค้งขวา
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 180);

            path.CloseFigure();
            return path;
        }

        private void AdjustHeight()
        {
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                this.Height = 0;
                return;
            }

            int totalHeight = flowLayoutPanel1.Padding.Vertical;
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                totalHeight += (c.Height + c.Margin.Vertical);
            }

            if (flowLayoutPanel1.Height != totalHeight)
            {
                flowLayoutPanel1.Height = totalHeight;
            }

            int finalHeight = flowLayoutPanel1.Bottom + 10;
            this.Height = finalHeight;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.Parent == null || this.Width <= 0) return;

            int newFlowWidth = this.Width - (flowLayoutPanel1.Left * 2);

            if (flowLayoutPanel1.Width != newFlowWidth)
            {
                this.SuspendLayout();
                flowLayoutPanel1.Width = newFlowWidth;

                int childWidth = flowLayoutPanel1.Width - flowLayoutPanel1.Padding.Horizontal;

                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    // เช็คก่อนว่าใช่ OrderItemControl ไหม ค่อยสั่งยืด
                    if (c is OrderItemControl && c.Width != childWidth)
                    {
                        c.Width = childWidth;
                    }
                }

                // AdjustHeight();

                this.ResumeLayout(false);
            }
        }
    }
}