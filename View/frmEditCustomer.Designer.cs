namespace CamDo.View
{
    partial class frmEditCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditCustomer));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtCCCD = new TextBox();
            txtName = new TextBox();
            txtSDT = new TextBox();
            txtAddress = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 15);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "CCCD:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 58);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 1;
            label2.Text = "Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 106);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "SĐT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 149);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ:";
            // 
            // txtCCCD
            // 
            txtCCCD.Enabled = false;
            txtCCCD.Location = new Point(113, 12);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(206, 27);
            txtCCCD.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(113, 55);
            txtName.Name = "txtName";
            txtName.Size = new Size(206, 27);
            txtName.TabIndex = 2;
            // 
            // txtSDT
            // 
            txtSDT.ImeMode = ImeMode.Disable;
            txtSDT.Location = new Point(113, 103);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(206, 27);
            txtSDT.TabIndex = 3;
            txtSDT.TextChanged += txtSDT_TextChanged;
            txtSDT.KeyPress += txtSDT_KeyPress;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(113, 146);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(206, 27);
            txtAddress.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(47, 201);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(194, 201);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmEditCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 251);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(txtSDT);
            Controls.Add(txtName);
            Controls.Add(txtCCCD);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditCustomer";
            Text = "Chỉnh sửa khách hàng";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtCCCD;
        private TextBox txtName;
        private TextBox txtSDT;
        private TextBox txtAddress;
        private Button btnSave;
        private Button btnCancel;
    }
}