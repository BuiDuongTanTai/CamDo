using System;
using System.Windows.Forms;

namespace CamDo.View
{
    public partial class frmEditContract : Form
    {
        protected int IDHD { get; set; }
        protected int IDTS { get; set; }
        protected long Money { get; set; }
        protected decimal InterestRate { get; set; }
        protected DateTime DateBegin { get; set; }
        protected DateTime DateFinish { get; set; }
        protected string TrangThai { get; set; } // Nếu có cột trạng thái

        public frmEditContract(int idHD, int idTS, long money, decimal interestRate, DateTime dateBegin, DateTime dateFinish, string trangThai)
        {
            InitializeComponent();
            IDHD = idHD;
            IDTS = idTS;
            Money = money;
            InterestRate = interestRate;
            DateBegin = dateBegin;
            DateFinish = dateFinish;
            TrangThai = trangThai; // Gán giá trị trạng thái
            this.Load += frmEditContract_Load;
        }

        private void frmEditContract_Load(object sender, EventArgs e)
        {
            txtIDHD.Text = IDHD.ToString();
            txtIDTS.Text = IDTS.ToString();
            txtMoney.Text = Money.ToString();
            nmInteresRate.Value = InterestRate;
            dateBegin.Value = DateBegin;
            dateFinish.Value = DateFinish;
            txtStatus.Text = TrangThai;
        }

        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ngăn không cho nhập ký tự không phải số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Làm tròn giá trị lãi suất
            if (nmInteresRate.Value % 0.1m != 0)
            {
                nmInteresRate.Value = Math.Round(nmInteresRate.Value, 1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMoney.Text))
            {
                MessageBox.Show("Hãy nhập số tiền");
                return;
            }
            if (nmInteresRate.Value == 0)
            {
                MessageBox.Show("Hãy thêm lãi suất");
                return;
            }
            if (dateFinish.Value <= dateBegin.Value.AddMonths(1))
            {
                MessageBox.Show("Hạn trả phải sau ngày cầm ít nhất 1 tháng.");
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn lưu chỉnh sửa hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Chuyển đổi dữ liệu và xử lý lỗi
                if (long.TryParse(txtMoney.Text, out long money) &&
                    decimal.TryParse(nmInteresRate.Value.ToString(), out decimal interestRate))
                {
                    DateTime dateBe = dateBegin.Value;
                    DateTime dateFi = dateFinish.Value;

                    // Gọi phương thức cập nhật
                    int result = Controllers.ContractCtrl.update(IDHD, IDTS, money, interestRate, dateBe, dateFi, TrangThai);

                    // Kiểm tra kết quả cập nhật
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        this.DialogResult = DialogResult.OK;
                        Controllers.PdfExporter.ExportContractToPdf(IDHD);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công. Vui lòng thử lại.");
                    }
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