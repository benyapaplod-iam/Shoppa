namespace CustomerApp
{
    partial class OrderItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Status = new Label();
            lblStatus = new Label();
            lblProductName = new Label();
            lblPrice = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Status
            // 
            Status.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Status.AutoSize = true;
            Status.Font = new Font("Cambria", 14.2574253F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Status.ImageAlign = ContentAlignment.TopLeft;
            Status.Location = new Point(654, 37);
            Status.Name = "Status";
            Status.Size = new Size(66, 23);
            Status.TabIndex = 0;
            Status.Text = "Status";
            Status.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Cambria", 12.1188116F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(654, 66);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Complete";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Cambria", 14.2574253F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.Location = new Point(141, 37);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(136, 23);
            lblProductName.TabIndex = 4;
            lblProductName.Text = "ProductName";
            lblProductName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Cambria", 12.1188116F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(141, 66);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 20);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Price";
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(33, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 86);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // OrderItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pictureBox1);
            Controls.Add(lblPrice);
            Controls.Add(lblProductName);
            Controls.Add(lblStatus);
            Controls.Add(Status);
            Name = "OrderItemControl";
            Size = new Size(800, 126);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Status;
        private Label lblStatus;
        private Label lblProductName;
        private Label lblPrice;
        private PictureBox pictureBox1;
    }
}
