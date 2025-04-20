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
                    MessageBox.Show("Thêm hợp đồng thành công");

                    ExportContractToPdf(idhd, name, address, cccd, sdt, money, InterestRate,
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

        private void ExportContractToPdf(int contractId, string customerName, string customerAddress,
    string cccd, string phone, long money, decimal interestRate,
    DateTime beginDate, DateTime finishDate, string assetType, string assetDescription, string imagePath)
        {
            try
            {
                // Tạo thư mục lưu file
                string contractsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Contracts");
                if (!Directory.Exists(contractsDirectory))
                    Directory.CreateDirectory(contractsDirectory);

                // Xử lý tên file an toàn
                string safeCustomerName = string.Concat(customerName.Where(c => !Path.GetInvalidFileNameChars().Contains(c))).Replace(" ", "_");
                string pdfFileName = $"HopDong_{contractId}_{safeCustomerName}.pdf";
                string pdfFilePath = Path.Combine(contractsDirectory, pdfFileName);

                // Tạo PDF
                using (Document document = new Document(PageSize.A4, 50, 50, 50, 50))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                    document.Open();

                    // Font
                    string fontPath = @"c:\windows\fonts\arial.ttf";
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    PdfFont titleFont = new PdfFont(baseFont, 16, PdfFont.BOLD);
                    PdfFont headingFont = new PdfFont(baseFont, 12, PdfFont.BOLD);
                    PdfFont normalFont = new PdfFont(baseFont, 11, PdfFont.NORMAL);
                    PdfFont italicFont = new PdfFont(baseFont, 10, PdfFont.ITALIC);

                    // Tiêu đề
                    Paragraph title = new Paragraph("HỢP ĐỒNG CẦM ĐỒ", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20
                    };
                    document.Add(title);

                    // Mục A - Thông tin chung
                    document.Add(new Paragraph("A. THÔNG TIN CHUNG", headingFont) { SpacingAfter = 5 });
                    PdfPTable infoTable = new PdfPTable(2) { WidthPercentage = 100, SpacingAfter = 10 };
                    infoTable.AddCell(new Phrase("Số hợp đồng:", normalFont));
                    infoTable.AddCell(new Phrase(contractId.ToString(), normalFont));
                    infoTable.AddCell(new Phrase("Ngày lập:", normalFont));
                    infoTable.AddCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), normalFont));
                    infoTable.AddCell(new Phrase("Ngày cầm:", normalFont));
                    infoTable.AddCell(new Phrase(beginDate.ToString("dd/MM/yyyy"), normalFont));
                    infoTable.AddCell(new Phrase("Ngày hẹn trả:", normalFont));
                    infoTable.AddCell(new Phrase(finishDate.ToString("dd/MM/yyyy"), normalFont));
                    document.Add(infoTable);

                    // Mục B - Bên A
                    document.Add(new Paragraph("B. BÊN A – CỬA HÀNG CẦM ĐỒ", headingFont));
                    document.Add(new Paragraph("Tên cửa hàng: CỬA HÀNG CẦM ĐỒ TÀI VŨ", normalFont));
                    document.Add(new Paragraph("Địa chỉ: 123 Đường Lớn, Quận 7, TP.HCM", normalFont));
                    document.Add(new Paragraph("Đại diện: Bùi Dương Tấn Tài", normalFont));
                    document.Add(new Paragraph("", normalFont));

                    // Mục C - Bên B
                    document.Add(new Paragraph("C. BÊN B – NGƯỜI CẦM ĐỒ", headingFont));
                    document.Add(new Paragraph($"Họ và tên: {customerName}", normalFont));
                    document.Add(new Paragraph($"Địa chỉ: {customerAddress}", normalFont));
                    document.Add(new Paragraph($"CCCD: {cccd}", normalFont));
                    document.Add(new Paragraph($"Số điện thoại: {phone}", normalFont));
                    document.Add(new Paragraph("", normalFont));

                    // Mục D - Tài sản cầm cố
                    document.Add(new Paragraph("D. TÀI SẢN CẦM CỐ", headingFont));
                    document.Add(new Paragraph($"Loại tài sản: {assetType}", normalFont));
                    document.Add(new Paragraph($"Mô tả: {assetDescription}", normalFont));

                    if (File.Exists(imagePath))
                    {
                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imagePath);
                        if (pdfImage.Width > 400)
                        {
                            float ratio = pdfImage.Width / pdfImage.Height;
                            pdfImage.ScaleAbsolute(400, 400 / ratio);
                        }
                        pdfImage.SpacingBefore = 10;
                        pdfImage.SpacingAfter = 10;
                        document.Add(pdfImage);
                    }
                    document.Add(new Paragraph("", normalFont));

                    // Mục E - Tài chính
                    document.Add(new Paragraph("E. THỎA THUẬN TÀI CHÍNH", headingFont));
                    int days = (finishDate - beginDate).Days;
                    int months = (int)Math.Ceiling(days / 30.0);
                    decimal totalInterest = money * (interestRate / 100) * months;
                    decimal totalAmount = money + totalInterest;

                    document.Add(new Paragraph("", normalFont));
                    PdfPTable financeTable = new PdfPTable(2) { WidthPercentage = 100, SpacingAfter = 10 };
                    financeTable.AddCell(new Phrase("Số tiền cầm:", normalFont));
                    financeTable.AddCell(new Phrase($"{money:N0} VNĐ", normalFont));
                    financeTable.AddCell(new Phrase("Lãi suất:", normalFont));
                    financeTable.AddCell(new Phrase($"{interestRate}% / tháng", normalFont));
                    financeTable.AddCell(new Phrase("Thời hạn vay:", normalFont));
                    financeTable.AddCell(new Phrase($"{months} tháng", normalFont));
                    financeTable.AddCell(new Phrase("Tiền lãi ước tính:", normalFont));
                    financeTable.AddCell(new Phrase($"{totalInterest:N0} VNĐ", normalFont));
                    financeTable.AddCell(new Phrase("Tổng tiền phải trả:", normalFont));
                    financeTable.AddCell(new Phrase($"{totalAmount:N0} VNĐ", normalFont));
                    document.Add(financeTable);

                    // Mục F - Điều khoản
                    document.Add(new Paragraph("F. ĐIỀU KHOẢN HỢP ĐỒNG", headingFont));
                    document.Add(new Paragraph("1. Bên B cam kết tài sản là sở hữu hợp pháp, không tranh chấp.", normalFont));
                    document.Add(new Paragraph("2. Bên A giữ gìn tài sản cẩn thận, không sử dụng, không làm hư hỏng.", normalFont));
                    document.Add(new Paragraph("3. Nếu quá hạn mà Bên B không đến chuộc, Bên A có quyền thanh lý tài sản.", normalFont));
                    document.Add(new Paragraph("4. Hợp đồng có giá trị kể từ ngày ký và được lập thành 2 bản, mỗi bên giữ 1 bản.", normalFont));
                    document.Add(new Paragraph("", normalFont));

                    // Chữ ký
                    PdfPTable signatureTable = new PdfPTable(2) { WidthPercentage = 100, SpacingBefore = 30 };
                    PdfPCell cell1 = new PdfPCell(new Phrase("ĐẠI DIỆN BÊN A\n(Ký và ghi rõ họ tên)", headingFont));
                    PdfPCell cell2 = new PdfPCell(new Phrase("BÊN B\n(Ký và ghi rõ họ tên)", headingFont));
                    foreach (var cell in new[] { cell1, cell2 })
                    {
                        cell.Border = 0;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.PaddingBottom = 50;
                    }
                    signatureTable.AddCell(cell1);
                    signatureTable.AddCell(cell2);
                    document.Add(signatureTable);

                    // Ghi chú
                    PdfContentByte cb = writer.DirectContent;
                    cb.BeginText();
                    cb.SetFontAndSize(baseFont, 10);
                    cb.ShowTextAligned(Element.ALIGN_CENTER,
                        "Lưu ý: Hợp đồng có hiệu lực khi có đầy đủ chữ ký của hai bên.",
                        document.PageSize.Width / 2,
                        30, // khoảng cách mép dưới, chỉnh nhỏ hơn nếu muốn sát hơn
                        0);
                    cb.EndText();

                    document.Close();

                }

                MessageBox.Show($"Xuất hợp đồng thành công!\nFile lưu tại: {pdfFilePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = pdfFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
