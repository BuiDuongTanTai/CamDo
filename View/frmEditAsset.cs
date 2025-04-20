using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CamDo.View
{
    public partial class frmEditAsset : Form
    {

        protected int IDTS { get; set; }
        protected string CCCD { get; set; } // Số chứng minh nhân dân
        protected string TENTS { get; set; } // Tên tài sản
        protected string MOTA { get; set; } // Mô tả tài sản
        protected string HINHANH { get; set; } // Đường dẫn hình ảnh

        public frmEditAsset(int idTS, string cccd, string tents, string mota, string hinhanh)
        {
            InitializeComponent();
            IDTS = idTS;
            CCCD = cccd;
            TENTS = tents;
            MOTA = mota;
            HINHANH = hinhanh;
            this.Load += frmEditAsset_Load;
        }

        private void frmEditAsset_Load(object sender, EventArgs e)
        {
            // Gán giá trị cho các control trên form
            txtIDTS.Text = IDTS.ToString();
            txtCCCD.Text = CCCD;
            txtNameAsset.Text = TENTS;
            txtDescribe.Text = MOTA;

            // Kiểm tra và gán đường dẫn hình ảnh
            if (!string.IsNullOrEmpty(HINHANH))
            {
                // Có thể sử dụng PictureBox để hiển thị hình ảnh
                try
                {
                    ptbAssetImg.Image = System.Drawing.Image.FromFile(HINHANH);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                }
            }
            else
            {
                ptbAssetImg.Image = null; // Không có hình ảnh
            }
        }

        public frmEditAsset()
        {
            InitializeComponent();
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                bool isImageAdded = false; // Biến để kiểm tra trạng thái
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // Lọc loại tệp hình ảnh
                openFileDialog.Title = "Chọn Hình Ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn thư mục của ứng dụng
                    string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string destinationPath = Path.Combine(appDirectory, "Images"); // Thư mục Images trong dự án
                    string fileName = Path.GetFileName(openFileDialog.FileName);
                    string newFilePath = Path.Combine(destinationPath, fileName);

                    // Kiểm tra nếu thư mục không tồn tại thì tạo mới
                    if (!Directory.Exists(destinationPath))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }

                    // Sao chép tệp hình ảnh vào thư mục
                    File.Copy(openFileDialog.FileName, newFilePath, true); // true để ghi đè nếu tệp đã tồn tại

                    // Hiển thị hình ảnh trong PictureBox
                    try
                    {
                        ptbAssetImg.Image = System.Drawing.Image.FromFile(newFilePath);
                        // Lưu đường dẫn hình ảnh vào biến
                        HINHANH = newFilePath;
                        isImageAdded = true; // Cập nhật trạng thái
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("Tệp hình ảnh không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (OutOfMemoryException)
                    {
                        MessageBox.Show("Tệp không phải là hình ảnh hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn huỷ chỉnh sửa hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
            else
                return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameAsset.Text))
            {
                MessageBox.Show("Hãy nhập tên tài sản");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDescribe.Text))
            {
                MessageBox.Show("Hãy nhập mô tả tài sản");
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn lưu chỉnh sửa hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Gọi phương thức cập nhật
                int result = Controllers.AssetCtrl.update(IDTS, CCCD, TENTS, MOTA, HINHANH);

                // Kiểm tra kết quả cập nhật
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    this.DialogResult = DialogResult.OK;

                    //lấy ID hợp đồng từ DataGridView
                    DataTable dt = Controllers.ContractCtrl.searchAsset(IDTS);
                    int IDHD = int.Parse(dt.Rows[0]["IDHD"].ToString());
                    // Xuất hợp đồng ra PDF
                    Controllers.PdfExporter.ExportContractToPdf(IDHD);
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
    }
}
