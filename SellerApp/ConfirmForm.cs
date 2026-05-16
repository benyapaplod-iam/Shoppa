using System;
using System.Windows.Forms;

namespace SellerApp
{
    public partial class ConfirmForm : Form
    {
        public ConfirmForm(int orderId)
        {
            InitializeComponent();

            lblSuccess.Text =
                $"Order #{orderId} Success!";
        }

        private void btnBack_Click(object sender,EventArgs e)
        {
            this.Close(); // ปิดหน้านี้เพื่อกลับไปหน้า SellerForm
        }
    }
}
