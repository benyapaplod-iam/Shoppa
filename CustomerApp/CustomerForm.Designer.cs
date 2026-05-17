namespace CustomerApp
{
    partial class Customer
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
            textBox1 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            logoShopa = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(156, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(530, 25);
            textBox1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Location = new Point(52, 80);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(713, 317);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources._2849824_basket_buy_market_multimedia_shop_shopping_store_107977;
            pictureBox1.Location = new Point(710, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackColor = Color.White;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.truck_icon_136081;
            pictureBox2.Location = new Point(760, 26);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Tomato;
            panel1.Controls.Add(logoShopa);
            panel1.Location = new Point(-3, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(844, 418);
            panel1.TabIndex = 5;
            // 
            // logoShopa
            // 
            logoShopa.BackColor = Color.Transparent;
            logoShopa.Cursor = Cursors.Hand;
            logoShopa.Font = new Font("Cambria", 24.9504948F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoShopa.ForeColor = Color.White;
            logoShopa.Location = new Point(15, 14);
            logoShopa.Name = "logoShopa";
            logoShopa.Size = new Size(138, 47);
            logoShopa.TabIndex = 5;
            logoShopa.Text = "Shoppa";
            // 
            // Customer
            // 
            ClientSize = new Size(834, 409);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            MinimumSize = new Size(850, 400);
            Name = "Customer";
            Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ตัวแปรหน้าจอทั้งหมด
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label logoShopa;
    }
}