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
    public partial class OrderItemControl : UserControl
    {
        public OrderItemControl(string productName, int quantity, decimal price, string order_status, string imageUrl)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            lblProductName.Text = $"{productName} (x{quantity})";

            decimal totalLinePrice = quantity * price;
            lblPrice.Text = totalLinePrice.ToString("#,##0.00");
       
            lblStatus.Text = order_status;

            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                try
                {
                    // ใช้ LoadAsync จะช่วยให้หน้าจอ Status เปิดได้ลื่น ไม่ค้าง
                    pictureBox1.LoadAsync(imageUrl);
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }
            
            // (Status Badge)
            string currentStatus = order_status.ToLower();

            if (currentStatus == "complete" || currentStatus == "completed")
            {
                // สถานะ Complete -> ป้ายสีเขียว
                lblStatus.BackColor = Color.LightGreen;
                lblStatus.ForeColor = Color.DarkGreen;
            }
            else if (currentStatus == "confirm" || currentStatus == "confirmed")
            {
                // สถานะ Confirm -> ป้ายสีฟ้า
                lblStatus.BackColor = Color.LightBlue; 
                lblStatus.ForeColor = Color.DarkBlue;  
            }
            else
            {
                // สถานะอื่นๆ (เช่น Pending, Unpaid) -> ป้ายสีส้ม
                lblStatus.BackColor = Color.Moccasin;
                lblStatus.ForeColor = Color.DarkOrange;
            }

        }
    }
    
}