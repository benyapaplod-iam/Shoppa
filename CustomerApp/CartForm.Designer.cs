namespace CustomerApp
{
    partial class CartForm
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
            pictureBox1 = new PictureBox();
            lblLogo = new Label();
            flowLayoutPanel2 = new Panel();
            btnOrderPurchase = new Button();
            lblbath = new Label();
            lblTotalPrice = new Label();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel = new Panel();
            checkBoxAll = new CheckBox();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Tomato;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lblLogo);
            panel1.Location = new Point(-6, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(871, 99);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._2849824_basket_buy_market_multimedia_shop_shopping_store_107977;
            pictureBox1.Location = new Point(179, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Cursor = Cursors.Hand;
            lblLogo.Font = new Font("Cambria", 25.6633663F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(27, 28);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(158, 42);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Shoppa |";
            lblLogo.Click += lblLogo_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.BackColor = Color.White;
            flowLayoutPanel2.Controls.Add(btnOrderPurchase);
            flowLayoutPanel2.Controls.Add(lblbath);
            flowLayoutPanel2.Controls.Add(lblTotalPrice);
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.ForeColor = SystemColors.ControlText;
            flowLayoutPanel2.Location = new Point(-6, 385);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(879, 105);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // btnOrderPurchase
            // 
            btnOrderPurchase.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOrderPurchase.Font = new Font("Leelawadee UI", 10.6930695F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOrderPurchase.Location = new Point(627, 53);
            btnOrderPurchase.Name = "btnOrderPurchase";
            btnOrderPurchase.Size = new Size(228, 24);
            btnOrderPurchase.TabIndex = 4;
            btnOrderPurchase.Text = "สั่งสินค้า";
            btnOrderPurchase.UseVisualStyleBackColor = true;
            btnOrderPurchase.Click += btnOrderPurchase_Click;
            // 
            // lblbath
            // 
            lblbath.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblbath.AutoSize = true;
            lblbath.Font = new Font("Leelawadee UI", 12.1188116F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblbath.Location = new Point(776, 19);
            lblbath.Name = "lblbath";
            lblbath.Size = new Size(49, 23);
            lblbath.TabIndex = 2;
            lblbath.Text = "/บาท";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalPrice.Font = new Font("Cambria", 12.1188116F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPrice.Location = new Point(672, 22);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(98, 20);
            lblTotalPrice.TabIndex = 3;
            lblTotalPrice.Text = "0";
            lblTotalPrice.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Leelawadee UI", 12.1188116F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(627, 19);
            label2.Name = "label2";
            label2.Size = new Size(39, 23);
            label2.TabIndex = 2;
            label2.Text = "รวม";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Location = new Point(5, 194);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(848, 169);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.BackColor = Color.White;
            flowLayoutPanel.Controls.Add(checkBoxAll);
            flowLayoutPanel.Controls.Add(label3);
            flowLayoutPanel.Location = new Point(5, 101);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(848, 87);
            flowLayoutPanel.TabIndex = 3;
            // 
            // checkBoxAll
            // 
            checkBoxAll.AutoSize = true;
            checkBoxAll.Location = new Point(35, 32);
            checkBoxAll.Name = "checkBoxAll";
            checkBoxAll.Size = new Size(15, 14);
            checkBoxAll.TabIndex = 2;
            checkBoxAll.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 25.6633663F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(73, 19);
            label3.Name = "label3";
            label3.Size = new Size(59, 44);
            label3.TabIndex = 1;
            label3.Text = "All";
            // 
            // CartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(861, 474);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel);
            MinimumSize = new Size(850, 400);
            Name = "CartForm";
            Text = "CartForm";
            Resize += CartForm_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblLogo;
        private Panel flowLayoutPanel2;
        private Label label2;
        private Label lblbath;
        private Label lblTotalPrice;
        private Button btnOrderPurchase;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel flowLayoutPanel;
        private Label label3;
        private CheckBox checkBoxAll;
        private PictureBox pictureBox1;
    }
}