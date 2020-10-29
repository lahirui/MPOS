using POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.PRL
{
    public partial class Login : Form
    {
        Common com = new Common();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataSet dsCashier = new DataSet();
            dsCashier = com.ReturnDataSet("SELECT dbo.Users.ID, dbo.Users.Username, dbo.Users.FactoryId, dbo.Factories.Code AS Factory "+
                                            "FROM     dbo.Users INNER JOIN " +
                                                              "dbo.Factories ON dbo.Users.FactoryId = dbo.Factories.ID " +
                                            "WHERE(dbo.Users.Username = '"+txtUsername.Text.ToUpper()+"') AND(dbo.Users.IsActive = 1)");
            if (dsCashier.Tables[0].Rows.Count > 0)
            {
                Variables._CashierId = Convert.ToInt32(dsCashier.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
                Variables._CashierEPF = dsCashier.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                Variables._CashierFactoryId = Convert.ToInt32(dsCashier.Tables[0].Rows[0].ItemArray.GetValue(2).ToString());
                Variables._CashierFactoryName= dsCashier.Tables[0].Rows[0].ItemArray.GetValue(3).ToString();

                POS pOS = new POS();
                this.Hide();
                pOS.Show();
                
            }
            else
            {
                MessageBox.Show("Access Denied."+"\n"+" Please Enter a Valid Username", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtUsername.Focus();
                //lblMessage.Text = "Access Denied";
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
