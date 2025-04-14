namespace CamDo.View
{
    partial class frmUpdateUserlogin
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
            txtPasswordOld = new TextBox();
            txtPassword = new TextBox();
            txtRepassword = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(206, 35);
            label1.TabIndex = 0;
            label1.Text = "Mật khẩu hiện tại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(12, 122);
            label2.Name = "label2";
            label2.Size = new Size(168, 35);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(12, 223);
            label3.Name = "label3";
            label3.Size = new Size(268, 35);
            label3.TabIndex = 2;
            label3.Text = "Nhập lại mật khẩu mới";
            // 
            // txtPasswordOld
            // 
            txtPasswordOld.Font = new Font("Segoe UI", 15F);
            txtPasswordOld.Location = new Point(12, 69);
            txtPasswordOld.Name = "txtPasswordOld";
            txtPasswordOld.Size = new Size(307, 41);
            txtPasswordOld.TabIndex = 1;
            this.txtPasswordOld.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 15F);
            txtPassword.Location = new Point(12, 160);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(307, 41);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtRepassword
            // 
            txtRepassword.Font = new Font("Segoe UI", 15F);
            txtRepassword.Location = new Point(12, 261);
            txtRepassword.Name = "txtRepassword";
            txtRepassword.Size = new Size(307, 41);
            txtRepassword.TabIndex = 3;
            txtRepassword.UseSystemPasswordChar = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(26, 325);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(99, 45);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(205, 325);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 45);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmUpdateUserlogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 382);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtRepassword);
            Controls.Add(txtPassword);
            Controls.Add(txtPasswordOld);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmUpdateUserlogin";
            Text = "Đổi mật khẩu";
            Load += frmUpdateUserlogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPasswordOld;
        private TextBox txtPassword;
        private TextBox txtRepassword;
        private Button btnOk;
        private Button btnCancel;
    }
}