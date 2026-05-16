namespace CustomerApp
{
    partial class CartItemRow
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
            checkBox1 = new CheckBox();
            pictureBoxItem = new PictureBox();
            lblTitle = new Label();
            lblDescription = new Label();
            btnMinus = new Button();
            btnPlus = new Button();
            lblQuantity = new Label();
            lblPrice = new Label();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).BeginInit();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(22, 40);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 0;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxItem
            // 
            pictureBoxItem.Location = new Point(60, 14);
            pictureBoxItem.Name = "pictureBoxItem";
            pictureBoxItem.Size = new Size(100, 68);
            pictureBoxItem.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxItem.TabIndex = 1;
            pictureBoxItem.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoEllipsis = true;
            lblTitle.Font = new Font("Cambria", 12.1188116F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(186, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(354, 20);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Product Name";
            // 
            // lblDescription
            // 
            lblDescription.AllowDrop = true;
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoEllipsis = true;
            lblDescription.Font = new Font("Segoe UI", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.FromArgb(64, 64, 64);
            lblDescription.Location = new Point(186, 44);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(354, 20);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "description";
            // 
            // btnMinus
            // 
            btnMinus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinus.Font = new Font("Segoe UI", 9.267326F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinus.Location = new Point(558, 41);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(29, 24);
            btnMinus.TabIndex = 4;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += btnMinus_Click;
            // 
            // btnPlus
            // 
            btnPlus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPlus.Font = new Font("Segoe UI", 9.267326F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlus.Location = new Point(614, 41);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(29, 24);
            btnPlus.TabIndex = 4;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            // 
            // lblQuantity
            // 
            lblQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(593, 45);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(15, 17);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "1";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Cambria", 12.1188116F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(676, 44);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 20);
            lblPrice.TabIndex = 7;
            lblPrice.Text = "Price";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Font = new Font("Segoe UI", 10.6930695F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(761, 38);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(49, 31);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "ลบ";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // CartItemRow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnDelete);
            Controls.Add(lblPrice);
            Controls.Add(lblQuantity);
            Controls.Add(btnPlus);
            Controls.Add(btnMinus);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(pictureBoxItem);
            Controls.Add(checkBox1);
            MinimumSize = new Size(500, 100);
            Name = "CartItemRow";
            Size = new Size(838, 100);
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private PictureBox pictureBoxItem;
        private Label lblTitle;
        private Label lblDescription;
        private Button btnMinus;
        private Button btnPlus;
        private Label lblQuantity;
        private Label lblPrice;
        private Button btnDelete;
    }
}
