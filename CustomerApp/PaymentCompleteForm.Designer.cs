namespace CustomerApp
{
    partial class PaymentCompleteForm
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
            btnViewStatus = new Button();
            txtSuccess = new Label();
            txtHeader = new TextBox();
            labelCorrect = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnViewStatus);
            panel1.Controls.Add(txtSuccess);
            panel1.Controls.Add(txtHeader);
            panel1.Controls.Add(labelCorrect);
            panel1.Location = new Point(249, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 402);
            panel1.TabIndex = 0;
            // 
            // btnViewStatus
            // 
            btnViewStatus.BackColor = Color.FromArgb(64, 64, 64);
            btnViewStatus.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewStatus.ForeColor = Color.White;
            btnViewStatus.Location = new Point(54, 335);
            btnViewStatus.Name = "btnViewStatus";
            btnViewStatus.Size = new Size(184, 42);
            btnViewStatus.TabIndex = 4;
            btnViewStatus.TabStop = false;
            btnViewStatus.Text = "View Status";
            btnViewStatus.UseVisualStyleBackColor = false;
            btnViewStatus.Click += btnViewStatus_Click;
            // 
            // txtSuccess
            // 
            txtSuccess.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSuccess.Location = new Point(20, 201);
            txtSuccess.Name = "txtSuccess";
            txtSuccess.Size = new Size(248, 100);
            txtSuccess.TabIndex = 3;
            txtSuccess.Text = "Payment\r\nSuccess!";
            txtSuccess.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtHeader
            // 
            txtHeader.BorderStyle = BorderStyle.None;
            txtHeader.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtHeader.Location = new Point(3, 15);
            txtHeader.Name = "txtHeader";
            txtHeader.Size = new Size(282, 39);
            txtHeader.TabIndex = 1;
            txtHeader.TabStop = false;
            txtHeader.Text = "Shoppa Pay";
            txtHeader.TextAlign = HorizontalAlignment.Center;
            // 
            // labelCorrect
            // 
            labelCorrect.BackColor = Color.Transparent;
            labelCorrect.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCorrect.ForeColor = Color.FromArgb(0, 192, 0);
            labelCorrect.Location = new Point(54, 62);
            labelCorrect.Name = "labelCorrect";
            labelCorrect.Size = new Size(184, 128);
            labelCorrect.TabIndex = 5;
            labelCorrect.Text = "✅";
            labelCorrect.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PaymentCompleteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Tomato;
            ClientSize = new Size(796, 457);
            Controls.Add(panel1);
            Location = new Point(252, 27);
            Name = "PaymentCompleteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PaymentCompleteForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtHeader;
        private Label txtSuccess;
        private Button btnViewStatus;
        private Label labelCorrect;
    }
}