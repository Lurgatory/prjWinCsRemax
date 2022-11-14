using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace prjWinCsRemaxWindowsApp.GUI
{
    public partial class frmSearchHouse : Form
    {
        public frmSearchHouse()
        {
            InitializeComponent();
        }

        DataSet mySet;
        DataTable tabHouse;

        private void frmSearchHouse_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();

            OleDbConnection myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Multi-project\prjWinCsRemaxWindowsApp\prjWinCsRemaxWindowsApp\database\Remax.mdb");
            myCon.Open();

            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Houses", myCon);
            OleDbDataAdapter myadp = new OleDbDataAdapter(myCmd);
            myadp.Fill(mySet, "Houses");
            tabHouse = mySet.Tables["Houses"];
            cboHouse.DataSource = tabHouse;
            cboHouse.DisplayMember = "HouseNumber";
            cboHouse.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbAllHouse.Checked == true)
            {
                var HouseFound = from DataRow house in tabHouse.Rows
                                 select new
                                 {
                                     HouseNumber = house.Field<string>("HouseNumber"),
                                     HouseType = house.Field<string>("HouseType"),
                                     Year = house.Field<int>("HouseYear"),
                                     Address = house.Field<string>("Address")
                                 };
                if (HouseFound.Count() != 0)
                {
                    gridHouse.DataSource = HouseFound.ToList();
                }
                else
                {
                    gridHouse.DataSource = null;
                }
            }
            else if (rdbHouseNumber.Checked == true)
            {
                var HouseFound = from DataRow house in tabHouse.Rows
                                 where house.Field<string>("HouseNumber") == Convert.ToString(cboHouse.Text)
                                 select new
                                 {
                                     HouseNumber = house.Field<string>("HouseNumber"),
                                     HouseType = house.Field<string>("HouseType"),
                                     Year = house.Field<int>("HouseYear"),
                                     Address = house.Field<string>("Address")
                                 };
                if (HouseFound.Count() != 0)
                {
                    gridHouse.DataSource = HouseFound.ToList();
                }
                else
                {
                    gridHouse.DataSource = null;
                }
            }
        }

        private void rdbHouseNumber_CheckedChanged(object sender, EventArgs e)
        {
            cboHouse.Visible = true;
        }

        private void rdbAllHouse_CheckedChanged(object sender, EventArgs e)
        {
            cboHouse.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure to quit?";
            string title = "Application closing";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
            }
        }
    }
}
