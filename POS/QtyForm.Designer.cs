namespace POS
{
    partial class QtyForm
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
            this.QtyTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // QtyTb
            // 
            this.QtyTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QtyTb.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QtyTb.Location = new System.Drawing.Point(0, 0);
            this.QtyTb.Multiline = true;
            this.QtyTb.Name = "QtyTb";
            this.QtyTb.Size = new System.Drawing.Size(190, 78);
            this.QtyTb.TabIndex = 0;
            this.QtyTb.Text = " 1";
            this.QtyTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.QtyTb.TextChanged += new System.EventHandler(this.QtyTb_TextChanged);
            this.QtyTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QtyTb_KeyPress);
            // 
            // QtyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 78);
            this.Controls.Add(this.QtyTb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QtyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantity";
            this.Load += new System.EventHandler(this.QtyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QtyTb;
    }
}