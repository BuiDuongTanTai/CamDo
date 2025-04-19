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
    public partial class frmEditCustomer : Form
    {
        protected string cccd { get; set; }          // CCCD
        protected string hoten { get; set; }         // Họ tên
        protected string sdt { get; set; }           // Số điện thoại
        protected string diachi { get; set; }

        public frmEditCustomer(string cccd, string hoten,  string sdt, string diachi)
        {
            InitializeComponent();
            this.cccd = cccd;  
            this.hoten = hoten;
            this.sdt = sdt;
            this.diachi = diachi;
            this.Load += frmEditCustomer_Load;
        }

        private void frmEditCustomer_Load(object sender, EventArgs e)
        {
            txtCCCD.Text = cccd;
            txtName.Text = hoten;
            txtSDT.Text = sdt;
            txtAddress.Text = diachi;
        }

        public frmEditCustomer()
        {
            InitializeComponent();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ngăn không cho nhập ký tự không phải số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Hãy nhập vào tên khách hàng");
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Hãy nhập SĐT");
                return;
            }
            if (txtSDT.Text.Length != 10 || !txtSDT.Text[0].Equals('0'))
            {
                MessageBox.Show("Sai định dạng SĐT");
                return;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Hãy nhập vào địa chỉ khách hàng");
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn lưu chỉnh sửa khách hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Gọi phương thức cập nhật
                int result = Controllers.CustomerCtrl.update(cccd, hoten, sdt, diachi);

                // Kiểm tra kết quả cập nhật
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công. Vui lòng thử lại.");
                }
            
                this.Close();
            }
            else
                return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn huỷ chỉnh sửa hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
            else
                return;
        }
    }
}
