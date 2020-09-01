namespace POS
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.oldPassTxt = new MetroFramework.Controls.MetroTextBox();
            this.newPassTxt = new MetroFramework.Controls.MetroTextBox();
            this.confirmPassTxt = new MetroFramework.Controls.MetroTextBox();
            this.SaveBtn = new Bunifu.Framework.UI.BunifuThinButton2();
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
            this.panel1.Size = new System.Drawing.Size(300, 43);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(251, 0);
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
            this.label1.Size = new System.Drawing.Size(148, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Change Password";
            // 
            // oldPassTxt
            // 
            // 
            // 
            // 
            this.oldPassTxt.CustomButton.Image = null;
            this.oldPassTxt.CustomButton.Location = new System.Drawing.Point(226, 2);
            this.oldPassTxt.CustomButton.Name = "";
            this.oldPassTxt.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.oldPassTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.oldPassTxt.CustomButton.TabIndex = 1;
            this.oldPassTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.oldPassTxt.CustomButton.UseSelectable = true;
            this.oldPassTxt.CustomButton.Visible = false;
            this.oldPassTxt.DisplayIcon = true;
            this.oldPassTxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.oldPassTxt.Icon = ((System.Drawing.Image)(resources.GetObject("oldPassTxt.Icon")));
            this.oldPassTxt.Lines = new string[0];
            this.oldPassTxt.Location = new System.Drawing.Point(21, 64);
            this.oldPassTxt.MaxLength = 32767;
            this.oldPassTxt.Multiline = true;
            this.oldPassTxt.Name = "oldPassTxt";
            this.oldPassTxt.PasswordChar = '•';
            this.oldPassTxt.PromptText = "Old Password";
            this.oldPassTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.oldPassTxt.SelectedText = "";
            this.oldPassTxt.SelectionLength = 0;
            this.oldPassTxt.SelectionStart = 0;
            this.oldPassTxt.ShortcutsEnabled = true;
            this.oldPassTxt.Size = new System.Drawing.Size(260, 36);
            this.oldPassTxt.TabIndex = 4;
            this.oldPassTxt.UseSelectable = true;
            this.oldPassTxt.WaterMark = "Old Password";
            this.oldPassTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.oldPassTxt.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // newPassTxt
            // 
            // 
            // 
            // 
            this.newPassTxt.CustomButton.Image = null;
            this.newPassTxt.CustomButton.Location = new System.Drawing.Point(226, 2);
            this.newPassTxt.CustomButton.Name = "";
            this.newPassTxt.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.newPassTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.newPassTxt.CustomButton.TabIndex = 1;
            this.newPassTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.newPassTxt.CustomButton.UseSelectable = true;
            this.newPassTxt.CustomButton.Visible = false;
            this.newPassTxt.DisplayIcon = true;
            this.newPassTxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.newPassTxt.Icon = ((System.Drawing.Image)(resources.GetObject("newPassTxt.Icon")));
            this.newPassTxt.Lines = new string[0];
            this.newPassTxt.Location = new System.Drawing.Point(21, 106);
            this.newPassTxt.MaxLength = 32767;
            this.newPassTxt.Multiline = true;
            this.newPassTxt.Name = "newPassTxt";
            this.newPassTxt.PasswordChar = '•';
            this.newPassTxt.PromptText = "New Password";
            this.newPassTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.newPassTxt.SelectedText = "";
            this.newPassTxt.SelectionLength = 0;
            this.newPassTxt.SelectionStart = 0;
            this.newPassTxt.ShortcutsEnabled = true;
            this.newPassTxt.Size = new System.Drawing.Size(260, 36);
            this.newPassTxt.TabIndex = 5;
            this.newPassTxt.UseSelectable = true;
            this.newPassTxt.WaterMark = "New Password";
            this.newPassTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.newPassTxt.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // confirmPassTxt
            // 
            // 
            // 
            // 
            this.confirmPassTxt.CustomButton.Image = null;
            this.confirmPassTxt.CustomButton.Location = new System.Drawing.Point(226, 2);
            this.confirmPassTxt.CustomButton.Name = "";
            this.confirmPassTxt.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.confirmPassTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.confirmPassTxt.CustomButton.TabIndex = 1;
            this.confirmPassTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.confirmPassTxt.CustomButton.UseSelectable = true;
            this.confirmPassTxt.CustomButton.Visible = false;
            this.confirmPassTxt.DisplayIcon = true;
            this.confirmPassTxt.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.confirmPassTxt.Icon = ((System.Drawing.Image)(resources.GetObject("confirmPassTxt.Icon")));
            this.confirmPassTxt.Lines = new string[0];
            this.confirmPassTxt.Location = new System.Drawing.Point(21, 148);
            this.confirmPassTxt.MaxLength = 32767;
            this.confirmPassTxt.Multiline = true;
            this.confirmPassTxt.Name = "confirmPassTxt";
            this.confirmPassTxt.PasswordChar = '•';
            this.confirmPassTxt.PromptText = "Confirm New Password";
            this.confirmPassTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.confirmPassTxt.SelectedText = "";
            this.confirmPassTxt.SelectionLength = 0;
            this.confirmPassTxt.SelectionStart = 0;
            this.confirmPassTxt.ShortcutsEnabled = true;
            this.confirmPassTxt.Size = new System.Drawing.Size(260, 36);
            this.confirmPassTxt.TabIndex = 6;
            this.confirmPassTxt.UseSelectable = true;
            this.confirmPassTxt.WaterMark = "Confirm New Password";
            this.confirmPassTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.confirmPassTxt.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // SaveBtn
            // 
            this.SaveBtn.ActiveBorderThickness = 1;
            this.SaveBtn.ActiveCornerRadius = 20;
            this.SaveBtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.SaveBtn.ActiveForecolor = System.Drawing.Color.White;
            this.SaveBtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.SaveBtn.BackColor = System.Drawing.Color.White;
            this.SaveBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveBtn.BackgroundImage")));
            this.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SaveBtn.ButtonText = "SAVE";
            this.SaveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.Black;
            this.SaveBtn.IdleBorderThickness = 3;
            this.SaveBtn.IdleCornerRadius = 20;
            this.SaveBtn.IdleFillColor = System.Drawing.Color.White;
            this.SaveBtn.IdleForecolor = System.Drawing.Color.Black;
            this.SaveBtn.IdleLineColor = System.Drawing.SystemColors.ScrollBar;
            this.SaveBtn.Location = new System.Drawing.Point(21, 192);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(5);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(260, 49);
            this.SaveBtn.TabIndex = 30;
            this.SaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 245);
            this.ControlBox = false;
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.confirmPassTxt);
            this.Controls.Add(this.newPassTxt);
            this.Controls.Add(this.oldPassTxt);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangePasswordForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public MetroFramework.Controls.MetroTextBox oldPassTxt;
        public MetroFramework.Controls.MetroTextBox newPassTxt;
        public MetroFramework.Controls.MetroTextBox confirmPassTxt;
        private Bunifu.Framework.UI.BunifuThinButton2 SaveBtn;
    }
}