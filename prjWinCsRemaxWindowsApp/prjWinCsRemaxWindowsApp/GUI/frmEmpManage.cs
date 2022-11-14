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
    public partial class frmEmpManage : Form
    {
        public frmEmpManage()
        {
            InitializeComponent();
        }
        DataSet mySet;
        OleDbConnection myCon;
        DataTable tabEmployees;
        OleDbDataAdapter myAdp;
        int currentposition;
        string mode;


        private void frmAdminManage_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Multi-project\prjWinCsRemaxWindowsApp\prjWinCsRemaxWindowsApp\database\Remax.mdb");
            myCon.Open();
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Employees", myCon);
            myAdp = new OleDbDataAdapter(myCmd);
            myAdp.Fill(mySet, "Employees");
            tabEmployees = mySet.Tables["Employees"];
            currentposition = 0;
            Display();
        }

        private void Display()
        {
            txtNumber.Text = tabEmployees.Rows[currentposition]["EmpNumber"].ToString();
            txtName.Text = tabEmployees.Rows[currentposition]["EmployeeName"].ToString();
            txtPassword.Text = tabEmployees.Rows[currentposition]["EmpPassword"].ToString();
            dtpBirthDate.Value = Convert.ToDateTime(tabEmployees.Rows[currentposition]["BirthDate"]);
            cbxPosition.Text = tabEmployees.Rows[currentposition]["EmpPosition"].ToString();
            lblWarning.Text = "Employee " + (currentposition + 1) + " on a total of " + (tabEmployees.Rows.Count);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            Display();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentposition = tabEmployees.Rows.Count - 1;
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
            if (currentposition > tabEmployees.Rows.Count - 1)
            {
                currentposition = tabEmployees.Rows.Count - 1;
                Display();
            }
            else
            {
                Display();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "Add";
            txtName.Text= txtNumber.Text = txtPassword.Text = "";
            dtpBirthDate.Value = DateTime.Now;
            cbxPosition.Text = "Select a position";
            txtName.Focus();
            lblWarning.Text = "----Add Mode---";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "Edit";
            txtName.Focus();
            lblWarning.Text = "----Edit Mode---";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure to want to delete this employee?";
            string title = "Warning : Employee Deletion";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    tabEmployees.Rows[currentposition].Delete();
                    // Now we need to update ( or synchronize) the contents of dataset --> the database
                    OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myAdp);
                    myAdp.Update(mySet, "Employees");
                    // Update the data of the datebase --> the dataset at same time
                    mySet.Tables.Remove("Employees");
                    OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Employees", myCon);
                    myAdp = new OleDbDataAdapter(myCmd);
                    myAdp.Fill(mySet, "Employees");
                    tabEmployees = mySet.Tables["Employees"];

                    currentposition = 0;
                    Display();
                }
                catch
                {
                    MessageBox.Show("Please delete all clients related to this employee at first", "Your program has an error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            DateTime dbate = dtpBirthDate.Value;
            string empnum = txtNumber.Text;
            string psw = txtPassword.Text;
            string pos = cbxPosition.SelectedItem.ToString();

            DataRow myRow = (mode == "Add") ? tabEmployees.NewRow() : tabEmployees.Rows[currentposition];
            myRow["EmpNumber"] = empnum;
            myRow["EmployeeName"] = name;
            myRow["BirthDate"] = dbate;
            myRow["EmpPassword"] = psw;
            myRow["EmpPosition"] = pos;

            if (mode == "Add")
            {
                tabEmployees.Rows.Add(myRow);
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myAdp);
                myAdp.Update(mySet, "Employees");
                mySet.Tables.Remove("Employees");
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Employees", myCon);
                myAdp = new OleDbDataAdapter(myCmd);
                myAdp.Fill(mySet, "Employees");
                tabEmployees = mySet.Tables["Employees"];

                currentposition = tabEmployees.Rows.Count - 1;
            }
            else if (mode == "Edit")
            {
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myAdp);
                myAdp.Update(mySet, "Employees");
                mySet.Tables.Remove("Employees");
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Employees", myCon);
                myAdp = new OleDbDataAdapter(myCmd);
                myAdp.Fill(mySet, "Employees");
                tabEmployees = mySet.Tables["Employees"];
            }
            Display();
            mode = "";
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
