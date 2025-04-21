using System.Windows.Forms;

namespace CamDo.View
{
    partial class frmContract
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            label8 = new Label();
            label11 = new Label();
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtCCCD = new TextBox();
            txtSDT = new TextBox();
            txtMoney = new TextBox();
            dateBegin = new DateTimePicker();
            label12 = new Label();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnCancel = new Button();
            cbAsset = new ComboBox();
            dateFinish = new DateTimePicker();
            nmInteresRate = new NumericUpDown();
            ptbAssetImg = new PictureBox();
            label13 = new Label();
            btnAddImg = new Button();
            ((System.ComponentModel.ISupportInitialize)nmInteresRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbAssetImg).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(498, 67);
            label1.TabIndex = 0;
            label1.Text = "HỢP ĐỒNG CẦM ĐỒ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 115);
            label2.Name = "label2";
            label2.Size = new Size(144, 20);
            label2.TabIndex = 1;
            label2.Text = "Họ tên khách hàng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 152);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 2;
            label3.Text = "Địa chỉ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(12, 190);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 3;
            label4.Text = "CCCD:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 220);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 4;
            label5.Text = "SĐT:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(12, 253);
            label6.Name = "label6";
            label6.Size = new Size(146, 20);
            label6.TabIndex = 5;
            label6.Text = "Số tiền cầm (đồng):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(12, 289);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 6;
            label7.Text = "Lãi suất:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(14, 357);
            label9.Name = "label9";
            label9.Size = new Size(65, 20);
            label9.TabIndex = 8;
            label9.Text = "Hạn trả:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(12, 322);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 7;
            label8.Text = "Ngày cầm";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(14, 389);
            label11.Name = "label11";
            label11.Size = new Size(61, 20);
            label11.TabIndex = 9;
            label11.Text = "Tài sản:";
            // 
            // txtName
            // 
            txtName.Location = new Point(156, 112);
            txtName.Name = "txtName";
            txtName.Size = new Size(353, 27);
            txtName.TabIndex = 1;
            txtName.KeyDown += txtName_KeyDown;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(156, 149);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(353, 27);
            txtAddress.TabIndex = 2;
            txtAddress.KeyDown += txtAddress_KeyDown;
            // 
            // txtCCCD
            // 
            txtCCCD.ImeMode = ImeMode.Disable;
            txtCCCD.Location = new Point(156, 183);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(353, 27);
            txtCCCD.TabIndex = 3;
            txtCCCD.TextChanged += txtCCCD_TextChanged;
            txtCCCD.KeyDown += txtCCCD_KeyDown;
            txtCCCD.KeyPress += txtNumber_KeyPress;
            // 
            // txtSDT
            // 
            txtSDT.ImeMode = ImeMode.Disable;
            txtSDT.Location = new Point(156, 217);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(353, 27);
            txtSDT.TabIndex = 4;
            txtSDT.TextChanged += txtSDT_TextChanged;
            txtSDT.KeyDown += txtSDT_KeyDown;
            txtSDT.KeyPress += txtNumber_KeyPress;
            // 
            // txtMoney
            // 
            txtMoney.ImeMode = ImeMode.Disable;
            txtMoney.Location = new Point(156, 250);
            txtMoney.Name = "txtMoney";
            txtMoney.Size = new Size(353, 27);
            txtMoney.TabIndex = 5;
            txtMoney.TextChanged += txtMoney_TextChanged;
            txtMoney.KeyDown += txtMoney_KeyDown;
            txtMoney.KeyPress += txtNumber_KeyPress;
            // 
            // dateBegin
            // 
            dateBegin.CustomFormat = "dd/MM/yyyy";
            dateBegin.Format = DateTimePickerFormat.Custom;
            dateBegin.Location = new Point(156, 319);
            dateBegin.Name = "dateBegin";
            dateBegin.Size = new Size(353, 27);
            dateBegin.TabIndex = 7;
            dateBegin.KeyDown += dateBegin_KeyDown;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(14, 422);
            label12.Name = "label12";
            label12.Size = new Size(106, 20);
            label12.TabIndex = 10;
            label12.Text = "Mô tả chi tiết:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(156, 419);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(353, 27);
            txtDescription.TabIndex = 10;
            txtDescription.KeyDown += txtDescription_KeyDown;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(68, 504);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(131, 44);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(312, 504);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 44);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cbAsset
            // 
            cbAsset.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAsset.FormattingEnabled = true;
            cbAsset.Items.AddRange(new object[] { "Xe máy", "Xe ô tô", "Điện thoại", "Máy tính bảng", "Máy tính xách tay", "Giầy tờ", "Vàng", "Khác" });
            cbAsset.Location = new Point(156, 385);
            cbAsset.Name = "cbAsset";
            cbAsset.Size = new Size(353, 28);
            cbAsset.TabIndex = 9;
            cbAsset.KeyDown += cbAsset_KeyDown;
            // 
            // dateFinish
            // 
            dateFinish.CustomFormat = "dd/MM/yyyy";
            dateFinish.Format = DateTimePickerFormat.Custom;
            dateFinish.Location = new Point(156, 352);
            dateFinish.Name = "dateFinish";
            dateFinish.Size = new Size(353, 27);
            dateFinish.TabIndex = 8;
            dateFinish.KeyDown += dateFinish_KeyDown;
            // 
            // nmInteresRate
            // 
            nmInteresRate.DecimalPlaces = 1;
            nmInteresRate.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nmInteresRate.Location = new Point(156, 283);
            nmInteresRate.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nmInteresRate.Name = "nmInteresRate";
            nmInteresRate.Size = new Size(354, 27);
            nmInteresRate.TabIndex = 6;
            nmInteresRate.ValueChanged += nmInteresRate_ValueChanged;
            nmInteresRate.KeyDown += nmInteresRate_KeyDown;
            // 
            // ptbAssetImg
            // 
            ptbAssetImg.Location = new Point(14, 487);
            ptbAssetImg.Name = "ptbAssetImg";
            ptbAssetImg.Size = new Size(496, 258);
            ptbAssetImg.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbAssetImg.TabIndex = 12;
            ptbAssetImg.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.Location = new Point(12, 452);
            label13.Name = "label13";
            label13.Size = new Size(126, 20);
            label13.TabIndex = 11;
            label13.Text = "Hình ảnh tài sản:";
            // 
            // btnAddImg
            // 
            btnAddImg.Location = new Point(156, 452);
            btnAddImg.Name = "btnAddImg";
            btnAddImg.Size = new Size(94, 29);
            btnAddImg.TabIndex = 11;
            btnAddImg.Text = "Chọn ảnh";
            btnAddImg.UseVisualStyleBackColor = true;
            btnAddImg.Click += btnAddImg_Click;
            // 
            // frmContract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 576);
            Controls.Add(btnAddImg);
            Controls.Add(label13);
            Controls.Add(ptbAssetImg);
            Controls.Add(nmInteresRate);
            Controls.Add(cbAsset);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(dateFinish);
            Controls.Add(dateBegin);
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
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmContract";
            Text = "Tạo hợp đồng mới";
            ((System.ComponentModel.ISupportInitialize)nmInteresRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbAssetImg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label label8;
        private Label label11;
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtCCCD;
        private TextBox txtSDT;
        private TextBox txtMoney;
        private DateTimePicker dateBegin;
        private Label label12;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnCancel;
        private ComboBox cbAsset;
        private DateTimePicker dateFinish;
        private NumericUpDown nmInteresRate;
        private PictureBox ptbAssetImg;
        private Label label13;
        private Button btnAddImg;
    }
}