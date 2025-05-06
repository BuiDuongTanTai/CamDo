namespace CamDo.View
{
    partial class frmConfig
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
            checkBox1 = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            textBoxServer = new TextBox();
            textBoxDB = new TextBox();
            textBoxUsername = new TextBox();
            textBoxPass = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 36);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên server";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 81);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên database";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 122);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 164);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 3;
            label4.Text = "Password";
            // 
            // checkBox1
            // 
            checkBox1.Location = new Point(109, 202);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(169, 24);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Windows Authentification";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(15, 234);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += save;
            button1.KeyDown += enterPressed;
            // 
            // button2
            // 
            button2.Location = new Point(248, 234);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += cancel;
            button2.KeyDown += cancelEnterPressed;
            // 
            // textBoxServer
            // 
            textBoxServer.Location = new Point(109, 33);
            textBoxServer.Name = "textBoxServer";
            textBoxServer.Size = new Size(214, 23);
            textBoxServer.TabIndex = 0;
            textBoxServer.KeyDown += enterPressed;
            // 
            // textBoxDB
            // 
            textBoxDB.Location = new Point(109, 78);
            textBoxDB.Name = "textBoxDB";
            textBoxDB.Size = new Size(214, 23);
            textBoxDB.TabIndex = 1;
            textBoxDB.KeyDown += enterPressed;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(109, 119);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(214, 23);
            textBoxUsername.TabIndex = 2;
            textBoxUsername.KeyDown += enterPressed;
            // 
            // textBoxPass
            // 
            textBoxPass.Location = new Point(109, 161);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.Size = new Size(214, 23);
            textBoxPass.TabIndex = 3;
            textBoxPass.KeyDown += enterPressed;
            // 
            // frmConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 293);
            Controls.Add(textBoxPass);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxDB);
            Controls.Add(textBoxServer);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmConfig";
            Text = "Configuration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox checkBox1;
        private Button button1;
        private Button button2;
        private TextBox textBoxServer;
        private TextBox textBoxDB;
        private TextBox textBoxUsername;
        private TextBox textBoxPass;
    }
}