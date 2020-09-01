namespace POS
{
    partial class DiscountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscountForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ConfirmBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.IDlbl = new System.Windows.Forms.Label();
            this.PriceTb = new System.Windows.Forms.TextBox();
            this.PercentTb = new System.Windows.Forms.TextBox();
            this.AmountTb = new System.Windows.Forms.TextBox();
            this.SeniorIdtxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SeniorName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 43);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(508, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Discount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Discount (%)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Discount Amount";
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.ActiveBorderThickness = 1;
            this.ConfirmBtn.ActiveCornerRadius = 20;
            this.ConfirmBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.ConfirmBtn.ActiveForecolor = System.Drawing.Color.White;
            this.ConfirmBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.ConfirmBtn.BackColor = System.Drawing.Color.White;
            this.ConfirmBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConfirmBtn.BackgroundImage")));
            this.ConfirmBtn.ButtonText = "Confirm";
            this.ConfirmBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfirmBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBtn.ForeColor = System.Drawing.Color.Black;
            this.ConfirmBtn.IdleBorderThickness = 3;
            this.ConfirmBtn.IdleCornerRadius = 20;
            this.ConfirmBtn.IdleFillColor = System.Drawing.Color.White;
            this.ConfirmBtn.IdleForecolor = System.Drawing.Color.Black;
            this.ConfirmBtn.IdleLineColor = System.Drawing.SystemColors.ScrollBar;
            this.ConfirmBtn.Location = new System.Drawing.Point(211, 222);
            this.ConfirmBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(288, 49);
            this.ConfirmBtn.TabIndex = 9;
            this.ConfirmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // IDlbl
            // 
            this.IDlbl.AutoSize = true;
            this.IDlbl.Location = new System.Drawing.Point(18, 76);
            this.IDlbl.Name = "IDlbl";
            this.IDlbl.Size = new System.Drawing.Size(0, 13);
            this.IDlbl.TabIndex = 10;
            this.IDlbl.Visible = false;
            // 
            // PriceTb
            // 
            this.PriceTb.Enabled = false;
            this.PriceTb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceTb.Location = new System.Drawing.Point(211, 131);
            this.PriceTb.Multiline = true;
            this.PriceTb.Name = "PriceTb";
            this.PriceTb.Size = new System.Drawing.Size(288, 26);
            this.PriceTb.TabIndex = 11;
            this.PriceTb.TextChanged += new System.EventHandler(this.PriceTb_TextChanged);
            // 
            // PercentTb
            // 
            this.PercentTb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentTb.Location = new System.Drawing.Point(211, 163);
            this.PercentTb.Multiline = true;
            this.PercentTb.Name = "PercentTb";
            this.PercentTb.Size = new System.Drawing.Size(288, 26);
            this.PercentTb.TabIndex = 12;
            this.PercentTb.TextChanged += new System.EventHandler(this.PercentTb_TextChanged);
            // 
            // AmountTb
            // 
            this.AmountTb.Enabled = false;
            this.AmountTb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountTb.Location = new System.Drawing.Point(211, 195);
            this.AmountTb.Multiline = true;
            this.AmountTb.Name = "AmountTb";
            this.AmountTb.Size = new System.Drawing.Size(288, 26);
            this.AmountTb.TabIndex = 13;
            // 
            // SeniorIdtxt
            // 
            this.SeniorIdtxt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeniorIdtxt.Location = new System.Drawing.Point(211, 99);
            this.SeniorIdtxt.Multiline = true;
            this.SeniorIdtxt.Name = "SeniorIdtxt";
            this.SeniorIdtxt.Size = new System.Drawing.Size(288, 26);
            this.SeniorIdtxt.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Senior Citizen ID No.";
            // 
            // SeniorName
            // 
            this.SeniorName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeniorName.Location = new System.Drawing.Point(211, 67);
            this.SeniorName.Multiline = true;
            this.SeniorName.Name = "SeniorName";
            this.SeniorName.Size = new System.Drawing.Size(288, 26);
            this.SeniorName.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Name";
            // 
            // DiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(557, 278);
            this.ControlBox = false;
            this.Controls.Add(this.SeniorName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SeniorIdtxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AmountTb);
            this.Controls.Add(this.PercentTb);
            this.Controls.Add(this.PriceTb);
            this.Controls.Add(this.IDlbl);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DiscountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DiscountForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DiscountForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuThinButton2 ConfirmBtn;
        public System.Windows.Forms.Label IDlbl;
        private System.Windows.Forms.TextBox AmountTb;
        public System.Windows.Forms.TextBox PriceTb;
        public System.Windows.Forms.TextBox PercentTb;
        public System.Windows.Forms.TextBox SeniorIdtxt;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox SeniorName;
        private System.Windows.Forms.Label label6;
    }
}