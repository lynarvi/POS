using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class CancelDetailsForm : Form
    {
        SoldItemsForm f;
        public CancelDetailsForm(SoldItemsForm frm)
        {
            InitializeComponent();
            f = frm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TransnoTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void DescriptionTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ActionCb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if ((ActionCb.Text != String.Empty) && (QtyTxt.Text != String.Empty) && (ReasonTxt.Text != String.Empty))
                {
                    if (int.Parse(QtyTxt.Text) >= int.Parse(CancelQtyTxt.Text))
                    {
                        VoidForm v = new VoidForm(this);
                        v.txtusername.Select();
                        v.txtusername.Focus();
                        v.ShowDialog();
                        
                    }
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        public void RefreshList()
        {
            f.LoadRecord();
        }

        private void CancelDetailsForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
