using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Globalization;

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
                // Tạo thư mục lưu hợp đồng nếu chưa tồn tại
                string contractsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Contracts");
                if (!Directory.Exists(contractsDirectory))
                {
                    Directory.CreateDirectory(contractsDirectory);
                }

                // Tên file PDF sẽ bao gồm ID hợp đồng và tên khách hàng
                string pdfFileName = $"HopDong_{contractId}_{customerName.Replace(" ", "_")}.pdf";
                string pdfFilePath = Path.Combine(contractsDirectory, pdfFileName);

                // Tạo document
                using (Document document = new Document(PageSize.A4, 50, 50, 50, 50))
                {
                    // Tạo file writer
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                    document.Open();

                    // Font và style - sử dụng tên đầy đủ để tránh xung đột namespace
                    BaseFont baseFont = BaseFont.CreateFont(@"c:\windows\fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font headingFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                    // Tiêu đề hợp đồng
                    Paragraph title = new Paragraph("HỢP ĐỒNG CẦM ĐỒ", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    document.Add(title);

                    // Thông tin hợp đồng
                    document.Add(new Paragraph($"Số hợp đồng: {contractId}", headingFont));
                    document.Add(new Paragraph($"Ngày lập: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}", normalFont));
                    document.Add(new Paragraph("", normalFont));

                    // Thông tin khách hàng
                    document.Add(new Paragraph("THÔNG TIN KHÁCH HÀNG:", headingFont));
                    document.Add(new Paragraph($"Họ và tên: {customerName}", normalFont));
                    document.Add(new Paragraph($"Địa chỉ: {customerAddress}", normalFont));
                    document.Add(new Paragraph($"CCCD: {cccd}", normalFont));
                    document.Add(new Paragraph($"Số điện thoại: {phone}", normalFont));
                    document.Add(new Paragraph("", normalFont));

                    // Thông tin tài sản
                    document.Add(new Paragraph("THÔNG TIN TÀI SẢN CẦM CỐ:", headingFont));
                    document.Add(new Paragraph($"Loại tài sản: {assetType}", normalFont));
                    document.Add(new Paragraph($"Mô tả: {assetDescription}", normalFont));

                    // Thêm hình ảnh tài sản nếu có
                    if (File.Exists(imagePath))
                    {
                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imagePath);

                        // Điều chỉnh kích thước hình ảnh để vừa trang
                        if (pdfImage.Width > 400)
                        {
                            float ratio = pdfImage.Width / pdfImage.Height;
                            pdfImage.ScaleAbsolute(400, 400 / ratio);
                        }

                        document.Add(pdfImage);
                    }
                    document.Add(new Paragraph("", normalFont));

                    // Thông tin hợp đồng
                    document.Add(new Paragraph("ĐIỀU KHOẢN HỢP ĐỒNG:", headingFont));
                    document.Add(new Paragraph($"Số tiền cầm: {money.ToString("N0", new CultureInfo("vi-VN"))} VNĐ", normalFont));
                    document.Add(new Paragraph($"Lãi suất: {interestRate}% / tháng", normalFont));
                    document.Add(new Paragraph($"Ngày cầm: {beginDate.ToString("dd/MM/yyyy")}", normalFont));
                    document.Add(new Paragraph($"Ngày hẹn trả: {finishDate.ToString("dd/MM/yyyy")}", normalFont));

                    // Tính thời hạn vay và số tiền lãi ước tính
                    int months = ((finishDate.Year - beginDate.Year) * 12) + finishDate.Month - beginDate.Month;
                    decimal totalInterest = money * (interestRate / 100) * months;
                    decimal totalAmount = money + totalInterest;

                    document.Add(new Paragraph($"Thời hạn vay: {months} tháng", normalFont));
                    document.Add(new Paragraph($"Tiền lãi ước tính: {totalInterest.ToString("N0", new CultureInfo("vi-VN"))} VNĐ", normalFont));
                    document.Add(new Paragraph($"Tổng số tiền phải trả: {totalAmount.ToString("N0", new CultureInfo("vi-VN"))} VNĐ", normalFont));
                    document.Add(new Paragraph("", normalFont));

                    // Chữ ký
                    PdfPTable signatureTable = new PdfPTable(2);
                    signatureTable.WidthPercentage = 100;

                    PdfPCell cell1 = new PdfPCell(new Phrase("NGƯỜI CẦM ĐỒ\n(Ký và ghi rõ họ tên)", headingFont));
                    cell1.Border = 0;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell1.PaddingBottom = 50;

                    PdfPCell cell2 = new PdfPCell(new Phrase("ĐẠI DIỆN CỬA HÀNG\n(Ký và ghi rõ họ tên)", headingFont));
                    cell2.Border = 0;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingBottom = 50;

                    signatureTable.AddCell(cell1);
                    signatureTable.AddCell(cell2);

                    document.Add(signatureTable);

                    // Chú thích
                    Paragraph note = new Paragraph("Lưu ý: Đây là hợp đồng hợp lệ có giá trị pháp lý khi có đầy đủ chữ ký của các bên liên quan.",
                                                    new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.ITALIC));
                    note.Alignment = Element.ALIGN_CENTER;
                    document.Add(note);

                    document.Close();
                }

                // Hiển thị thông báo và mở file
                MessageBox.Show($"Xuất hợp đồng thành công!\nFile được lưu tại: {pdfFilePath}",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở file PDF sau khi tạo
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
        //public static string ExportContractToPdf(int contractId)
        //{
        //    try
        //    {
        //        // Lấy thông tin hợp đồng từ database
        //        var contractInfo = Controllers.ContractCtrl.GetContractById(contractId);
        //        if (contractInfo == null)
        //        {
        //            MessageBox.Show("Không tìm thấy thông tin hợp đồng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return null;
        //        }

        //        // Lấy thông tin tài sản
        //        var assetInfo = Controllers.AssetCtrl.GetAssetById(contractInfo.AssetId);
        //        if (assetInfo == null)
        //        {
        //            MessageBox.Show("Không tìm thấy thông tin tài sản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return null;
        //        }

        //        // Lấy thông tin khách hàng
        //        var customerInfo = Controllers.CustomerCtrl.GetCustomerByCCCD(assetInfo.CustomerCCCD);
        //        if (customerInfo == null)
        //        {
        //            MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return null;
        //        }

        //        // Gọi phương thức xuất PDF với thông tin đầy đủ
        //        return ExportContractToPdf(
        //            contractId,
        //            customerInfo.Name,
        //            customerInfo.Address,
        //            customerInfo.CCCD,
        //            customerInfo.Phone,
        //            contractInfo.Money,
        //            contractInfo.InterestRate,
        //            contractInfo.BeginDate,
        //            contractInfo.FinishDate,
        //            assetInfo.Type,
        //            assetInfo.Description,
        //            assetInfo.ImagePath
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi xuất hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}
    }
}
