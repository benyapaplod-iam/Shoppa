namespace CustomerApp
{
    partial class ProductCard
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
            pictureBox1 = new PictureBox();
            lblPrice = new Label();
            lblQuantity = new Label();
            btnAdd = new Button();
            btnMinus = new Button();
            btnPlus = new Button();
            lblTitle = new Label();
            lblDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(14, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(186, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Cambria", 10.6930695F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(14, 220);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(46, 17);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "$0.00";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(152, 224);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(15, 17);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "0";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom;
            btnAdd.BackColor = Color.Black;
            btnAdd.Font = new Font("Cambria", 12.1188116F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(14, 247);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(186, 34);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnMinus
            // 
            btnMinus.Location = new Point(121, 220);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(25, 24);
            btnMinus.TabIndex = 5;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            // 
            // btnPlus
            // 
            btnPlus.Location = new Point(173, 220);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(27, 24);
            btnPlus.TabIndex = 6;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoEllipsis = true;
            lblTitle.Font = new Font("Cambria", 12.1188116F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(14, 147);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(120, 20);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Product Name";
       
            // 
            // lblDescription
            // 
            lblDescription.AutoEllipsis = true;
            lblDescription.Font = new Font("Segoe UI", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(14, 167);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(186, 41);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "...";
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(btnPlus);
            Controls.Add(btnMinus);
            Controls.Add(btnAdd);
            Controls.Add(lblQuantity);
            Controls.Add(lblPrice);
            Controls.Add(pictureBox1);
            Name = "ProductCard";
            Size = new Size(220, 293);        
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblPrice;
        private Label lblQuantity;
        private Button btnAdd;
        private Button btnMinus;
        private Button btnPlus;
        private Label lblTitle;
        private Label lblDescription;
    }
}
