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
    public partial class frmCompanyManage : Form
    {
        public frmCompanyManage()
        {
            InitializeComponent();
        }
        DataSet mySet;
        OleDbConnection myCon;
        DataTable tabComp;
        OleDbDataAdapter comAdp;
        int currentposition;
        string mode;


        private void frmCompanyManage_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Multi-project\prjWinCsRemaxWindowsApp\prjWinCsRemaxWindowsApp\database\Remax.mdb");
            myCon.Open();
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Companies", myCon);
            comAdp = new OleDbDataAdapter(myCmd);
            comAdp.Fill(mySet, "Companies");
            tabComp = mySet.Tables["Companies"];
            currentposition = 0;
            Display();
        }

        private void Display()
        {
            txtName.Text = tabComp.Rows[currentposition]["CompanyName"].ToString();
            txtNumber.Text = tabComp.Rows[currentposition]["CompanyNumber"].ToString();
            lblWarning.Text = "Company " + (currentposition + 1) + " on a total of " + (tabComp.Rows.Count);

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            Display();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentposition = tabComp.Rows.Count - 1;
            Display();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentposition -= 1;
            if (currentposition < 0)
            {
                currentposition = 0;
                Display();
            }
            else
            {
                Display();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentposition += 1;
            if (currentposition > tabComp.Rows.Count - 1)
            {
                currentposition = tabComp.Rows.Count - 1;
                Display();
            }
            else
            {
                Display();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtNumber.Text = txtName.Text = "";
            txtNumber.Focus();
            lblWarning.Text = "----Add Mode----";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtNumber.Focus();
            lblWarning.Text = "----Edit Mode----";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string num = txtNumber.Text;
            string name = txtName.Text;

            DataRow myrow = (mode == "Add") ? tabComp.NewRow() : tabComp.Rows[currentposition];
            myrow["CompanyNumber"] = num;
            myrow["CompanyName"] = name;

            if (mode == "add")
            {
                tabComp.Rows.Add(myrow);
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(comAdp);
                comAdp.Update(mySet, "Companies");
                mySet.Tables.Remove("Companies");
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Companies", myCon);
                comAdp = new OleDbDataAdapter(myCmd);
                comAdp.Fill(mySet, "Companies");
                tabComp = mySet.Tables["Companies"];

                currentposition = tabComp.Rows.Count - 1;
            }
            else if(mode == "Edit")
            {
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(comAdp);
                comAdp.Update(mySet, "Companies");
                mySet.Tables.Remove("Companies");
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Companies", myCon);
                comAdp = new OleDbDataAdapter(myCmd);
                comAdp.Fill(mySet, "Companies");
                tabComp = mySet.Tables["Companies"];
            }
            Display();
            mode = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure to want to delete this employee?";
            string title = "Warning : Employee Deletion";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabComp.Rows[currentposition].Delete();
                // Now we need to update ( or synchronize) the contents of dataset --> the database
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(comAdp);
                comAdp.Update(mySet, "Companies");
                // Update the data of the datebase --> the dataset at same time
                mySet.Tables.Remove("Companies");
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Companies", myCon);
                comAdp = new OleDbDataAdapter(myCmd);
                comAdp.Fill(mySet, "Companies");
                tabComp = mySet.Tables["Companies"];

                currentposition = 0;
                Display();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
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
