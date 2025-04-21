using CamDo.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamDo.View
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        private void btnSearchIDHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDHD.Text))
            {
                MessageBox.Show("Vui lòng nhập ID hợp đồng để tra cứu.");
                return;
            }
            int contractId = int.Parse(txtIDHD.Text.Trim());
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

                // Tải thông tin lên form
                txtName.Text = customerInfo["HOTEN"].ToString();
                txtCCCD.Text = customerInfo["CCCD"].ToString();
                txtSDT.Text = customerInfo["SDT"].ToString();
                txtAddress.Text = customerInfo["DIACHI"].ToString();
                cbAsset.SelectedValue = assetInfo["TENTS"].ToString();
                txtDescription.Text = assetInfo["MOTA"].ToString();
                txtIDHD.Text = contractInfo["IDHD"].ToString();
                txtMoney.Text = contractInfo["SOTIEN"].ToString();
                nmInteresRate.Text = contractInfo["LAISUAT"].ToString();
                dateBegin.Text = contractInfo["NGAYVAY"].ToString();
                dateFinish.Text = contractInfo["HANTRA"].ToString();
                string HINHANH = assetInfo["HINHANH"].ToString();
                txtStatus.Text = contractInfo["TRANGTHAI"].ToString();
                int days = ((DateTime)contractInfo["HANTRA"] - (DateTime)contractInfo["NGAYVAY"]).Days;
                int months = (int)Math.Ceiling(days / 30.0);
                decimal totalInterest = Convert.ToInt64(contractInfo["SOTIEN"]) * (Convert.ToDecimal(contractInfo["LAISUAT"]) / 100) * months;
                decimal totalAmount = Convert.ToInt64(contractInfo["SOTIEN"]) + totalInterest;
                // Kiểm tra và gán đường dẫn hình ảnh
                if (!string.IsNullOrEmpty(HINHANH))
                {
                    // Có thể sử dụng PictureBox để hiển thị hình ảnh
                    try
                    {
                        ptbAssetImg.Image = Image.FromFile(HINHANH);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập ID và tra cứu hợp đồng để thanh toán.");
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn thanh toán hợp đồng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Gọi phương thức thanh toán từ Controller
                int contractId = int.Parse(txtIDHD.Text.Trim());
                // Kiểm tra trạng thái hợp đồng trước khi thanh toán
                if (txtStatus.Text == "Đã kết thúc")
                {
                    MessageBox.Show("Hợp đồng này đã được thanh toán trước đó.");
                    return;
                }
                if (txtStatus.Text == "Thanh lý")
                {
                    MessageBox.Show("Không thể thanh toán do tài sản đã bị thanh lý.");
                    return;
                }
                int paymentId = PaymentCtrl.generalid();
                int result2 = PaymentCtrl.insert(paymentId, contractId, long.Parse(txtMoney.Text), datePay.Value);
                if (result2 > 0)
                {
                    MessageBox.Show("Thanh toán thành công!");
                    this.DialogResult = DialogResult.OK;
                    PdfExporter.ExportPaymentToPdf(paymentId, contractId, txtName.Text, txtAddress.Text, txtCCCD.Text, txtSDT.Text, long.Parse(txtMoney.Text), nmInteresRate.Value, datePay.Value, dateBegin.Value, dateFinish.Value);
                    int result1 = ContractCtrl.pay(contractId);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thanh toán không thành công. Vui lòng thử lại.");
                }
            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn huỷ than toán không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
            else
                return;
        }

        private void txtIDHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ngăn không cho nhập ký tự không phải số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIDHD_TextChanged(object sender, EventArgs e)
        {
            string onlyDigits = new string(txtIDHD.Text.Where(char.IsDigit).ToArray());
            if (txtIDHD.Text != onlyDigits)
            {
                int selectionStart = txtIDHD.SelectionStart - 1;
                txtIDHD.Text = onlyDigits;
                txtIDHD.SelectionStart = Math.Max(0, selectionStart);
            }
        }

    }
}
