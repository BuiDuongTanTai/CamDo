using System.Windows.Forms;

namespace CamDo.View
{
    partial class uctContract
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
            btnCreateNewContract = new Button();
            dgvContract = new DataGridView();
            btnEdit = new Button();
            btnDelete = new Button();
            cmbStatus = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnStatus = new Button();
            label1 = new Label();
            label2 = new Label();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvContract).BeginInit();
            SuspendLayout();
            // 
            // btnCreateNewContract
            // 
            btnCreateNewContract.Location = new Point(14, 388);
            btnCreateNewContract.Name = "btnCreateNewContract";
            btnCreateNewContract.Size = new Size(94, 50);
            btnCreateNewContract.TabIndex = 1;
            btnCreateNewContract.Text = "Thêm mới";
            btnCreateNewContract.UseVisualStyleBackColor = true;
            btnCreateNewContract.Click += btnCreateNewContract_Click;
            // 
            // dgvContract
            // 
            dgvContract.AllowUserToAddRows = false;
            dgvContract.AllowUserToDeleteRows = false;
            dgvContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContract.BackgroundColor = SystemColors.ControlLightLight;
            dgvContract.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContract.Dock = DockStyle.Top;
            dgvContract.GridColor = Color.OldLace;
            dgvContract.Location = new Point(0, 0);
            dgvContract.MultiSelect = false;
            dgvContract.Name = "dgvContract";
            dgvContract.ReadOnly = true;
            dgvContract.RowHeadersWidth = 51;
            dgvContract.Size = new Size(950, 369);
            dgvContract.TabIndex = 9;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(114, 389);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 50);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(214, 388);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 50);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Đang hoạt động", "Đã kết thúc", "Quá hạn", "Thanh lý" });
            cmbStatus.Location = new Point(585, 410);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(116, 28);
            cmbStatus.TabIndex = 6;
            // 
            // txtSearch
            // 
            txtSearch.ImeMode = ImeMode.Disable;
            txtSearch.Location = new Point(325, 411);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(136, 27);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(467, 409);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnStatus
            // 
            btnStatus.Location = new Point(707, 410);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(94, 29);
            btnStatus.TabIndex = 7;
            btnStatus.Text = "Lọc";
            btnStatus.UseVisualStyleBackColor = true;
            btnStatus.Click += btnStatus_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(325, 388);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 8;
            label1.Text = "Nhập idhd:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(585, 388);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 9;
            label2.Text = "Chọn trạng thái:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(824, 410);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // uctContract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = SystemColors.Control;
            Controls.Add(btnRefresh);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnStatus);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(cmbStatus);
            Controls.Add(dgvContract);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnCreateNewContract);
            Name = "uctContract";
            Size = new Size(950, 450);
            ((System.ComponentModel.ISupportInitialize)dgvContract).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateNewContract;
        private DataGridView dgvContract;
        private Button btnEdit;
        private Button btnDelete;
        private ComboBox cmbStatus;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnStatus;
        private Label label1;
        private Label label2;
        private Button btnRefresh;
    }
}
