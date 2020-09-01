namespace POS
{
    partial class LoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            this.LoginBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.ExitBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usertxt = new MetroFramework.Controls.MetroTextBox();
            this.passtxt = new MetroFramework.Controls.MetroTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.ActiveBorderThickness = 1;
            this.LoginBtn.ActiveCornerRadius = 20;
            this.LoginBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.LoginBtn.ActiveForecolor = System.Drawing.Color.Transparent;
            this.LoginBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.LoginBtn.BackColor = System.Drawing.Color.White;
            this.LoginBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginBtn.BackgroundImage")));
            this.LoginBtn.ButtonText = "Login";
            this.LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.LoginBtn.IdleBorderThickness = 1;
            this.LoginBtn.IdleCornerRadius = 20;
            this.LoginBtn.IdleFillColor = System.Drawing.Color.Transparent;
            this.LoginBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.LoginBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.LoginBtn.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.LoginBtn.Location = new System.Drawing.Point(13, 96);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(259, 47);
            this.LoginBtn.TabIndex = 7;
            this.LoginBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.ActiveBorderThickness = 1;
            this.ExitBtn.ActiveCornerRadius = 20;
            this.ExitBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.ExitBtn.ActiveForecolor = System.Drawing.Color.White;
            this.ExitBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ExitBtn.BackColor = System.Drawing.Color.White;
            this.ExitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExitBtn.BackgroundImage")));
            this.ExitBtn.ButtonText = "Exit";
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.ExitBtn.IdleBorderThickness = 1;
            this.ExitBtn.IdleCornerRadius = 20;
            this.ExitBtn.IdleFillColor = System.Drawing.Color.Transparent;
            this.ExitBtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.ExitBtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.ExitBtn.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.ExitBtn.Location = new System.Drawing.Point(13, 141);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(259, 45);
            this.ExitBtn.TabIndex = 9;
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 186);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(66, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.usertxt);
            this.panel2.Controls.Add(this.passtxt);
            this.panel2.Controls.Add(this.LoginBtn);
            this.panel2.Controls.Add(this.ExitBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 200);
            this.panel2.TabIndex = 15;
            // 
            // usertxt
            // 
            // 
            // 
            // 
            this.usertxt.CustomButton.Image = null;
            this.usertxt.CustomButton.Location = new System.Drawing.Point(226, 2);
            this.usertxt.CustomButton.Name = "";
            this.usertxt.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.usertxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.usertxt.CustomButton.TabIndex = 1;
            this.usertxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.usertxt.CustomButton.UseSelectable = true;
            this.usertxt.CustomButton.Visible = false;
            this.usertxt.DisplayIcon = true;
            this.usertxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.usertxt.Icon = ((System.Drawing.Image)(resources.GetObject("usertxt.Icon")));
            this.usertxt.Lines = new string[0];
            this.usertxt.Location = new System.Drawing.Point(13, 18);
            this.usertxt.MaxLength = 32767;
            this.usertxt.Multiline = true;
            this.usertxt.Name = "usertxt";
            this.usertxt.PasswordChar = '\0';
            this.usertxt.PromptText = "Username";
            this.usertxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usertxt.SelectedText = "";
            this.usertxt.SelectionLength = 0;
            this.usertxt.SelectionStart = 0;
            this.usertxt.ShortcutsEnabled = true;
            this.usertxt.Size = new System.Drawing.Size(260, 36);
            this.usertxt.TabIndex = 32;
            this.usertxt.UseSelectable = true;
            this.usertxt.WaterMark = "Username";
            this.usertxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.usertxt.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // passtxt
            // 
            // 
            // 
            // 
            this.passtxt.CustomButton.Image = null;
            this.passtxt.CustomButton.Location = new System.Drawing.Point(226, 2);
            this.passtxt.CustomButton.Name = "";
            this.passtxt.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.passtxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passtxt.CustomButton.TabIndex = 1;
            this.passtxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passtxt.CustomButton.UseSelectable = true;
            this.passtxt.CustomButton.Visible = false;
            this.passtxt.DisplayIcon = true;
            this.passtxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.passtxt.Icon = ((System.Drawing.Image)(resources.GetObject("passtxt.Icon")));
            this.passtxt.Lines = new string[0];
            this.passtxt.Location = new System.Drawing.Point(13, 60);
            this.passtxt.MaxLength = 32767;
            this.passtxt.Multiline = true;
            this.passtxt.Name = "passtxt";
            this.passtxt.PasswordChar = '•';
            this.passtxt.PromptText = "Password";
            this.passtxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passtxt.SelectedText = "";
            this.passtxt.SelectionLength = 0;
            this.passtxt.SelectionStart = 0;
            this.passtxt.ShortcutsEnabled = true;
            this.passtxt.Size = new System.Drawing.Size(260, 36);
            this.passtxt.TabIndex = 31;
            this.passtxt.UseSelectable = true;
            this.passtxt.WaterMark = "Password";
            this.passtxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passtxt.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 386);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginPage_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuThinButton2 LoginBtn;
        private Bunifu.Framework.UI.BunifuThinButton2 ExitBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public MetroFramework.Controls.MetroTextBox usertxt;
        public MetroFramework.Controls.MetroTextBox passtxt;





    }
}

