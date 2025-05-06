namespace CamDo.View
{
    partial class frmEditContract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditContract));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            txtMoney = new TextBox();
            nmInteresRate = new NumericUpDown();
            dateFinish = new DateTimePicker();
            dateBegin = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            txtIDHD = new TextBox();
            txtIDTS = new TextBox();
            label7 = new Label();
            txtStatus = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nmInteresRate).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 112);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 0;
            label1.Text = "Số tiền (Đồng):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 156);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "Lãi suất:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 201);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Ngày vay:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 248);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 3;
            label4.Text = "Hạn trả:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(222, 339);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(60, 339);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtMoney
            // 
            txtMoney.ImeMode = ImeMode.Disable;
            txtMoney.Location = new Point(126, 109);
            txtMoney.Name = "txtMoney";
            txtMoney.Size = new Size(250, 27);
            txtMoney.TabIndex = 1;
            txtMoney.TextChanged += txtMoney_TextChanged;
            txtMoney.KeyPress += txtMoney_KeyPress;
            // 
            // nmInteresRate
            // 
            nmInteresRate.DecimalPlaces = 1;
            nmInteresRate.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nmInteresRate.Location = new Point(126, 156);
            nmInteresRate.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nmInteresRate.Name = "nmInteresRate";
            nmInteresRate.Size = new Size(250, 27);
            nmInteresRate.TabIndex = 2;
            nmInteresRate.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // dateFinish
            // 
            dateFinish.Location = new Point(126, 248);
            dateFinish.Name = "dateFinish";
            dateFinish.Size = new Size(250, 27);
            dateFinish.TabIndex = 4;
            // 
            // dateBegin
            // 
            dateBegin.Location = new Point(126, 201);
            dateBegin.Name = "dateBegin";
            dateBegin.Size = new Size(250, 27);
            dateBegin.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 19);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 7;
            label5.Text = "IdHĐ:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 65);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 8;
            label6.Text = "IdTS:";
            // 
            // txtIDHD
            // 
            txtIDHD.Enabled = false;
            txtIDHD.Location = new Point(126, 16);
            txtIDHD.Name = "txtIDHD";
            txtIDHD.Size = new Size(250, 27);
            txtIDHD.TabIndex = 9;
            // 
            // txtIDTS
            // 
            txtIDTS.Enabled = false;
            txtIDTS.Location = new Point(126, 62);
            txtIDTS.Name = "txtIDTS";
            txtIDTS.Size = new Size(250, 27);
            txtIDTS.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 294);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 11;
            label7.Text = "Trạng thái:";
            // 
            // txtStatus
            // 
            txtStatus.Enabled = false;
            txtStatus.Location = new Point(126, 291);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(250, 27);
            txtStatus.TabIndex = 12;
            // 
            // frmEditContract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 381);
            Controls.Add(txtStatus);
            Controls.Add(label7);
            Controls.Add(txtIDTS);
            Controls.Add(txtIDHD);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dateBegin);
            Controls.Add(dateFinish);
            Controls.Add(nmInteresRate);
            Controls.Add(txtMoney);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditContract";
            Text = "Chỉnh sửa hợp đồng";
            ((System.ComponentModel.ISupportInitialize)nmInteresRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCancel;
        private Button btnSave;
        private TextBox txtMoney;
        private NumericUpDown nmInteresRate;
        private DateTimePicker dateFinish;
        private DateTimePicker dateBegin;
        private Label label5;
        private Label label6;
        private TextBox txtIDHD;
        private TextBox txtIDTS;
        private Label label7;
        private TextBox txtStatus;
    }
}