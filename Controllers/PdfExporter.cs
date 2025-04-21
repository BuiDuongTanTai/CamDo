using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Globalization;
using PdfFont = iTextSharp.text.Font;
using System.Data;

namespace CamDo.Controllers
{
    internal class PdfExporter
    {
        // Phương thức xuất hợp đồng ra PDF
        public static void ExportContractToPdf(
            int contractId,
            string customerName,
            string customerAddress,
            string cccd,
            string phone,
            long money,
            decimal interestRate,
            DateTime beginDate,
            DateTime finishDate,
            string assetType,
            string assetDescription,
            string imagePath)
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
                    document.Add(new Paragraph("E. THỎA THUẬN TÀI CHÍNH", headingFont) { SpacingAfter = 5 });
                    int days = (finishDate - beginDate).Days;
                    int months = (int)Math.Ceiling(days / 30.0);
                    decimal totalInterest = money * (interestRate / 100) * months;
                    decimal totalAmount = money + totalInterest;

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

        // Phương thức tạo PDF từ thông tin hợp đồng (Overload)
        public static void ExportContractToPdf(int contractId)
        {
            try
            {
                // Lấy thông tin hợp đồng từ database
                DataTable contractList = ContractCtrl.search(contractId);
                if (contractList == null || contractList.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin hợp đồng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Lấy thông tin hợp đồng
                DataRow contractInfo = contractList.Rows[0];

                //Lấy id tài sản từ bảng hợp đồng
                int assetId = Convert.ToInt32(contractInfo["IDTS"]);
                DataTable assetList = AssetCtrl.searchID(assetId);
                if (assetList == null || assetList.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin tài sản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Lấy thông tin tài sản
                DataRow assetInfo = assetList.Rows[0];

                // Lấy thông tin khách hàng từ bảng tài sản
                string customerCCCD = assetInfo["CCCD"].ToString();
                DataTable customerList = CustomerCtrl.searchCCCD(customerCCCD);
                if (customerList == null || customerList.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Lấy thông tin khách hàng
                DataRow customerInfo = customerList.Rows[0];

                // Gọi phương thức xuất PDF với thông tin đầy đủ
                ExportContractToPdf(
                    contractId,
                    customerInfo["HOTEN"].ToString(),
                    customerInfo["DIACHI"].ToString(),
                    customerInfo["CCCD"].ToString(),
                    customerInfo["SDT"].ToString(),
                    long.Parse(contractInfo["SOTIEN"].ToString()),
                    decimal.Parse(contractInfo["LAISUAT"].ToString()),
                    DateTime.Parse(contractInfo["NGAYVAY"].ToString()),
                    DateTime.Parse(contractInfo["HANTRA"].ToString()),
                    assetInfo["TENTS"].ToString(),
                    assetInfo["MOTA"].ToString(),
                    assetInfo["HINHANH"].ToString()
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void deletePdf(int contractId)
        {
            try
            {
                // Lấy thông tin hợp đồng từ database
                DataTable contractList = ContractCtrl.search(contractId);
                if (contractList == null || contractList.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin hợp đồng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Lấy thông tin hợp đồng
                DataRow contractInfo = contractList.Rows[0];

                //Lấy id tài sản từ bảng hợp đồng
                int assetId = Convert.ToInt32(contractInfo["IDTS"]);
                DataTable assetList = AssetCtrl.searchID(assetId);
                if (assetList == null || assetList.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin tài sản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Lấy thông tin tài sản
                DataRow assetInfo = assetList.Rows[0];

                // Lấy thông tin khách hàng từ bảng tài sản
                string customerCCCD = assetInfo["CCCD"].ToString();
                DataTable customerList = CustomerCtrl.searchCCCD(customerCCCD);
                if (customerList == null || customerList.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Lấy thông tin khách hàng
                DataRow customerInfo = customerList.Rows[0];

                // Tạo đường dẫn đên thư mục chứ file pdf
                string contractsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Contracts");

                // Tên file PDF sẽ bao gồm ID hợp đồng và tên khách hàng
                string pdfFileName = $"HopDong_{contractId}_{customerInfo["HOTEN"].ToString().Replace(" ", "_")}.pdf";
                string pdfFilePath = Path.Combine(contractsDirectory, pdfFileName);

                // Kiểm tra nếu file tồn tại
                if (File.Exists(pdfFilePath))
                {
                    File.Delete(pdfFilePath); // Xóa file
                    MessageBox.Show("File đã được xóa thành công!");
                }
                else
                {
                    MessageBox.Show("File không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xóa file: {ex.Message}");
            }
        }
    }
}
