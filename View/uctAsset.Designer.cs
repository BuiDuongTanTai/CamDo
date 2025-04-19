namespace CamDo.View
{
    partial class uctAsset
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvAsset = new DataGridView();
            btnRefresh = new Button();
            label1 = new Label();
            btnSearchID = new Button();
            txtSearch = new TextBox();
            btnDelete = new Button();
            btnEdit = new Button();
            btnSearchName = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAsset).BeginInit();
            SuspendLayout();
            // 
            // dgvAsset
            // 
            dgvAsset.AllowUserToAddRows = false;
            dgvAsset.AllowUserToDeleteRows = false;
            dgvAsset.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAsset.BackgroundColor = SystemColors.ControlLightLight;
            dgvAsset.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsset.Dock = DockStyle.Top;
            dgvAsset.GridColor = Color.OldLace;
            dgvAsset.Location = new Point(0, 0);
            dgvAsset.MultiSelect = false;
            dgvAsset.Name = "dgvAsset";
            dgvAsset.ReadOnly = true;
            dgvAsset.RowHeadersWidth = 51;
            dgvAsset.Size = new Size(950, 369);
            dgvAsset.TabIndex = 10;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(825, 408);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(326, 386);
            label1.Name = "label1";
            label1.Size = new Size(181, 20);
            label1.TabIndex = 19;
            label1.Text = "Nhập idts hoặc tên tài sản";
            // 
            // btnSearchID
            // 
            btnSearchID.Location = new Point(592, 407);
            btnSearchID.Name = "btnSearchID";
            btnSearchID.Size = new Size(94, 29);
            btnSearchID.TabIndex = 4;
            btnSearchID.Text = "Tìm idts";
            btnSearchID.UseVisualStyleBackColor = true;
            btnSearchID.Click += btnSearchID_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(326, 409);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(260, 27);
            txtSearch.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(215, 386);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 50);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(115, 386);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 50);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSearchName
            // 
            btnSearchName.Location = new Point(692, 407);
            btnSearchName.Name = "btnSearchName";
            btnSearchName.Size = new Size(94, 29);
            btnSearchName.TabIndex = 5;
            btnSearchName.Text = "Tìm tên ts";
            btnSearchName.UseVisualStyleBackColor = true;
            btnSearchName.Click += btnSearchName_Click;
            // 
            // uctAsset
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRefresh);
            Controls.Add(label1);
            Controls.Add(btnSearchName);
            Controls.Add(btnSearchID);
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(dgvAsset);
            Name = "uctAsset";
            Size = new Size(950, 450);
            ((System.ComponentModel.ISupportInitialize)dgvAsset).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAsset;
        private Button btnRefresh;
        private Label label1;
        private Button btnSearchID;
        private TextBox txtSearch;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnSearchName;
    }
}
