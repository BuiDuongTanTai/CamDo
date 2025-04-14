namespace CamDo.View
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lab_title = new Label();
            label2 = new Label();
            label3 = new Label();
            btnOK = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lab_title
            // 
            resources.ApplyResources(lab_title, "lab_title");
            lab_title.Name = "lab_title";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // btnOK
            // 
            resources.ApplyResources(btnOK, "btnOK");
            btnOK.Name = "btnOK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOk_Click;
            // 
            // txtUsername
            // 
            resources.ApplyResources(txtUsername, "txtUsername");
            txtUsername.Name = "txtUsername";
            txtUsername.KeyDown += textBox_KeyDown;
            // 
            // txtPassword
            // 
            resources.ApplyResources(txtPassword, "txtPassword");
            txtPassword.Name = "txtPassword";
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtPassword.KeyDown += textBox_KeyDown;
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmLogin
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lab_title);
            Name = "frmLogin";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lab_title;
        private Label label2;
        private Label label3;
        private Button btnOK;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnCancel;
    }
}
