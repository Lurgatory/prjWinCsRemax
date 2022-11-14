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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblWarning.Visible = false;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string num = txtNumber.Text;
            string ps = txtPassword.Text;
            OleDbConnection myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Multi-project\prjWinCsRemaxWindowsApp\prjWinCsRemaxWindowsApp\database\Remax.mdb");
            myCon.Open();
            if (rdbClient.Checked == true)
            {
                string sql = "SELECT ClientName, CltPassword, Identity FROM Clients WHERE (ClientNumber = '" + num + "') AND (CltPassword = '" + ps + "')";
                OleDbCommand myCmd = new OleDbCommand(sql, myCon);
                OleDbDataReader myRdr = myCmd.ExecuteReader();
                if (myRdr.HasRows == true)
                {
                    if (myRdr.Read())
                    {
                        if (myRdr["Identity"].ToString() == "Buyer")
                        {
                            myCon.Close();
                            this.Hide();
                            frmBuyerMain fbm = new frmBuyerMain();
                            fbm.ShowDialog();
                        }
                        else if (myRdr["Identity"].ToString() == "Seller")
                        {
                            myCon.Close();
                            this.Hide();
                            frmSellerMain fsm = new frmSellerMain();
                            fsm.ShowDialog();
                        }
                    }
                }
                else
                {
                    lblWarning.Visible = true;
                    lblWarning.Text = "Your Name or Password not found, Try again!";
                    txtPassword.Clear();
                    txtNumber.Focus();
                }
            }
            else if (rdbStaff.Checked == true)
            {
                string sql2 = "SELECT EmployeeName, EmpPassword, EmpPosition FROM Employees WHERE (EmpNumber = '" + num + "') AND (EmpPassword = '" + ps + "')";
                OleDbCommand myCmd2 = new OleDbCommand(sql2, myCon);
                OleDbDataReader myRdr2 = myCmd2.ExecuteReader();
                if (myRdr2.HasRows == true)
                {
                    if (myRdr2.Read())
                    {
                        if (myRdr2["EmpPosition"].ToString() == "Admin")
                        {
                            myCon.Close();
                            this.Hide();
                            frmAdminMain fam = new frmAdminMain();
                            fam.ShowDialog();
                        }
                        else if (myRdr2["EmpPosition"].ToString() == "Agent")
                        {
                            myCon.Close();
                            this.Hide();
                            frmAgentMain fgm = new frmAgentMain();
                            fgm.ShowDialog();
                        }
                    }
                }
                else
                {
                    lblWarning.Visible = true;
                    lblWarning.Text = "Your Name or Password not found, Try again!";
                    txtPassword.Clear();
                    txtNumber.Focus();
                }
            }
            else
            {
                lblWarning.Visible = true;
                lblWarning.Text = "Please select CLIENT or STAFF!";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string msg = "You sure you want to say BYEBYE to REMAX?";
            string title = "Application closing";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber.Clear();
            txtPassword.Clear();
            txtNumber.Focus();
            lblWarning.Visible = false;
        }
    }
}
