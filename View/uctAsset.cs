using CamDo.Models;
using Microsoft.VisualBasic.Devices;
using System.Data;
using System.Security.Cryptography;

namespace CamDo.View
{
    public partial class uctAsset : UserControl
    {
        public static uctAsset uctAs = new uctAsset();

        public uctAsset()
        {
            InitializeComponent();
            this.Load += uctContract_Load; // Đăng ký sự kiện Load

        }
        private DataTable LoadData()
        {
            DataTable dt = connection_sql.FillDataTable(constant.show_Asset);
            return dt;

        }

        private void uctContract_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            DataTable dt = LoadData(); // Gọi LoadData để lấy dữ liệu
            dgvAsset.DataSource = dt; // Ràng buộc dữ liệu vào DataGridView
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAsset.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAsset.SelectedRows[0];

                // Lấy dữ liệu từ hàng được chọn
                int idTS = int.Parse(selectedRow.Cells["IDTS"].Value.ToString());
                string cccd = selectedRow.Cells["CCCD"].Value.ToString();
                string nameAsset = selectedRow.Cells["TENTS"].Value.ToString();
                string describe = selectedRow.Cells["MOTA"].Value.ToString();
                string linkImage = selectedRow.Cells["HINHANH"].Value.ToString();

                // Tạo form chỉnh sửa và truyền dữ liệu
                frmEditAsset editForm = new frmEditAsset(idTS, cccd, nameAsset, describe, linkImage);
                editForm.FormClosed += (s, args) => LoadDataToGrid();
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void btnSearchID_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập ID tài sản để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id;
            if (!int.TryParse(keyword, out id))
            {
                MessageBox.Show("Vui lòng nhập một ID tài sản hợp lệ (số nguyên).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt = LoadDataSearchedID(keyword);
            dgvAsset.DataSource = dt;
        }

        private DataTable LoadDataSearchedID(string keyword)
        {
            int idts = int.Parse(keyword);
            DataTable dt = Controllers.AssetCtrl.searchID(idts);
            // Kiểm tra dữ liệu trả về
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tài sản nào với ID này.");
            }
            return dt;
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên tài sản để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt = LoadDataSearchedName(keyword);
            dgvAsset.DataSource = dt;
        }

        private DataTable LoadDataSearchedName(string keyword)
        {
            DataTable dt = Controllers.AssetCtrl.searchName(keyword);
            // Kiểm tra dữ liệu trả về
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tài sản nào với tên này.");
            }
            return dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Xoá nội dung trong TextBox tìm kiếm
            txtSearch.Clear();
            // Tải lại dữ liệu ban đầu vào DataGridView
            LoadDataToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAsset.SelectedRows.Count > 0)
            {
                // Lấy ID hợp đồng từ hàng được chọn
                DataGridViewRow selectedRow = dgvAsset.SelectedRows[0];
                int idTS = int.Parse(selectedRow.Cells["IDTS"].Value.ToString());
                DataTable dataTable = Controllers.ContractCtrl.searchAsset(idTS);
                int count = dataTable.Rows.Count; // Đếm số lượng hợp đồng có tài sản này

                // Kiểm tra hợp đồng có tài sản này đã được xoá chưa
                if (count != 0)
                {
                    MessageBox.Show("Tài sản vẫn đang được cầm, không thể xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    // Hiển thị hộp thoại xác nhận
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa tài sản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        // Gọi phương thức xóa từ Controller
                        int result = Controllers.AssetCtrl.delete(idTS); // Giả sử có phương thức delete(idTS)

                        // Kiểm tra kết quả xóa
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa tài sản thành công!");
                            LoadDataToGrid(); // Tải lại dữ liệu
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công. Vui lòng thử lại.");
                        }
                    }
                }
                   
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }
    }
}
