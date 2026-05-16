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
    public partial class PaymentCompleteForm : Form
    {
        public PaymentCompleteForm()
        {
            InitializeComponent();
        }

        private void btnViewStatus_Click(object sender, EventArgs e)
        {
            StatusForm form = new StatusForm();

            form.WindowState = this.WindowState;
            form.Show();

            this.Close();
        }
    }
}