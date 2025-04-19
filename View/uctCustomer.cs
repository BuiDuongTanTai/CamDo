using CamDo.Models;
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
    public partial class uctCustomer : UserControl
    {
        public static uctCustomer uctCu = new uctCustomer();

        public uctCustomer()
        {
            InitializeComponent();
            this.Load += uctContract_Load; // Đăng ký sự kiện Load

        }
        private DataTable LoadData()
        {
            DataTable dt = connection_sql.FillDataTable(constant.show_Customer);
            return dt;

        }

        private void uctContract_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            DataTable dt = LoadData(); // Gọi LoadData để lấy dữ liệu
            dgvCustomer.DataSource = dt; // Ràng buộc dữ liệu vào DataGridView
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCustomer.SelectedRows[0];

                // Lấy dữ liệu từ hàng được chọn
                string cccd = selectedRow.Cells["CCCD"].Value.ToString();
                string name = selectedRow.Cells["HOTEN"].Value.ToString();
                string sdt = selectedRow.Cells["SDT"].Value.ToString();
                string diachi = selectedRow.Cells["DIACHI"].Value.ToString();

                // Tạo form chỉnh sửa và truyền dữ liệu
                frmEditCustomer editForm = new frmEditCustomer(cccd, name, sdt, diachi);
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
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                // Lấy ID hợp đồng từ hàng được chọn
                DataGridViewRow selectedRow = dgvCustomer.SelectedRows[0];
                string cccd = selectedRow.Cells["CCCD"].Value.ToString();
                int count = LoadDataSearchedCCCD(cccd).Rows.Count;

                // Kiểm tra hợp đồng có tài sản này đã được xoá chưa
                if (count != 0)
                {
                    MessageBox.Show("Tài sản của khách hàng đang được cầm, không thể xoá khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    // Hiển thị hộp thoại xác nhận
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa tài sản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        // Gọi phương thức xóa từ Controller
                        int result = Controllers.CustomerCtrl.delete(cccd); // Giả sử có phương thức delete(cccd)

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

        private DataTable LoadDataSearchedCCCD(string keyword)
        {
            DataTable dt = Controllers.CustomerCtrl.searchCCCD(keyword);
            // Kiểm tra dữ liệu trả về
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tài sản nào với ID này.");
            }
            return dt;
        }

        private DataTable LoadDataSearchedName(string keyword)
        {
            DataTable dt = Controllers.CustomerCtrl.searchName(keyword);
            // Kiểm tra dữ liệu trả về
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tài sản nào với ID này.");
            }
            return dt;
        }

        private void btnSearchCCCD_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập CCCD khách hàng để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id;
            if (!int.TryParse(keyword, out id))
            {
                MessageBox.Show("Vui lòng nhập một CCCD hợp lệ (số nguyên).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt = LoadDataSearchedCCCD(keyword);
            dgvCustomer.DataSource = dt;
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt = LoadDataSearchedName(keyword);
            dgvCustomer.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Xoá nội dung trong TextBox tìm kiếm
            txtSearch.Clear();
            // Tải lại dữ liệu ban đầu vào DataGridView
            LoadDataToGrid();
        }
    }
}
