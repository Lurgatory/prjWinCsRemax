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
    public partial class frmBuyerMain : Form
    {
        public frmBuyerMain()
        {
            InitializeComponent();
        }

        private void mnuSearchHouse_Click(object sender, EventArgs e)
        {
            frmSearchHouse fsh = new frmSearchHouse();
            fsh.MdiParent = this;
            fsh.Show();
        }

        private void mnuSearchAgent_Click(object sender, EventArgs e)
        {
            frmSearchAgent fsa = new frmSearchAgent();
            fsa.MdiParent = this;
            fsa.Show();
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
