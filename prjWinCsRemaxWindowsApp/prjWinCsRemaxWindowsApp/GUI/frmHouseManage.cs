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
    public partial class frmHouseManage : Form
    {
        public frmHouseManage()
        {
            InitializeComponent();
        }

        DataSet mySet;
        OleDbConnection myCon;
        DataTable tabHouse, tabClient;
        OleDbDataAdapter houAdp;
        int currentposition;
        string mode;

        private void frmHouseManage_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Multi-project\prjWinCsRemaxWindowsApp\prjWinCsRemaxWindowsApp\database\Remax.mdb");
            myCon.Open();

            OleDbCommand myCmd = new OleDbCommand("SELECT RefClient, ClientName FROM Clients", myCon);
            OleDbDataAdapter cltAdp = new OleDbDataAdapter(myCmd);
            cltAdp.Fill(mySet, "Clients");

            myCmd = new OleDbCommand("SELECT * FROM Houses", myCon);
            houAdp = new OleDbDataAdapter(myCmd);
            houAdp.Fill(mySet, "Houses");

            tabClient = mySet.Tables["Clients"];
            tabHouse = mySet.Tables["Houses"];
            currentposition = 0;
            FillComboWithClient();
            Display();
        }

        private void Display()
        {
            txtNumber.Text = tabHouse.Rows[currentposition]["HouseNumber"].ToString();
            cboType.Text = tabHouse.Rows[currentposition]["HouseType"].ToString();
            txtYear.Text = tabHouse.Rows[currentposition]["HouseYear"].ToString();
            txtAddress.Text = tabHouse.Rows[currentposition]["Address"].ToString();
            int referClient = Convert.ToInt32(tabHouse.Rows[currentposition]["ReferClient"]);
            cboClient.SelectedValue = referClient;
            lblWarning.Text = "House " + (currentposition + 1) + " on a total of " + (tabHouse.Rows.Count);
        }

        private void FillComboWithClient()
        {
            cboClient.DataSource = tabClient;
            cboClient.DisplayMember = "ClientName";
            cboClient.ValueMember = "RefClient";
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            Display();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentposition = tabHouse.Rows.Count - 1;
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
            if (currentposition > tabHouse.Rows.Count - 1)
            {
                currentposition = tabHouse.Rows.Count - 1;
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
            txtNumber.Text = txtAddress.Text = txtYear.Text = "";
            cboType.Text = "Select a type";
            txtNumber.Focus();
            lblWarning.Text = "----Add Mode----";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtNumber.Focus();
            lblWarning.Text = "----Edit Mode----";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure to want to delete this house?";
            string title = "Warning : House Deletion";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    tabHouse.Rows[currentposition].Delete();
                    // Now we need to update ( or synchronize) the contents of dataset --> the database
                    OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(houAdp);
                    houAdp.Update(mySet, "Houses");
                    // Update the data of the datebase --> the dataset at same time
                    mySet.Tables.Remove("Houses");
                    OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Houses", myCon);
                    houAdp = new OleDbDataAdapter(myCmd);
                    houAdp.Fill(mySet, "Houses");
                    tabHouse = mySet.Tables["Houses"];

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
            string num = txtNumber.Text;
            string type = cboType.SelectedItem.ToString();
            int year = Convert.ToInt32(txtYear.Text);
            string add = txtAddress.Text;
            int refClt = Convert.ToInt32(cboClient.SelectedValue);

            DataRow myRow = (mode == "add") ? tabHouse.NewRow() : tabHouse.Rows[currentposition];
            myRow["HouseNumber"] = num;
            myRow["HouseType"] = type;
            myRow["HouseYear"] = year;
            myRow["Address"] = add;
            myRow["ReferClient"] = refClt;

            if (mode == "add")
            {
                tabHouse.Rows.Add(myRow);
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(houAdp);
                houAdp.Update(mySet, "Houses");
                mySet.Tables.Remove("Houses");
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Houses", myCon);
                houAdp = new OleDbDataAdapter(myCmd);
                houAdp.Fill(mySet, "Houses");
                tabHouse = mySet.Tables["Houses"];

                currentposition = tabHouse.Rows.Count - 1;
            }
            else if (mode == "edit")
            {
                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(houAdp);
                houAdp.Update(mySet, "Houses");
                mySet.Tables.Remove("Houses");
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Houses", myCon);
                houAdp = new OleDbDataAdapter(myCmd);
                houAdp.Fill(mySet, "Houses");
                tabHouse = mySet.Tables["Houses"];
            }
            Display();
            mode = "";

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}
