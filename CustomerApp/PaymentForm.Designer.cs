namespace CustomerApp
{
    partial class PaymentForm
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
            panel1 = new Panel();
            btnPayment = new Button();
            txtPrice = new TextBox();
            qrFrame = new Panel();
            pictureQR = new PictureBox();
            txtHeader = new TextBox();
            panel1.SuspendLayout();
            qrFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureQR).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnPayment);
            panel1.Controls.Add(txtPrice);
            panel1.Controls.Add(qrFrame);
            panel1.Controls.Add(txtHeader);
            panel1.Location = new Point(252, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 402);
            panel1.TabIndex = 0;
            // 
            // btnPayment
            // 
            btnPayment.BackColor = Color.FromArgb(64, 64, 64);
            btnPayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPayment.ForeColor = Color.White;
            btnPayment.Location = new Point(46, 344);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(190, 38);
            btnPayment.TabIndex = 3;
            btnPayment.TabStop = false;
            btnPayment.Text = "ยืนยันชำระเงิน";
            btnPayment.UseVisualStyleBackColor = false;
            btnPayment.Click += btnPayment_Click;
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.None;
            txtPrice.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(3, 287);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(282, 28);
            txtPrice.TabIndex = 2;
            txtPrice.TabStop = false;
            txtPrice.Text = "Total Price";
            txtPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // qrFrame
            // 
            qrFrame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            qrFrame.BackColor = Color.White;
            qrFrame.BorderStyle = BorderStyle.FixedSingle;
            qrFrame.Controls.Add(pictureQR);
            qrFrame.Location = new Point(46, 72);
            qrFrame.Name = "qrFrame";
            qrFrame.Size = new Size(190, 195);
            qrFrame.TabIndex = 1;
            // 
            // pictureQR
            // 
            pictureQR.Location = new Point(10, 10);
            pictureQR.Name = "pictureQR";
            pictureQR.Size = new Size(170, 175);
            pictureQR.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureQR.TabIndex = 0;
            pictureQR.TabStop = false;
            // 
            // txtHeader
            // 
            txtHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtHeader.BorderStyle = BorderStyle.None;
            txtHeader.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtHeader.Location = new Point(3, 15);
            txtHeader.Name = "txtHeader";
            txtHeader.Size = new Size(282, 39);
            txtHeader.TabIndex = 0;
            txtHeader.TabStop = false;
            txtHeader.Text = "Shoppa Pay";
            txtHeader.TextAlign = HorizontalAlignment.Center;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tomato;
            ClientSize = new Size(796, 457);
            Controls.Add(panel1);
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PaymentForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            qrFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureQR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtHeader;
        private Panel qrFrame;
        private PictureBox pictureQR;
        private TextBox txtPrice;
        private Button btnPayment;
    }
}