namespace CamDo.View
{
    partial class frmPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label13 = new Label();
            ptbAssetImg = new PictureBox();
            nmInteresRate = new NumericUpDown();
            cbAsset = new ComboBox();
            btnCancel = new Button();
            btnPay = new Button();
            dateFinish = new DateTimePicker();
            dateBegin = new DateTimePicker();
            txtDescription = new TextBox();
            txtMoney = new TextBox();
            txtSDT = new TextBox();
            txtCCCD = new TextBox();
            txtAddress = new TextBox();
            txtName = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label8 = new Label();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label10 = new Label();
            label14 = new Label();
            label1 = new Label();
            txtIDHD = new TextBox();
            btnSearchIDHD = new Button();
            label2 = new Label();
            txtStatus = new TextBox();
            label15 = new Label();
            datePay = new DateTimePicker();
            label16 = new Label();
            label17 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            txtTotalInterest = new TextBox();
            txtTotalAmount = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ptbAssetImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmInteresRate).BeginInit();
            SuspendLayout();
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.Location = new Point(12, 629);
            label13.Name = "label13";
            label13.Size = new Size(126, 20);
            label13.TabIndex = 34;
            label13.Text = "Hình ảnh tài sản:";
            // 
            // ptbAssetImg
            // 
            ptbAssetImg.Location = new Point(14, 664);
            ptbAssetImg.Name = "ptbAssetImg";
            ptbAssetImg.Size = new Size(496, 258);
            ptbAssetImg.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbAssetImg.TabIndex = 38;
            ptbAssetImg.TabStop = false;
            // 
            // nmInteresRate
            // 
            nmInteresRate.DecimalPlaces = 1;
            nmInteresRate.Enabled = false;
            nmInteresRate.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nmInteresRate.Location = new Point(156, 389);
            nmInteresRate.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nmInteresRate.Name = "nmInteresRate";
            nmInteresRate.Size = new Size(354, 27);
            nmInteresRate.TabIndex = 7;
            // 
            // cbAsset
            // 
            cbAsset.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAsset.Enabled = false;
            cbAsset.FormattingEnabled = true;
            cbAsset.Items.AddRange(new object[] { "Xe máy", "Xe ô tô", "Điện thoại", "Máy tính bảng", "Máy tính xách tay", "Giầy tờ", "Vàng", "Khác" });
            cbAsset.Location = new Point(156, 562);
            cbAsset.Name = "cbAsset";
            cbAsset.Size = new Size(353, 28);
            cbAsset.TabIndex = 10;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(316, 938);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 44);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnPay
            // 
            btnPay.Location = new Point(70, 938);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(131, 44);
            btnPay.TabIndex = 3;
            btnPay.Text = "Thanh toán";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // dateFinish
            // 
            dateFinish.CustomFormat = "dd/MM/yyyy";
            dateFinish.Enabled = false;
            dateFinish.Format = DateTimePickerFormat.Custom;
            dateFinish.Location = new Point(156, 458);
            dateFinish.Name = "dateFinish";
            dateFinish.Size = new Size(353, 27);
            dateFinish.TabIndex = 9;
            // 
            // dateBegin
            // 
            dateBegin.CustomFormat = "dd/MM/yyyy";
            dateBegin.Enabled = false;
            dateBegin.Format = DateTimePickerFormat.Custom;
            dateBegin.Location = new Point(156, 425);
            dateBegin.Name = "dateBegin";
            dateBegin.Size = new Size(353, 27);
            dateBegin.TabIndex = 8;
            // 
            // txtDescription
            // 
            txtDescription.Enabled = false;
            txtDescription.Location = new Point(156, 596);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(353, 27);
            txtDescription.TabIndex = 33;
            // 
            // txtMoney
            // 
            txtMoney.Enabled = false;
            txtMoney.Location = new Point(156, 358);
            txtMoney.Name = "txtMoney";
            txtMoney.Size = new Size(353, 27);
            txtMoney.TabIndex = 6;
            // 
            // txtSDT
            // 
            txtSDT.Enabled = false;
            txtSDT.Location = new Point(156, 323);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(353, 27);
            txtSDT.TabIndex = 5;
            // 
            // txtCCCD
            // 
            txtCCCD.Enabled = false;
            txtCCCD.Location = new Point(156, 289);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(353, 27);
            txtCCCD.TabIndex = 4;
            // 
            // txtAddress
            // 
            txtAddress.Enabled = false;
            txtAddress.Location = new Point(156, 255);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(353, 27);
            txtAddress.TabIndex = 12;
            // 
            // txtName
            // 
            txtName.Enabled = false;
            txtName.Location = new Point(156, 218);
            txtName.Name = "txtName";
            txtName.Size = new Size(353, 27);
            txtName.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(14, 566);
            label11.Name = "label11";
            label11.Size = new Size(61, 20);
            label11.TabIndex = 31;
            label11.Text = "Tài sản:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(14, 599);
            label12.Name = "label12";
            label12.Size = new Size(106, 20);
            label12.TabIndex = 32;
            label12.Text = "Mô tả chi tiết:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(12, 428);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 27;
            label8.Text = "Ngày cầm";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(14, 463);
            label9.Name = "label9";
            label9.Size = new Size(65, 20);
            label9.TabIndex = 29;
            label9.Text = "Hạn trả:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(12, 395);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 25;
            label7.Text = "Lãi suất:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(12, 359);
            label6.Name = "label6";
            label6.Size = new Size(146, 20);
            label6.TabIndex = 23;
            label6.Text = "Số tiền cầm (đồng):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 326);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 20;
            label5.Text = "SĐT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(12, 296);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 18;
            label4.Text = "CCCD:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 258);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 16;
            label3.Text = "Địa chỉ:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(12, 221);
            label10.Name = "label10";
            label10.Size = new Size(144, 20);
            label10.TabIndex = 15;
            label10.Text = "Họ tên khách hàng:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 30F);
            label14.Location = new Point(95, 9);
            label14.Name = "label14";
            label14.RightToLeft = RightToLeft.No;
            label14.Size = new Size(340, 67);
            label14.TabIndex = 13;
            label14.Text = "THANH TOÁN";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 104);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 39;
            label1.Text = "MÃ HỢP ĐỒNG";
            // 
            // txtIDHD
            // 
            txtIDHD.Font = new Font("Segoe UI", 12F);
            txtIDHD.ImeMode = ImeMode.Disable;
            txtIDHD.Location = new Point(156, 94);
            txtIDHD.Name = "txtIDHD";
            txtIDHD.Size = new Size(254, 34);
            txtIDHD.TabIndex = 1;
            txtIDHD.TextChanged += txtIDHD_TextChanged;
            txtIDHD.KeyPress += txtIDHD_KeyPress;
            // 
            // btnSearchIDHD
            // 
            btnSearchIDHD.Location = new Point(416, 95);
            btnSearchIDHD.Name = "btnSearchIDHD";
            btnSearchIDHD.Size = new Size(94, 29);
            btnSearchIDHD.TabIndex = 2;
            btnSearchIDHD.Text = "Tra cứu";
            btnSearchIDHD.UseVisualStyleBackColor = true;
            btnSearchIDHD.Click += btnSearchIDHD_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(14, 188);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 39;
            label2.Text = "Trạng thái:";
            // 
            // txtStatus
            // 
            txtStatus.Enabled = false;
            txtStatus.Font = new Font("Segoe UI", 9F);
            txtStatus.Location = new Point(156, 185);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(353, 27);
            txtStatus.TabIndex = 1;
            txtStatus.KeyPress += txtIDHD_KeyPress;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label15.Location = new Point(12, 145);
            label15.Name = "label15";
            label15.Size = new Size(131, 20);
            label15.TabIndex = 39;
            label15.Text = "Ngày thanh toán:";
            // 
            // datePay
            // 
            datePay.Location = new Point(156, 140);
            datePay.Name = "datePay";
            datePay.Size = new Size(354, 27);
            datePay.TabIndex = 40;
            datePay.Value = new DateTime(2025, 4, 21, 9, 49, 38, 0);
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label16.Location = new Point(14, 499);
            label16.Name = "label16";
            label16.Size = new Size(63, 20);
            label16.TabIndex = 41;
            label16.Text = "Tiền lãi:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label17.Location = new Point(12, 528);
            label17.Name = "label17";
            label17.Size = new Size(138, 20);
            label17.TabIndex = 42;
            label17.Text = "Tổng tiền phải trả:";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(156, 496);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(353, 27);
            textBox1.TabIndex = 33;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(156, 529);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(353, 27);
            textBox2.TabIndex = 33;
            // 
            // txtTotalInterest
            // 
            txtTotalInterest.Enabled = false;
            txtTotalInterest.Location = new Point(156, 495);
            txtTotalInterest.Name = "txtTotalInterest";
            txtTotalInterest.Size = new Size(353, 27);
            txtTotalInterest.TabIndex = 33;
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Enabled = false;
            txtTotalAmount.Location = new Point(156, 528);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.Size = new Size(353, 27);
            txtTotalAmount.TabIndex = 33;
            // 
            // frmPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 992);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(datePay);
            Controls.Add(btnSearchIDHD);
            Controls.Add(txtStatus);
            Controls.Add(label2);
            Controls.Add(txtIDHD);
            Controls.Add(label15);
            Controls.Add(label1);
            Controls.Add(label13);
            Controls.Add(ptbAssetImg);
            Controls.Add(nmInteresRate);
            Controls.Add(cbAsset);
            Controls.Add(btnCancel);
            Controls.Add(btnPay);
            Controls.Add(dateFinish);
            Controls.Add(dateBegin);
            Controls.Add(txtTotalAmount);
            Controls.Add(txtTotalInterest);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(txtDescription);
            Controls.Add(txtMoney);
            Controls.Add(txtSDT);
            Controls.Add(txtCCCD);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label10);
            Controls.Add(label14);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPayment";
            Text = "Thanh toán";
            ((System.ComponentModel.ISupportInitialize)ptbAssetImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmInteresRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label13;
        private PictureBox ptbAssetImg;
        private NumericUpDown nmInteresRate;
        private ComboBox cbAsset;
        private Button btnCancel;
        private Button btnPay;
        private DateTimePicker dateFinish;
        private DateTimePicker dateBegin;
        private TextBox txtDescription;
        private TextBox txtMoney;
        private TextBox txtSDT;
        private TextBox txtCCCD;
        private TextBox txtAddress;
        private TextBox txtName;
        private Label label11;
        private Label label12;
        private Label label8;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label10;
        private Label label14;
        private Label label1;
        private TextBox txtIDHD;
        private Button btnSearchIDHD;
        private Label label2;
        private TextBox txtStatus;
        private Label label15;
        private DateTimePicker datePay;
        private Label label16;
        private Label label17;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox txtTotalInterest;
        private TextBox txtTotalAmount;
    }
}