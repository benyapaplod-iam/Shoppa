using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shoppa.Data.Models;

namespace CustomerApp
{
    public partial class StatusForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private List<Order> allOrders = new List<Order>();

        private System.Windows.Forms.Timer resizeTimer;

        public StatusForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(flowLayoutPanel1, true, null);

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;

            this.Load += StatusForm_Load;

            flowLayoutPanel1.Resize += flowLayoutPanel1_Resize;

            //ตั้งค่า Timer ให้ทำงานหลังจากหยุดลากจอ 50 มิลลิวินาที
            resizeTimer = new System.Windows.Forms.Timer();
            resizeTimer.Interval = 50;
            resizeTimer.Tick += ResizeTimer_Tick;
        }

        private async void StatusForm_Load(object? sender, EventArgs e)
        {
            await LoadOrdersFromApi();
        }

        private async Task LoadOrdersFromApi()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();

                string apiUrl = "https://localhost:7186/api/v1/Order";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var orders = JsonSerializer.Deserialize<List<Order>>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (orders != null)
                    {
                        allOrders = orders;
                        DisplayOrders();
                    }
                }
                else
                {
                    MessageBox.Show($"ไม่สามารถดึงข้อมูลได้ (Status: {response.StatusCode})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เชื่อมต่อ Server ไม่ได้ กรุณาตรวจสอบการเปิด API\n\nError: " + ex.Message);
            }
        }

        private void DisplayOrders()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            List<Control> cardsToAdd = new List<Control>();
            int targetWidth = CalculateTargetWidth();

            foreach (var order in allOrders.OrderByDescending(o => o.OrderId))
            {
                OrderControl card = new OrderControl(order);
                card.Width = targetWidth;
                card.Margin = new Padding(0, 0, 0, 15);
                cardsToAdd.Add(card);
            }

            flowLayoutPanel1.Controls.AddRange(cardsToAdd.ToArray());
            flowLayoutPanel1.ResumeLayout();
        }

        // ส่วนจัดการการยืดหน้าจอแบบ Real-time
        private void flowLayoutPanel1_Resize(object? sender, EventArgs e)
        {
            // เมื่อลากจอ ให้รีเซ็ต Timer (ยังไม่ยืดการ์ดทันที)
            resizeTimer.Stop();
            resizeTimer.Start();
        }

        private void ResizeTimer_Tick(object? sender, EventArgs e)
        {
            resizeTimer.Stop(); 

            int targetWidth = CalculateTargetWidth();

            if (flowLayoutPanel1.Controls.Count > 0 && flowLayoutPanel1.Controls[0].Width == targetWidth)
                return;

            flowLayoutPanel1.SuspendLayout();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is OrderControl && control.Width != targetWidth)
                {
                    control.Width = targetWidth;
                }
            }

            flowLayoutPanel1.ResumeLayout();
        }

        private int CalculateTargetWidth()
        {
            int width = flowLayoutPanel1.ClientSize.Width - flowLayoutPanel1.Padding.Horizontal;
            if (flowLayoutPanel1.VerticalScroll.Visible)
            {
                width -= SystemInformation.VerticalScrollBarWidth;
            }
            return width > 100 ? width : 100;
        }

        private void logo_Click(object sender, EventArgs e)
        {
            Customer? mainForm = Application.OpenForms.OfType<Customer>().FirstOrDefault();

            if (mainForm != null)
            {
                //ดึงหน้าจอหลักกลับมาแสดง และคัดลอกขนาดหน้าจอให้ต่อเนื่องกัน
                mainForm.WindowState = this.WindowState;
                mainForm.Show();
            }
            else
            {
                //ถ้าหาหน้าจอเดิมไม่เจอ สร้างขึ้นมาใหม่
                Customer newMain = new Customer();
                newMain.WindowState = this.WindowState;
                newMain.Show();
            }

            this.Close();
        }

    }
}