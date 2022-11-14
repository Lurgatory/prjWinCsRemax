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
    public partial class frmSearchAgent : Form
    {
        public frmSearchAgent()
        {
            InitializeComponent();
        }
        DataSet mySet;
        DataTable tabAgent;
        private void frmSearchAgent_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            OleDbConnection myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Multi-project\prjWinCsRemaxWindowsApp\prjWinCsRemaxWindowsApp\database\Remax.mdb");
            myCon.Open();

            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Employees WHERE EmpPosition = 'Agent'", myCon);
            OleDbDataAdapter mydpt = new OleDbDataAdapter(myCmd);
            mydpt.Fill(mySet, "Employees");
            tabAgent = mySet.Tables["Employees"];
            cboAgent.DataSource = tabAgent;
            cboAgent.DisplayMember = "EmpNumber";
            cboAgent.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (rdbAllAgent.Checked == true)
            {
                var HouseFound = from DataRow house in tabAgent.Rows
                                 select new
                                 {
                                     AgentNumber = house.Field<string>("EmpNumber"),
                                     AgentName = house.Field<string>("EmployeeName"),
                                     BirthDate = house.Field<DateTime>("BirthDate"),
                                     Password = house.Field<string>("EmpPassword")
                                 };
                if (HouseFound.Count() != 0)
                {
                    gridAgent.DataSource = HouseFound.ToList();
                }
                else
                {
                    gridAgent.DataSource = null;
                }
            }
            else if (rdbAgentNumber.Checked == true)
            {
                
                var HouseFound = from DataRow house in tabAgent.Rows
                                 where house.Field<string>("EmpNumber") == Convert.ToString(cboAgent.Text)
                                 select new
                                 {
                                     AgentNumber = house.Field<string>("EmpNumber"),
                                     AgentName = house.Field<string>("EmployeeName"),
                                     BirthDate = house.Field<DateTime>("BirthDate"),
                                     Password = house.Field<string>("EmpPassword")
                                 };
                if (HouseFound.Count() != 0)
                {
                    gridAgent.DataSource = HouseFound.ToList();
                }
                else
                {
                    gridAgent.DataSource = null;
                }
            }
        }

        private void rdbAgentNumber_CheckedChanged(object sender, EventArgs e)
        {
            cboAgent.Visible = true;
        }

        private void rdbAllAgent_CheckedChanged(object sender, EventArgs e)
        {
            cboAgent.Visible = false;
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
