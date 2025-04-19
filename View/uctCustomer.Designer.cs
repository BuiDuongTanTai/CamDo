namespace CamDo.View
{
    partial class uctCustomer
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
            btnRefresh = new Button();
            label1 = new Label();
            btnSearchCCCD = new Button();
            txtSearch = new TextBox();
            btnDelete = new Button();
            btnEdit = new Button();
            dgvCustomer = new DataGridView();
            btnSearchName = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(822, 411);
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
            label1.Location = new Point(323, 389);
            label1.Name = "label1";
            label1.Size = new Size(230, 20);
            label1.TabIndex = 18;
            label1.Text = "Nhập CCCD hoặc tên khách hàng:";
            // 
            // btnSearchCCCD
            // 
            btnSearchCCCD.Location = new Point(577, 410);
            btnSearchCCCD.Name = "btnSearchCCCD";
            btnSearchCCCD.Size = new Size(94, 29);
            btnSearchCCCD.TabIndex = 4;
            btnSearchCCCD.Text = "Tìm CCCD";
            btnSearchCCCD.UseVisualStyleBackColor = true;
            btnSearchCCCD.Click += btnSearchCCCD_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(323, 412);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(248, 27);
            txtSearch.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(212, 389);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 50);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(112, 390);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 50);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // dgvCustomer
            // 
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToDeleteRows = false;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomer.BackgroundColor = SystemColors.ControlLightLight;
            dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomer.Dock = DockStyle.Top;
            dgvCustomer.GridColor = Color.OldLace;
            dgvCustomer.Location = new Point(0, 0);
            dgvCustomer.MultiSelect = false;
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.ReadOnly = true;
            dgvCustomer.RowHeadersWidth = 51;
            dgvCustomer.Size = new Size(950, 369);
            dgvCustomer.TabIndex = 8;
            // 
            // btnSearchName
            // 
            btnSearchName.Location = new Point(677, 410);
            btnSearchName.Name = "btnSearchName";
            btnSearchName.Size = new Size(94, 29);
            btnSearchName.TabIndex = 5;
            btnSearchName.Text = "Tìm tên";
            btnSearchName.UseVisualStyleBackColor = true;
            btnSearchName.Click += btnSearchName_Click;
            // 
            // uctCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvCustomer);
            Controls.Add(btnRefresh);
            Controls.Add(label1);
            Controls.Add(btnSearchName);
            Controls.Add(btnSearchCCCD);
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Name = "uctCustomer";
            Size = new Size(950, 450);
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRefresh;
        private Label label2;
        private Label label1;
        private Button btnStatus;
        private Button btnSearchCCCD;
        private TextBox txtSearch;
        private ComboBox cmbStatus;
        private Button btnDelete;
        private Button btnEdit;
        private DataGridView dgvCustomer;
        private Button btnSearchName;
    }
}
