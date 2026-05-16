namespace SellerApp
{
    partial class SellerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            headerPanel = new Panel();
            label1 = new Label();
            flowOrders = new FlowLayoutPanel();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.Tomato;
            headerPanel.Controls.Add(label1);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(800, 78);
            headerPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Cambria", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(284, 43);
            label1.TabIndex = 0;
            label1.Text = "SHOPPA | Seller";
            label1.Click += label1_Click;
            // 
            // flowOrders
            // 
            flowOrders.AutoScroll = true;
            flowOrders.BackColor = Color.White;
            flowOrders.Dock = DockStyle.Fill;
            flowOrders.Location = new Point(0, 78);
            flowOrders.Name = "flowOrders";
            flowOrders.Padding = new Padding(20, 23, 20, 23);
            flowOrders.Size = new Size(800, 432);
            flowOrders.TabIndex = 1;
            // 
            // SellerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(800, 510);
            Controls.Add(flowOrders);
            Controls.Add(headerPanel);
            Name = "SellerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seller Dashboard";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;

        private System.Windows.Forms.FlowLayoutPanel flowOrders;

        private System.Windows.Forms.Label label1;
    }
}