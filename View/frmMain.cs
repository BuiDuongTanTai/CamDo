using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamDo.View
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        internal static List<byte> typePages = new List<byte>();
        public void ThemTabPages(UserControl uct, byte typeControl, string tenTab)
        {
            // Kiểm tra tồn tại trang này chưa
            for (int i = 0; i < TabHienThi.TabPages.Count; i++)
            {
                if (TabHienThi.TabPages[i].Contains(uct) == true)
                {
                    TabHienThi.SelectedTab = TabHienThi.TabPages[i];
                    return;
                }
            }
            TabPage tab = new TabPage();
            typePages.Add(typeControl);
            tab.Name = uct.Name;
            tab.Size = TabHienThi.Size;
            tab.Text = tenTab;
            TabHienThi.TabPages.Add(tab);
            TabHienThi.SelectedTab = tab;
            uct.Dock = DockStyle.Fill;
            tab.Controls.Add(uct);
            uct.Focus();

        }

        public void DongTabHienTai()
        {
            TabHienThi.TabPages.Remove(TabHienThi.SelectedTab);
        }
        public void DongAllTab()
        {
            while (TabHienThi.TabPages.Count > 0)
            {
                DongTabHienTai();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadNotificationsToMenu();
            hợpĐồngToolStripMenuItem_Click(sender, e);
        }

        private void menuItemDongTrang_Click(object sender, EventArgs e)
        {
            DongTabHienTai();
        }

        private void menuItemDongTrangAll_Click(object sender, EventArgs e)
        {
            DongAllTab();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateUserlogin frm = new frmUpdateUserlogin();
            frm.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Restart();
                //Application.Exit();
            }
            else
                return;
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(uctContract.uctCo, 4, "Hợp đồng");
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(uctCustomer.uctCu, 4, "Khách hàng");
        }

        private void tàiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(uctAsset.uctAs, 4, "Tài sản");
        }

        private DataTable updateStatusAuto()
        {
            return Controllers.ContractCtrl.updateStatusAuto();
        }

        private void LoadNotificationsToMenu()
        {
            // Xóa thông báo cũ nếu có
            thôngBáoToolStripMenuItem.DropDownItems.Clear();


            DataRowCollection rows = updateStatusAuto().Rows;
            int count = rows.Count;

            if (count > 0)
            {
                //Đổi màu mục thông báo khi có thông báo
                thôngBáoToolStripMenuItem.ForeColor = Color.Red;
                thôngBáoToolStripMenuItem.Font = new Font(thôngBáoToolStripMenuItem.Font, FontStyle.Bold);
                thôngBáoToolStripMenuItem.Text = $"Thông báo ({count})"; // Cập nhật số lượng thông báo

                // Tạo thông báo cho mỗi hợp đồng quá hạn
                foreach (DataRow row in rows)
                {
                    // Lấy thông tin từ DataRow
                    string contractName = row["IDHD"].ToString();
                    DateTime dueDate = Convert.ToDateTime(row["HANTRA"]);
                    // Tạo thông báo dạng ToolStripMenuItem
                    ToolStripMenuItem notificationItem = new ToolStripMenuItem();
                    notificationItem.Text = $"Hợp đồng {contractName} đã quá hạn vào ngày {dueDate:dd/MM/yyyy}";
                    notificationItem.ForeColor = Color.Red;
                    notificationItem.Font = new Font(thôngBáoToolStripMenuItem.Font, FontStyle.Bold);

                    // Tùy chỉnh thêm hành động khi nhấp vào thông báo
                    notificationItem.Click += (s, e) =>
                    {
                        ToolStripMenuItem item = s as ToolStripMenuItem;

                        if (item != null && item.Tag?.ToString() != "read")
                        {
                            item.ForeColor = Color.Black;
                            item.Font = new Font(thôngBáoToolStripMenuItem.Font, FontStyle.Regular);
                            item.Tag = "read";

                            // Đếm lại số thông báo chưa đọc
                            int unreadCount = thôngBáoToolStripMenuItem.DropDownItems
                                .OfType<ToolStripMenuItem>()
                                .Count(i => i.Tag?.ToString() != "read");

                            // Cập nhật text menu
                            thôngBáoToolStripMenuItem.Text = $"Thông báo ({unreadCount})";

                            // Nếu không còn thông báo chưa đọc, có thể đổi màu lại
                            if (unreadCount == 0)
                            {
                                thôngBáoToolStripMenuItem.ForeColor = Color.Black;
                                thôngBáoToolStripMenuItem.Font = new Font(thôngBáoToolStripMenuItem.Font, FontStyle.Regular);
                            }
                        }
                    };

                    // Thêm vào MenuStrip
                    thôngBáoToolStripMenuItem.DropDownItems.Add(notificationItem);
                }
            }
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPay frm = new frmPay();
            frm.ShowDialog();
        }
    }
}
