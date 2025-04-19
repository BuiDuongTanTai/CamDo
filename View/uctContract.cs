using CamDo.Models;
using System.Data;


namespace CamDo.View
{
    public partial class uctContract : UserControl
    {

        public static uctContract uctCo = new uctContract();

        public uctContract()
        {
            InitializeComponent();
            this.Load += uctContract_Load; // Đăng ký sự kiện Load

        }

        private void btnCreateNewContract_Click(object sender, EventArgs e)
        {
            frmContract frm = new frmContract();
            frm.FormClosed += (s, args) => LoadDataToGrid();
            frm.ShowDialog();
        }

        private DataTable LoadData()
        {
            DataTable dt = connection_sql.FillDataTable(constant.show_Contract);
            return dt;

        }

        private void uctContract_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            DataTable dt = LoadData(); // Gọi LoadData để lấy dữ liệu
            dgvContract.DataSource = dt; // Ràng buộc dữ liệu vào DataGridView
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = -1; // Xóa lựa chọn hiện tại
            string keyword = txtSearch.Text.Trim();
            // Kiểm tra nếu TextBox để trống
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập ID hợp đồng để tìm kiếm.");
                return; // Ngăn không cho tiếp tục nếu không có từ khóa
            }
            DataTable dt = LoadDataSearched(keyword);
            dgvContract.DataSource = dt;
        }

        private DataTable LoadDataSearched(string keyword)
        {
            int idhd = int.Parse(keyword);
            DataTable dt = Controllers.ContractCtrl.search(idhd);
            // Kiểm tra dữ liệu trả về
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hợp đồng nào với ID này.");
            }
            return dt;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ngăn không cho nhập ký tự không phải số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Xoá nội dung trong TextBox tìm kiếm
            txtSearch.Clear();
            cmbStatus.SelectedIndex = -1; // Xóa lựa chọn hiện tại

            // Tải lại dữ liệu ban đầu vào DataGridView
            LoadDataToGrid();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            string selectedStatus = cmbStatus.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selectedStatus))
            {
                DataTable dt = LoadDataFiltered(selectedStatus);
                dgvContract.DataSource = dt;
            }
        }

        private DataTable LoadDataFiltered(string status)
        {
            DataTable dt = Controllers.ContractCtrl.filter(status);
            return dt;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvContract.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvContract.SelectedRows[0];

                // Lấy dữ liệu từ hàng được chọn
                int idHD = int.Parse(selectedRow.Cells["IDHD"].Value.ToString());
                int idTS = int.Parse(selectedRow.Cells["IDTS"].Value.ToString());
                long money = long.Parse(selectedRow.Cells["SoTien"].Value.ToString());
                decimal interestRate = decimal.Parse(selectedRow.Cells["LaiSuat"].Value.ToString());
                DateTime dateBegin = DateTime.Parse(selectedRow.Cells["NgayVay"].Value.ToString());
                DateTime dateFinish = DateTime.Parse(selectedRow.Cells["HanTra"].Value.ToString());
                string trangThai = selectedRow.Cells["TrangThai"].Value.ToString(); // Nếu có cột trạng thái

                // Tạo form chỉnh sửa và truyền dữ liệu
                frmEditContract editForm = new frmEditContract(idHD, idTS, money, interestRate, dateBegin, dateFinish, trangThai);
                editForm.FormClosed += (s, args) => LoadDataToGrid();
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvContract.SelectedRows.Count > 0)
            {
                // Lấy ID hợp đồng từ hàng được chọn
                DataGridViewRow selectedRow = dgvContract.SelectedRows[0];
                int idHD = int.Parse(selectedRow.Cells["IDHD"].Value.ToString());

                // Hiển thị hộp thoại xác nhận
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    // Gọi phương thức xóa từ Controller
                    int result = Controllers.ContractCtrl.delete(idHD); // Giả sử có phương thức delete(idHD)

                    // Kiểm tra kết quả xóa
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa hợp đồng thành công!");
                        LoadDataToGrid(); // Tải lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công. Vui lòng thử lại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
