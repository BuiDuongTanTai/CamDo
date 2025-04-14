namespace CamDo.View
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(this, new EventArgs());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Hãy nhập vào tên đăng nhập");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Hãy nhập vào mật khẩu");
            }
            else
            {
                string user = txtUsername.Text;
                string pass = Controllers.UserLoginCtrl.encodePassword(txtPassword.Text);
                string check = Controllers.UserLoginCtrl.checkUserlogin(user, pass);

                if (check == "")
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                }
                else
                {
                    frmMain frm = new frmMain();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
