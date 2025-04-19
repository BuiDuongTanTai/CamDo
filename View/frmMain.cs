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

        private void contextMenuTabHienThi_Opening(object sender, CancelEventArgs e)
        {

        }
        private void đổiMậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void TabHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
