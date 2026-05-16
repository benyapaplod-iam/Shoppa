namespace SellerApp
{
    partial class ConfirmForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblSuccess = new Label();
            lblBody = new Label();
            BtnBack = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblSuccess
            // 
            lblSuccess.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSuccess.AutoSize = true;
            lblSuccess.Font = new Font("Leelawadee UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSuccess.ForeColor = Color.DarkGreen;
            lblSuccess.Location = new Point(36, 29);
            lblSuccess.Name = "lblSuccess";
            lblSuccess.Size = new Size(261, 47);
            lblSuccess.TabIndex = 0;
            lblSuccess.Text = "Order Success!";
            // 
            // lblBody
            // 
            lblBody.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblBody.AutoSize = true;
            lblBody.Font = new Font("Leelawadee UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBody.Location = new Point(89, 260);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(208, 21);
            lblBody.TabIndex = 1;
            lblBody.Text = "Order has been confirmed";
            // 
            // BtnBack
            // 
            BtnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnBack.Font = new Font("Leelawadee UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnBack.Location = new Point(140, 310);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(120, 40);
            BtnBack.TabIndex = 2;
            BtnBack.Text = "Back";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 99.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 192, 0);
            label1.Location = new Point(89, 91);
            label1.Name = "label1";
            label1.Size = new Size(224, 156);
            label1.TabIndex = 3;
            label1.Text = "✅";
            // 
            // ConfirmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 392);
            Controls.Add(label1);
            Controls.Add(BtnBack);
            Controls.Add(lblBody);
            Controls.Add(lblSuccess);
            Name = "ConfirmForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Confirm Order";
            Click += btnBack_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSuccess;

        private Label lblBody;

        private Button BtnBack;
        private Label label1;
    }
}