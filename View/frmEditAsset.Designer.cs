namespace CamDo.View
{
    partial class frmEditAsset
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
            txtIDTS = new TextBox();
            txtCCCD = new TextBox();
            txtNameAsset = new TextBox();
            txtDescribe = new TextBox();
            ptbAssetImg = new PictureBox();
            btnImg = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)ptbAssetImg).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 0;
            label1.Text = "IdTS:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "CCCD:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 104);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 2;
            label3.Text = "Tên tài sản:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 148);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 3;
            label4.Text = "Mô tả:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 189);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 4;
            label5.Text = "Hình ảnh:";
            // 
            // txtIDTS
            // 
            txtIDTS.Enabled = false;
            txtIDTS.Location = new Point(115, 15);
            txtIDTS.Name = "txtIDTS";
            txtIDTS.Size = new Size(212, 27);
            txtIDTS.TabIndex = 5;
            // 
            // txtCCCD
            // 
            txtCCCD.Enabled = false;
            txtCCCD.Location = new Point(115, 57);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(212, 27);
            txtCCCD.TabIndex = 6;
            // 
            // txtNameAsset
            // 
            txtNameAsset.Location = new Point(115, 101);
            txtNameAsset.Name = "txtNameAsset";
            txtNameAsset.Size = new Size(212, 27);
            txtNameAsset.TabIndex = 1;
            // 
            // txtDescribe
            // 
            txtDescribe.Location = new Point(115, 145);
            txtDescribe.Name = "txtDescribe";
            txtDescribe.Size = new Size(212, 27);
            txtDescribe.TabIndex = 2;
            // 
            // ptbAssetImg
            // 
            ptbAssetImg.Location = new Point(12, 220);
            ptbAssetImg.Name = "ptbAssetImg";
            ptbAssetImg.Size = new Size(315, 153);
            ptbAssetImg.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbAssetImg.TabIndex = 9;
            ptbAssetImg.TabStop = false;
            // 
            // btnImg
            // 
            btnImg.Location = new Point(113, 185);
            btnImg.Name = "btnImg";
            btnImg.Size = new Size(94, 29);
            btnImg.TabIndex = 3;
            btnImg.Text = "Chọn ảnh";
            btnImg.UseVisualStyleBackColor = true;
            btnImg.Click += btnImg_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(40, 395);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 30);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(195, 395);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 30);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmEditAsset
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 438);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnImg);
            Controls.Add(ptbAssetImg);
            Controls.Add(txtDescribe);
            Controls.Add(txtNameAsset);
            Controls.Add(txtCCCD);
            Controls.Add(txtIDTS);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmEditAsset";
            Text = "Chỉnh sửa tài sản";
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
        private TextBox txtIDTS;
        private TextBox txtCCCD;
        private TextBox txtNameAsset;
        private TextBox txtDescribe;
        private PictureBox ptbAssetImg;
        private Button btnImg;
        private Button btnSave;
        private Button btnCancel;
    }
}