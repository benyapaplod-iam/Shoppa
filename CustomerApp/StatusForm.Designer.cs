namespace CustomerApp
{
    partial class StatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            logo = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Tomato;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 83);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20, 0, 20, 0);
            flowLayoutPanel1.Size = new Size(836, 311);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
           
            // 
            // logo
            // 
            logo.AutoSize = true;
            logo.Cursor = Cursors.Hand;
            logo.Font = new Font("Cambria", 27.80198F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logo.ForeColor = Color.White;
            logo.Location = new Point(12, 10);
            logo.Name = "logo";
            logo.Size = new Size(292, 46);
            logo.TabIndex = 1;
            logo.Text = "Shoppa | Status";
            logo.Click += logo_Click;
            // 
            // StatusForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tomato;
            ClientSize = new Size(834, 394);
            Controls.Add(logo);
            Controls.Add(flowLayoutPanel1);
            MinimumSize = new Size(850, 400);
            Name = "StatusForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StatusForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label logo;
    }
}