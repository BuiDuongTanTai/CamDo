namespace CamDo.View
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            contextMenuTabHienThi = new ContextMenuStrip(components);
            menuItemDongTrang = new ToolStripMenuItem();
            menuItemDongTrangAll = new ToolStripMenuItem();
            MenuMain = new MenuStrip();
            hợpĐồngToolStripMenuItem = new ToolStripMenuItem();
            kháchHàngToolStripMenuItem = new ToolStripMenuItem();
            tàiSảnToolStripMenuItem = new ToolStripMenuItem();
            thốngKêToolStripMenuItem = new ToolStripMenuItem();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem1 = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            TabHienThi = new TabControl();
            thanhToánToolStripMenuItem = new ToolStripMenuItem();
            contextMenuTabHienThi.SuspendLayout();
            MenuMain.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuTabHienThi
            // 
            contextMenuTabHienThi.ImageScalingSize = new Size(20, 20);
            contextMenuTabHienThi.Items.AddRange(new ToolStripItem[] { menuItemDongTrang, menuItemDongTrangAll });
            contextMenuTabHienThi.Name = "contextMenuTabHienThi";
            contextMenuTabHienThi.Size = new Size(208, 52);
            contextMenuTabHienThi.Opening += contextMenuTabHienThi_Opening;
            // 
            // menuItemDongTrang
            // 
            menuItemDongTrang.Name = "menuItemDongTrang";
            menuItemDongTrang.Size = new Size(207, 24);
            menuItemDongTrang.Text = "Đóng trang hiện tại";
            menuItemDongTrang.Click += menuItemDongTrang_Click;
            // 
            // menuItemDongTrangAll
            // 
            menuItemDongTrangAll.Name = "menuItemDongTrangAll";
            menuItemDongTrangAll.Size = new Size(207, 24);
            menuItemDongTrangAll.Text = "Đóng tất cả";
            menuItemDongTrangAll.Click += menuItemDongTrangAll_Click;
            // 
            // MenuMain
            // 
            MenuMain.ImageScalingSize = new Size(20, 20);
            MenuMain.Items.AddRange(new ToolStripItem[] { hợpĐồngToolStripMenuItem, kháchHàngToolStripMenuItem, tàiSảnToolStripMenuItem, thanhToánToolStripMenuItem, thốngKêToolStripMenuItem, hệThốngToolStripMenuItem });
            MenuMain.Location = new Point(0, 0);
            MenuMain.Name = "MenuMain";
            MenuMain.Size = new Size(933, 28);
            MenuMain.TabIndex = 1;
            MenuMain.Text = "MenuMain";
            // 
            // hợpĐồngToolStripMenuItem
            // 
            hợpĐồngToolStripMenuItem.Name = "hợpĐồngToolStripMenuItem";
            hợpĐồngToolStripMenuItem.Size = new Size(91, 24);
            hợpĐồngToolStripMenuItem.Text = "Hợp đồng";
            hợpĐồngToolStripMenuItem.Click += hợpĐồngToolStripMenuItem_Click;
            // 
            // kháchHàngToolStripMenuItem
            // 
            kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            kháchHàngToolStripMenuItem.Size = new Size(100, 24);
            kháchHàngToolStripMenuItem.Text = "Khách hàng";
            kháchHàngToolStripMenuItem.Click += kháchHàngToolStripMenuItem_Click;
            // 
            // tàiSảnToolStripMenuItem
            // 
            tàiSảnToolStripMenuItem.Name = "tàiSảnToolStripMenuItem";
            tàiSảnToolStripMenuItem.Size = new Size(67, 24);
            tàiSảnToolStripMenuItem.Text = "Tài sản";
            tàiSảnToolStripMenuItem.Click += tàiSảnToolStripMenuItem_Click;
            // 
            // thốngKêToolStripMenuItem
            // 
            thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            thốngKêToolStripMenuItem.Size = new Size(84, 24);
            thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đổiMậtKhẩuToolStripMenuItem, đăngXuấtToolStripMenuItem1 });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(85, 24);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(181, 26);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            đổiMậtKhẩuToolStripMenuItem.Click += đổiMậtKhẩuToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem1
            // 
            đăngXuấtToolStripMenuItem1.Name = "đăngXuấtToolStripMenuItem1";
            đăngXuấtToolStripMenuItem1.Size = new Size(181, 26);
            đăngXuấtToolStripMenuItem1.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem1.Click += đăngXuấtToolStripMenuItem1_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(32, 19);
            // 
            // TabHienThi
            // 
            TabHienThi.ContextMenuStrip = contextMenuTabHienThi;
            TabHienThi.Location = new Point(0, 39);
            TabHienThi.Margin = new Padding(3, 4, 3, 4);
            TabHienThi.Name = "TabHienThi";
            TabHienThi.SelectedIndex = 0;
            TabHienThi.Size = new Size(933, 494);
            TabHienThi.TabIndex = 2;
            TabHienThi.SelectedIndexChanged += TabHienThi_SelectedIndexChanged;
            // 
            // thanhToánToolStripMenuItem
            // 
            thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            thanhToánToolStripMenuItem.Size = new Size(97, 24);
            thanhToánToolStripMenuItem.Text = "Thanh toán";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 533);
            Controls.Add(TabHienThi);
            Controls.Add(MenuMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuMain;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            Text = "Quản Lý Cầm Đồ TÀI VŨ";
            Load += frmMain_Load;
            contextMenuTabHienThi.ResumeLayout(false);
            MenuMain.ResumeLayout(false);
            MenuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuTabHienThi;
        private MenuStrip MenuMain;
        private ToolStripMenuItem trangChủToolStripMenuItem;
        private ToolStripMenuItem kháchHàngToolStripMenuItem;
        private ToolStripMenuItem tàiSảnToolStripMenuItem;
        private ToolStripMenuItem hợpĐồngToolStripMenuItem;
        private ToolStripMenuItem thốngKêToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem1;
        private TabControl TabHienThi;
        private ToolStripMenuItem menuItemDongTrang;
        private ToolStripMenuItem menuItemDongTrangAll;
        private ToolStripMenuItem thanhToánToolStripMenuItem;
    }
}