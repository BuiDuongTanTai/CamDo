using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Globalization;
using PdfFont = iTextSharp.text.Font;


namespace CamDo.View
{
    public partial class frmContract : Form
    {

        private string imagePath; // Biến để lưu đường dẫn hình ảnh
        private bool isImageAdded = false; // Biến để kiểm tra trạng thái

        public frmContract()
        {
            InitializeComponent();
            ptbAssetImg.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Hãy nhập vào tên khách hàng");
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Hãy nhập vào địa chỉ khách hàng");
            }
            else if (txtCCCD.Text == "")
            {
                MessageBox.Show("Hãy nhập vào CCCD của khách hàng");
            }
            else if (txtCCCD.Text.Length != 12 || !txtCCCD.Text[0].Equals('0'))
            {
                MessageBox.Show("Sai định dạng CCCD");
            }
            else if (txtSDT.Text == "")
            {
                MessageBox.Show("Hãy nhập SĐT");
            }
            else if (txtSDT.Text.Length != 10 || !txtSDT.Text[0].Equals('0'))
            {
                MessageBox.Show("Sai định dạng SĐT");
            }
            else if (txtMoney.Text == "")
            {
                MessageBox.Show("Hãy nhập số tiền");
            }
            else if (long.Parse(txtMoney.Text) < 100000)
            {
                {
                    MessageBox.Show("Số tiền không được nhỏ hơn 100000");
                }
            }
            else if (decimal.Parse(nmInteresRate.Text) <= 0)
            {
                MessageBox.Show("Lãi suất phải lớn hơn 0.");
            }
            else if (dateFinish.Value <= dateBegin.Value.AddMonths(1))
            {
                MessageBox.Show("Hạn trả phải sau ngày cầm ít nhất 1 tháng.");
            }
            else if (cbAsset.Text == "")
            {
                MessageBox.Show("Hãy chọn loại tài sản");
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Hãy nhập mô tả sản phẩm");
            }
            else if (ptbAssetImg.Image == null)
            {
                MessageBox.Show("Hãy thêm ảnh về tài sản");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn thêm hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string name = txtName.Text;
                    string address = txtAddress.Text;
                    string cccd = txtCCCD.Text;
                    string sdt = txtSDT.Text;
                    long money = long.Parse(txtMoney.Text);
                    decimal InterestRate = decimal.Parse(nmInteresRate.Text);
                    DateTime dateBe = dateBegin.Value;
                    DateTime dateFi = dateFinish.Value;
                    string asset = cbAsset.Text;
                    string description = txtDescription.Text;

                    int idhd = Controllers.ContractCtrl.generalid();
                    int idts = Controllers.AssetCtrl.generalid();

                    int ass, con = 0;
                    int cus = Controllers.CustomerCtrl.check(cccd);
                    if (cus == 0)
                    {
                        cus = Controllers.CustomerCtrl.insert(cccd, name, sdt, address);
                        if (cus == 0)
                        {
                            MessageBox.Show("Thêm khách hàng thất bại");
                            return;
                        }
                    }
                    ass = Controllers.AssetCtrl.insert(idts, cccd, asset, description, imagePath);
                    if (ass == 0)
                    {
                        MessageBox.Show("Thêm tài sản thất bại");
                        // Xóa khách hàng đã 
                        Controllers.CustomerCtrl.delete(cccd);
                        return;
                    }
                    con = Controllers.ContractCtrl.insert(idhd, idts, money, InterestRate, dateBe, dateFi);
                    if (con == 0)
                    {
                        MessageBox.Show("Thêm hợp đồng thất bại");
                        // Xóa tài sản và khách hàng đã thêm
                        Controllers.AssetCtrl.delete(idts);
                        Controllers.CustomerCtrl.delete(cccd);
                        return;

                    }
                    Controllers.PdfExporter.ExportContractToPdf(idhd, name, address, cccd, sdt, money, InterestRate,
                dateBe, dateFi, asset, description, imagePath);

                    this.Close();
                }
                else
                    return;

            }
        }
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ngăn không cho nhập ký tự không phải số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void nmInteresRate_ValueChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem giá trị đã thay đổi
            if (nmInteresRate.Value % 0.1m != 0)
            {
                // Làm tròn giá trị
                nmInteresRate.Value = Math.Round(nmInteresRate.Value, 1);
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void txtCCCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void txtMoney_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void nmInteresRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void dateBegin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void dateFinish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void cbAsset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn huỷ thêm hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
            else
                return;
        }

        private void btnAddImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
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
                        imagePath = newFilePath;
                        isImageAdded = true; // Cập nhật trạng thái

                        ptbAssetImg.Visible = true; // Hiện PictureBox
                        this.Height = 858; // Điều chỉnh chiều cao form khi có ảnh
                        btnAdd.Location = new Point(72, 755); // Điều chỉnh vị trí nút "Thêm"
                        btnCancel.Location = new Point(321, 755); // Điều chỉnh vị trí nút "Huỷ"
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

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            string onlyDigits = new string(txtCCCD.Text.Where(char.IsDigit).ToArray());
            if (txtCCCD.Text != onlyDigits)
            {
                int selectionStart = txtCCCD.SelectionStart - 1;
                txtCCCD.Text = onlyDigits;
                txtCCCD.SelectionStart = Math.Max(0, selectionStart);
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string onlyDigits = new string(txtSDT.Text.Where(char.IsDigit).ToArray());
            if (txtSDT.Text != onlyDigits)
            {
                int selectionStart = txtSDT.SelectionStart - 1;
                txtSDT.Text = onlyDigits;
                txtSDT.SelectionStart = Math.Max(0, selectionStart);
            }
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            string onlyDigits = new string(txtMoney.Text.Where(char.IsDigit).ToArray());
            if (txtMoney.Text != onlyDigits)
            {
                int selectionStart = txtMoney.SelectionStart - 1;
                txtMoney.Text = onlyDigits;
                txtMoney.SelectionStart = Math.Max(0, selectionStart);
            }
        }
    }
}
