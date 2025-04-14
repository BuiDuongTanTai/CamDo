using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamDo.View
{
    public partial class frmUpdateUserlogin : Form
    {
        public frmUpdateUserlogin()
        {
            InitializeComponent();
        }

        private void reset()
        {
            txtPasswordOld.Text = "";
            txtPassword.Text = "";
            txtRepassword.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPasswordOld.Text == "")
            {
                reset();
                MessageBox.Show("Hãy nhập vào mật khẩu hiện tại!");
            }
            else if (txtPassword.Text == "")
            {
                reset();
                MessageBox.Show("Hãy nhập vào mật khẩu mới!");
            }
            else if (txtRepassword.Text == "")
            {
                reset();
                MessageBox.Show("Hãy nhập lại mật khẩu mới!");
            }
            else if (txtPassword.Text != txtRepassword.Text)
            {
                reset();
                MessageBox.Show("Bạn nhập mật khẩu mới không trùng nhau!");
            }
            else
            {
                string user = "admin";
                string pass = Controllers.UserLoginCtrl.encodePassword(txtPasswordOld.Text);
                string passnew = Controllers.UserLoginCtrl.encodePassword(txtPassword.Text);
                string check = Controllers.UserLoginCtrl.checkUserlogin(user, pass);
                if (check == "")
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!");
                }
                else
                {
                    Controllers.UserLoginCtrl.updateUserlogin(user, passnew);
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    Application.Restart();
                }
            }
        }

        private void frmUpdateUserlogin_Load(object sender, EventArgs e)
        {

        }
    }
}
