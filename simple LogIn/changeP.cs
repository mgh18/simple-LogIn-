using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_LogIn
{
    public partial class changeP : Form
    {
        public changeP()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changePassDataContext db = new changePassDataContext();
            var query = (from pas in db.tbl_managers select pas).Single();
            if (txt_oldpass.Text != "")
            {
                if(txt_newpass.Text!=""&& txt_renewpass.Text != "")
                {
                    if(txt_newpass.Text == txt_renewpass.Text)
                    {
                        if (txt_oldpass.Text == textBox4.Text)
                        {
                            query.password = txt_newpass.Text;
                            db.SubmitChanges();
                            MessageBox.Show("The password changed successfully!", "change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_newpass.Text = "";
                            txt_oldpass.Text = "";
                            txt_renewpass.Text = "";
                            txt_oldpass.Focus();
                            changeP_Load(null, null);

                        }
                        else
                        {
                            MessageBox.Show("The current password is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_newpass.Text = "";
                            txt_oldpass.Text = "";
                            txt_renewpass.Text = "";
                            txt_oldpass.Focus();

                        }

                    }
                    else
                    {
                        MessageBox.Show("The passwords are not the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_newpass.Text = "";
                        txt_oldpass.Text = "";
                        txt_renewpass.Text = "";
                        txt_oldpass.Focus();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Enter your new password and repeat it!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_newpass.Text = "";
                    txt_oldpass.Text = "";
                    txt_oldpass.Focus();
                }
            }
            else
            {
                MessageBox.Show("Enter the current password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_newpass.Text = "";
                txt_oldpass.Text = "";
                txt_oldpass.Focus();
            }
        }

        private void changeP_Load(object sender, EventArgs e)
        {
            changePassDataContext db = new changePassDataContext();
            textBox4.Text = (from pass in db.tbl_managers select pass).Single().password;
        }
    }
}
