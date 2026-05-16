namespace DeliveryStaffApp
{
    partial class OrderCard
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
            lbOrderId = new Label();
            lbStatus = new Label();
            cmbStatus = new ComboBox();
            btnConfirm = new Button();
            lbBodyText = new RichTextBox();
            btnDel = new Button();
            SuspendLayout();
            // 
            // lbOrderId
            // 
            lbOrderId.AutoSize = true;
            lbOrderId.Font = new Font("Cambria", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbOrderId.Location = new Point(13, 12);
            lbOrderId.Name = "lbOrderId";
            lbOrderId.Size = new Size(154, 28);
            lbOrderId.TabIndex = 0;
            lbOrderId.Text = "Order #1001";
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbStatus.Location = new Point(20, 144);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(55, 19);
            lbStatus.TabIndex = 2;
            lbStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.Cursor = Cursors.Hand;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Pending", "Shipping", "Completed" });
            cmbStatus.Location = new Point(20, 173);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(127, 27);
            cmbStatus.TabIndex = 3;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(64, 64, 64);
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(218, 171);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(113, 29);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lbBodyText
            // 
            lbBodyText.BackColor = Color.White;
            lbBodyText.BorderStyle = BorderStyle.None;
            lbBodyText.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbBodyText.Location = new Point(20, 52);
            lbBodyText.Name = "lbBodyText";
            lbBodyText.ReadOnly = true;
            lbBodyText.Size = new Size(298, 78);
            lbBodyText.TabIndex = 5;
            lbBodyText.Text = "";
            lbBodyText.WordWrap = false;
            // 
            // btnDel
            // 
            btnDel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDel.Cursor = Cursors.Hand;
            btnDel.FlatAppearance.BorderSize = 0;
            btnDel.FlatStyle = FlatStyle.Flat;
            btnDel.ForeColor = Color.Black;
            btnDel.Location = new Point(314, 12);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(33, 23);
            btnDel.TabIndex = 6;
            btnDel.Text = "✕";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // OrderCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDel);
            Controls.Add(lbBodyText);
            Controls.Add(btnConfirm);
            Controls.Add(cmbStatus);
            Controls.Add(lbStatus);
            Controls.Add(lbOrderId);
            Margin = new Padding(10);
            Name = "OrderCard";
            Size = new Size(350, 230);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbOrderId;
        private Label lbStatus;
        private ComboBox cmbStatus;
        private Button btnConfirm;
        private RichTextBox lbBodyText;
        private Button btnDel;
    }
}
