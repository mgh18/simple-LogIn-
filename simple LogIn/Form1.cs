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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changePassDataContext db = new changePassDataContext();
            var query = db.tbl_managers.Where(m => m.username == txt_username.Text && m.password == txt_password.Text);
            if (txt_password.Text != "" && txt_username.Text != "")
            {
                if (query.Count() != 0)
                {
                    changeP c = new changeP();
                    this.Hide();
                    c.ShowDialog();
                    txt_username.Text = "";
                    txt_password.Text = "";
                }
                else
                {
                    MessageBox.Show("User Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Text = "";
                    txt_password.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Text = "";
                txt_password.Text = "";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            forget fo = new forget();
            this.Hide();
            fo.ShowDialog();
        }

        
    }
}
