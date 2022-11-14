using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsRemaxWindowsApp.GUI
{
    public partial class frmAgentMain : Form
    {
        public frmAgentMain()
        {
            InitializeComponent();
        }

        private void frmAgentMain_Load(object sender, EventArgs e)
        {

        }

        private void mnuClient_Click(object sender, EventArgs e)
        {
            frmClientManage fem = new frmClientManage();
            fem.MdiParent = this;
            fem.Show();
        }

        private void mnuHouse_Click(object sender, EventArgs e)
        {
            frmHouseManage fem = new frmHouseManage();
            fem.MdiParent = this;
            fem.Show();
        }

        private void mnuCompany_Click(object sender, EventArgs e)
        {
            frmCompanyManage fem = new frmCompanyManage();
            fem.MdiParent = this;
            fem.Show();
        }

        private void mnuSearchHouse_Click(object sender, EventArgs e)
        {
            frmSearchHouse fem = new frmSearchHouse();
            fem.MdiParent = this;
            fem.Show();
        }

        private void mnuSearchAgent_Click(object sender, EventArgs e)
        {
            frmSearchAgent fem = new frmSearchAgent();
            fem.MdiParent = this;
            fem.Show();
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure to quit?";
            string title = "Application closing";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
