namespace DeliveryStaffApp
{
    partial class DeliveryForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryForm));
            flowPanel = new FlowLayoutPanel();
            notifyIcon1 = new NotifyIcon(components);
            panel1 = new Panel();
            lbShoppa = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowPanel
            // 
            flowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowPanel.AutoScroll = true;
            flowPanel.Location = new Point(0, 75);
            flowPanel.Name = "flowPanel";
            flowPanel.Padding = new Padding(20);
            flowPanel.Size = new Size(834, 375);
            flowPanel.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lbShoppa);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(834, 69);
            panel1.TabIndex = 1;
            // 
            // lbShoppa
            // 
            lbShoppa.AutoSize = true;
            lbShoppa.Font = new Font("Cambria", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbShoppa.Location = new Point(12, 9);
            lbShoppa.Name = "lbShoppa";
            lbShoppa.Size = new Size(374, 41);
            lbShoppa.TabIndex = 0;
            lbShoppa.Text = "Shoppa | DeliveryStaff";
            lbShoppa.Click += lbShoppa_Click;
            // 
            // DeliveryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tomato;
            ClientSize = new Size(834, 450);
            Controls.Add(panel1);
            Controls.Add(flowPanel);
            MinimumSize = new Size(850, 400);
            Name = "DeliveryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowPanel;
        private NotifyIcon notifyIcon1;
        private Panel panel1;
        private Label lbShoppa;
    }
}
