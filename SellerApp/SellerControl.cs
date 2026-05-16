using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace SellerApp
{
    public partial class SellerControl : UserControl
    {
        private int _orderId;
        private Action _refresh; 
        private static readonly HttpClient _httpClient = new HttpClient();

        public SellerControl()
        {
            InitializeComponent();
        }

        public void SetData(int orderId, string body, Action refreshCallback)
        {
            _orderId = orderId;
            _refresh = refreshCallback;
            lblOrder.Text = $"Order #{orderId}";
            lblBody.Text = body;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                btnConfirm.Enabled = false;

                string url = $"https://localhost:7186/api/v1/Order/{_orderId}/confirm-shipping";
                var response = await _httpClient.PutAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    ConfirmForm nextForm = new ConfirmForm(_orderId);
                    nextForm.ShowDialog();

                    _refresh?.Invoke();

                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการยืนยัน");
                    btnConfirm.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                btnConfirm.Enabled = true;
            }
        }
    }
}