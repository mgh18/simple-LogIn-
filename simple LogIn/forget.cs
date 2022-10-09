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
    public partial class forget : Form
    {
        public forget()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changePassDataContext db = new changePassDataContext();
            var query = db.tbl_managers.Where(pas => pas.username == txt_username.Text);
            if (query.Count() != 0)
            {
                label2.Text = (from p in db.tbl_managers select p).Single().password;
                txt_username.Text = "";
                txt_username.Focus();
            }
            else
            {
                MessageBox.Show("The user name is not correct!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Text = "";
                txt_username.Focus();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }
    }
}
