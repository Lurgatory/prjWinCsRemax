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
    public partial class frmClientManage : Form
    {
        public frmClientManage()
        {
            InitializeComponent();
        }
        DataSet mySet;
        OleDbConnection myCon;
        DataTable tabClient,tabComp,tabEmp;
        OleDbDataAdapter myAdp;
        int currentposition;
        string mode;

        private void frmClientManage_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Multi-project\prjWinCsRemaxWindowsApp\prjWinCsRemaxWindowsApp\database\Remax.mdb");
            myCon.Open();

            OleDbCommand myCmd = new OleDbCommand("SELECT RefCompany, CompanyName FROM Companies", myCon);
            OleDbDataAdapter comAdp = new OleDbDataAdapter(myCmd);
            comAdp.Fill(mySet, "Companies");

            myCmd = new OleDbCommand("SELECT RefEmployee, EmployeeName FROM Employees", myCon);
            OleDbDataAdapter empAdp = new OleDbDataAdapter(myCmd);
            empAdp.Fill(mySet, "Employees");

            myCmd = new OleDbCommand("SELECT * FROM Clients", myCon);
            myAdp = new OleDbDataAdapter(myCmd);
            myAdp.Fill(mySet, "Clients");
            tabClient = mySet.Tables["Clients"];
            tabComp = mySet.Tables["Companies"];
            tabEmp = mySet.Tables["Employees"];
            currentposition = 0;
            FillwithComboCompany();
            FillwithComboEmp();
            Display();
        }

        private void Display()
        {
            txtNumber.Text = tabClient.Rows[currentposition]["ClientNumber"].ToString();
            txtName.Text = tabClient.Rows[currentposition]["ClientName"].ToString();
            txtPassword.Text = tabClient.Rows[currentposition]["CltPassword"].ToString();
            dtpBirthDate.Value = Convert.ToDateTime(tabClient.Rows[currentposition]["BirthDate"]);
            cbxIdentity.Text = tabClient.Rows[currentposition]["Identity"].ToString();
            int referComp = Convert.ToInt32(tabClient.Rows[currentposition]["ReferCompany"]);
            cboCompany.SelectedValue = referComp;
            int referEmp = Convert.ToInt32(tabClient.Rows[currentposition]["ReferEmployee"]);
            cboManager.SelectedValue = referEmp;
            lblWarning.Text = "Client " + (currentposition + 1) + " on a total of " + (tabClient.Rows.Count);
        }

        private void FillwithComboCompany()
        {
            cboCompany.DataSource = tabComp;
            cboCompany.DisplayMember = "CompanyName";
            cboCompany.ValueMember = "RefCompany";
        }

        private void FillwithComboEmp()
        {
            cboManager.DataSource = tabEmp;
            cboManager.DisplayMember = "EmployeeName";
            cboManager.ValueMember = "RefEmployee";
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            Display();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentposition = tabClient.Rows.Count - 1;
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
            if (currentposition > tabClient.Rows.Count - 1)
            {
                currentposition = tabClient.Rows.Count - 1;
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
            txtName.Text = txtNumber.Text = txtPassword.Text = "";
            dtpBirthDate.Value = DateTime.Now;
            cbxIdentity.Text = "Select a Identity";
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
                    tabClient.Rows[currentposition].Delete();
                    // Now we need to update ( or synchronize) the contents of dataset --> the database
                    OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myAdp);
                    myAdp.Update(mySet, "Clients");
                    // Update the data of the datebase --> the dataset at same time
                    mySet.Tables.Remove("Clients");
                    OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Clients", myCon);
                    myAdp = new OleDbDataAdapter(myCmd);
                    myAdp.Fill(mySet, "Clients");
                    tabClient = mySet.Tables["Clients"];

                    currentposition = 0;
                    Display();
                }
                catch
                {
                    MessageBox.Show("Please delete all clients related to this employee at first", "Your program has an error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCompanyManage fcm = new frmCompanyManage();
            fcm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            DateTime dbate = dtpBirthDate.Value;
            string num = txtNumber.Text;
            string psw = txtPassword.Text;
            string pos = cbxIdentity.SelectedItem.ToString();
            int refCom = Convert.ToInt32(cboCompany.SelectedValue);
            int refEmp = Convert.ToInt32(cboManager.SelectedValue);

            DataRow myRow = (mode == "Add") ? tabClient.NewRow() : tabClient.Rows[currentposition];
            myRow["ClientNumber"] = num;
            myRow["ClientName"] = name;
            myRow["BirthDate"] = dbate;
            myRow["CltPassword"] = psw;
            myRow["Identity"] = pos;
            myRow["ReferCompany"] = refCom;
            myRow["ReferEmployee"] = refEmp;

            if (mode == "Add")
            {
                tabClient.Rows.Add(myRow);
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myAdp);
                myAdp.Update(mySet, "Clients");
                mySet.Tables.Remove("Clients");
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Clients", myCon);
                myAdp = new OleDbDataAdapter(myCmd);
                myAdp.Fill(mySet, "Clients");
                tabClient = mySet.Tables["Clients"];

                currentposition = tabClient.Rows.Count - 1;
            }
            else if (mode == "Edit")
            {
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myAdp);
                myAdp.Update(mySet, "Clients");
                mySet.Tables.Remove("Clients");
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Clients", myCon);
                myAdp = new OleDbDataAdapter(myCmd);
                myAdp.Fill(mySet, "Clients");
                tabClient = mySet.Tables["Clients"];
            }
            Display();
            mode = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}
