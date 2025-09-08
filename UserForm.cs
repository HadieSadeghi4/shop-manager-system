using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Myshop1
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myshopDataSet1.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.myshopDataSet1.Users);

        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            usersTableAdapter.FillByUserNameAndPass(myshopDataSet1.Users, txtUserName.Text, txtPassword.Text);
            if (myshopDataSet1.Users.Rows.Count > 0)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است", "خطا در ورود", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
