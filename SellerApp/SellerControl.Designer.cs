namespace SellerApp
{
    partial class SellerControl
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
            pnlCard = new Panel();
            lblBody = new RichTextBox();
            btnConfirm = new Button();
            lblOrder = new Label();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.WhiteSmoke;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.Controls.Add(lblBody);
            pnlCard.Controls.Add(btnConfirm);
            pnlCard.Controls.Add(lblOrder);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(340, 241);
            pnlCard.TabIndex = 0;
            // 
            // lblBody
            // 
            lblBody.BackColor = Color.WhiteSmoke;
            lblBody.BorderStyle = BorderStyle.None;
            lblBody.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBody.Location = new Point(34, 80);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(279, 81);
            lblBody.TabIndex = 4;
            lblBody.Text = "";
            lblBody.WordWrap = false;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.Tomato;
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(223, 182);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(90, 34);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblOrder
            // 
            lblOrder.AutoSize = true;
            lblOrder.Font = new Font("Cambria", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrder.Location = new Point(23, 27);
            lblOrder.Name = "lblOrder";
            lblOrder.Size = new Size(134, 34);
            lblOrder.TabIndex = 0;
            lblOrder.Text = "Order #1";
            // 
            // SellerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlCard);
            Name = "SellerControl";
            Size = new Size(340, 241);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCard;
        private Label lblOrder;
        private Button btnConfirm;
        private RichTextBox lblBody;
    }
}
