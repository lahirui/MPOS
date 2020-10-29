using POS.DAL;
using POS.PRL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class POS : Form
    {
        #region Variables

        private Common com = new Common();
        private DataSet dsEmployeeDetails = new DataSet();
        private int _EmployeeID;
        private string _EmployeeEPF;
        private string _EmployeeCode;
        private int _EmployeeClassId;
        private int _EmployeeFactoryId;
        private int _UserId;
        private int _UserFactoryId;
        private int _X = 0;
        private int _Y = 0;
        private int _Z = 0;
        private int _SelectedItemId=0;
        private decimal _MinVal;
        private decimal _MaxVal;
        private decimal _CreditBalance;
        private decimal _ItemTotalAfterDelete;
        private decimal _CurrentOrderBalance = 0;
        private decimal _DaySellingQty = 0;
        private string _UserName;
        private string _ItemName;
        private string _UnitPrice;
        private bool _ItemFound = false;

        #endregion Variables

        public POS()
        {
            InitializeComponent();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            txtEPFNo.Focus();
            btnEnter.Visible = false;
            btnPurchase.Visible = false;
            _UserName = Variables._CashierEPF;
            lblCashierEpf.Text = Variables._CashierEPF;
            lblCahierFactory.Text = Variables._CashierFactoryName;
            timer1.Enabled = true;
            timer1.Interval = 1000;
            this.gvSelectedItems.AutoResizeColumns();
            this.gvSelectedItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataSet dsUserFactoryId = new DataSet();
            dsUserFactoryId = com.ReturnDataSet("SELECT ID, FactoryId FROM Users WHERE(Username = '" + _UserName + "') AND(IsActive = 1)");
            if (dsUserFactoryId.Tables[0].Rows.Count > 0)
            {
                _UserId = Convert.ToInt32(dsUserFactoryId.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
                _UserFactoryId = Convert.ToInt32(dsUserFactoryId.Tables[0].Rows[0].ItemArray.GetValue(1).ToString());
            }

            DataSet dsCatagories = new DataSet();
            dsCatagories = com.ReturnDataSet("SELECT ID, ItemType FROM ItemTypes WHERE(FactoryID = " + _UserFactoryId + ") AND(IsDeleted = 0) ORDER BY ItemType");

            for (int i = 0; i < dsCatagories.Tables[0].Rows.Count; i++)
            {
                Button button = new Button();
                button.Size = new Size(120, 90);
                button.Name = dsCatagories.Tables[0].Rows[i].ItemArray.GetValue(0).ToString(); ;
                button.Text = dsCatagories.Tables[0].Rows[i].ItemArray.GetValue(1).ToString();
                button.BackColor = System.Drawing.Color.Orange;
                button.ForeColor = System.Drawing.Color.White;
                button.Cursor = Cursors.Hand;
                button.Location = new Point(10, 100 * (_X + 1));
                _X++;

                button.Click += new EventHandler(btnCatagories_Click);
                flpCatagories.Controls.Add(button);
            }
            _X = 0;
        }

        private void txtEPFNo_TextChanged(object sender, EventArgs e)
        {
            if (txtEPFNo.Text.Length >= 5)
            {
                lblMessage.Text = "";
                btnOne.Visible = true;
                btnTwo.Visible = true;
                btnThree.Visible = true;
                btnFour.Visible = true;
                btnFive.Visible = true;
                btnSix.Visible = true;
                btnSeven.Visible = true;
                btnEight.Visible = true;
                btnNine.Visible = true;
                btnDot.Visible = true;
                btnZero.Visible = true;
                btnClear.Visible = true;
                btnEnter.Visible = true;
                lblEnteredQty.Visible = true;
                lblItem.Visible = true;
                btnPurchase.Enabled = true;
                dsEmployeeDetails = com.ReturnDataSet("SELECT ID, EPF, FullName, CallingName, FactoryId, CreditBalance, IsActive, IsDeleted, ISNULL(Department,'NA') AS Department, EPFNumber, ISNULL(ClassId,0) AS ClassId,TnANumber " +
                                                  "FROM     Employees " +
                                                  "WHERE(IsActive = 1) AND (IsDeleted = 0) AND (TnANumber='" + txtEPFNo.Text + "') ");
                if (dsEmployeeDetails.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(dsEmployeeDetails.Tables[0].Rows[0].ItemArray.GetValue(10).ToString()) > 0)
                    {
                        _EmployeeID = Convert.ToInt32(dsEmployeeDetails.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
                        _EmployeeEPF = dsEmployeeDetails.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                        _EmployeeFactoryId = Convert.ToInt32(dsEmployeeDetails.Tables[0].Rows[0].ItemArray.GetValue(4).ToString());
                        _EmployeeCode = dsEmployeeDetails.Tables[0].Rows[0].ItemArray.GetValue(9).ToString();
                        _EmployeeClassId = Convert.ToInt32(dsEmployeeDetails.Tables[0].Rows[0].ItemArray.GetValue(10).ToString());
                        lblName.Text = dsEmployeeDetails.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                        decimal MinusRemovedBalance = Convert.ToDecimal(dsEmployeeDetails.Tables[0].Rows[0].ItemArray.GetValue(5).ToString()) * -1;
                        _CreditBalance = Convert.ToDecimal(dsEmployeeDetails.Tables[0].Rows[0].ItemArray.GetValue(5).ToString());
                        lblAvailableBalance.Text = Convert.ToString(MinusRemovedBalance);
                        lblEpfNumber.Text = _EmployeeEPF;
                        btnEnter.Visible = true;
                        btnPurchase.Visible = true;
                        EmployeeImage();

                        DataSet dsConfigurations = new DataSet();
                        dsConfigurations = com.ReturnDataSet("SELECT ParamValue FROM Configurations WHERE(ParamName = 'CommonThreshold')");
                        if (dsConfigurations.Tables[0].Rows[0].ItemArray.GetValue(0).ToString() == "True")
                        {
                            DataSet dsMinVal = new DataSet();
                            dsMinVal = com.ReturnDataSet("SELECT ParamValue FROM Configurations WHERE(ParamName = 'MinPayment')");
                            if (dsMinVal.Tables[0].Rows.Count > 0)
                            {
                                _MinVal = Convert.ToDecimal(dsMinVal.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
                            }
                            DataSet dsMaxVal = new DataSet();
                            dsMaxVal = com.ReturnDataSet("SELECT ParamValue FROM Configurations WHERE(ParamName = 'MaxPayment')");
                            if (dsMaxVal.Tables[0].Rows.Count > 0)
                            {
                                _MaxVal = Convert.ToDecimal(dsMaxVal.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
                            }
                        }
                        else if (dsConfigurations.Tables[0].Rows[0].ItemArray.GetValue(0).ToString() == "False")
                        {
                            DataSet dsClassValues = new DataSet();
                            dsClassValues = com.ReturnDataSet("SELECT MaxVal, MinVal FROM Classes WHERE(ID = " + _EmployeeClassId + ")");
                            if (dsClassValues.Tables[0].Rows.Count > 0)
                            {
                                if (_EmployeeClassId > 0)
                                {
                                    _MaxVal = Convert.ToDecimal(dsClassValues.Tables[0].Rows[0].ItemArray.GetValue(0).ToString());
                                    _MinVal = Convert.ToDecimal(dsClassValues.Tables[0].Rows[0].ItemArray.GetValue(1).ToString());
                                }
                                else
                                {
                                    lblMessage.Text = "Employee Class Not Defined. Please Contact HRD";
                                }

                            }

                        }
                        else
                        {
                            _MaxVal = 0;
                            _MinVal = 0;
                        }
                        if (_MinVal > _CreditBalance)
                        {
                            flpCatagories.Visible = false;
                            MessageBox.Show("Credit Limit Exceeded", "No Credits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        txtEPFNo.Enabled = false;
                    }
                    else
                    {
                        lblMessage.Text = "Employee Class Not Defined. Please Contact HRD";
                    }

                    
                }
                else
                {
                    lblEpfNumber.Text = "NO EMPLOYEE";
                    lblName.Text = "NO EMPLOYEE";
                }
            }
        }

        private void btnCatagories_Click(object sender, EventArgs e)
        {
            if (txtEPFNo.Text.Length == 0)
            {
                lblMessage.Text = "Employee Not Selected";
                btnOne.Visible = false;
                btnTwo.Visible = false;
                btnThree.Visible = false;
                btnFour.Visible = false;
                btnFive.Visible = false;
                btnSix.Visible = false;
                btnSeven.Visible = false;
                btnEight.Visible = false;
                btnNine.Visible = false;
                btnDot.Visible = false;
                btnZero.Visible = false;
                btnClear.Visible = false;
                btnEnter.Visible = false;
                lblEnteredQty.Visible = false;
                lblItem.Visible = false;
                pbEmployeePicture.Image = null;
                btnPurchase.Enabled = false;

                flpItems.Controls.Clear();
                int CatagoryId = Convert.ToInt32((sender as Button).Name);
                DataSet dsItemsinCatagory = new DataSet();
                dsItemsinCatagory = com.ReturnDataSet("SELECT ID, ItemName, UnitPrice, DaySellingQty, IsDeleted " +
                                                      "FROM Items " +
                                                      "WHERE(ItemTypeId = " + CatagoryId + ") AND(IsDeleted = 0) AND(FactoryId = " + _UserFactoryId + ") AND (DaySellingQty > 0) " +
                                                      "ORDER BY ItemName");
                for (int i = 0; i < dsItemsinCatagory.Tables[0].Rows.Count; i++)
                {
                    Button button = new Button();

                    string daySellingQty = dsItemsinCatagory.Tables[0].Rows[i].ItemArray.GetValue(3).ToString();
                    Label lbldaySellingQty = new Label();
                    lbldaySellingQty.Text = daySellingQty;
                    lbldaySellingQty.TextAlign = ContentAlignment.TopCenter;
                    lbldaySellingQty.BackColor = Color.Transparent;
                    lbldaySellingQty.ForeColor = System.Drawing.Color.Red;
                    lbldaySellingQty.Location = new Point(15, 1 * (_Y + 1));
                    _Y++;

                    button.Size = new Size(130, 90);
                    button.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    button.Name = dsItemsinCatagory.Tables[0].Rows[i].ItemArray.GetValue(0).ToString();
                    button.Text = dsItemsinCatagory.Tables[0].Rows[i].ItemArray.GetValue(1).ToString();
                    button.BackColor = System.Drawing.Color.MediumTurquoise;
                    button.ForeColor = System.Drawing.Color.White;
                    button.Cursor = Cursors.Hand;
                    button.Location = new Point(10, 100 * (_Z + 1));
                    _Z++;
                    button.Click += new EventHandler(btnItems_Click);
                    flpItems.Controls.Add(button);
                    button.Controls.Add(lbldaySellingQty);
                }
                _Y = 0;
                _Z = 0;
            }
            else
            {
                btnOne.Visible = true;
                btnTwo.Visible = true;
                btnThree.Visible = true;
                btnFour.Visible = true;
                btnFive.Visible = true;
                btnSix.Visible = true;
                btnSeven.Visible = true;
                btnEight.Visible = true;
                btnNine.Visible = true;
                btnDot.Visible = true;
                btnZero.Visible = true;
                btnClear.Visible = true;
                btnEnter.Visible = true;
                lblEnteredQty.Visible = true;
                lblItem.Visible = true;

                flpItems.Controls.Clear();
                int CatagoryId = Convert.ToInt32((sender as Button).Name);
                DataSet dsItemsinCatagory = new DataSet();
                dsItemsinCatagory = com.ReturnDataSet("SELECT ID, ItemName, UnitPrice, DaySellingQty, IsDeleted " +
                                                      "FROM Items " +
                                                      "WHERE(ItemTypeId = " + CatagoryId + ") AND(IsDeleted = 0) AND(FactoryId = " + _UserFactoryId + ") AND (DaySellingQty > 0) " +
                                                      "ORDER BY ItemName");
                for (int i = 0; i < dsItemsinCatagory.Tables[0].Rows.Count; i++)
                {
                    Button button = new Button();

                    string daySellingQty = dsItemsinCatagory.Tables[0].Rows[i].ItemArray.GetValue(3).ToString();
                    Label lbldaySellingQty = new Label();
                    lbldaySellingQty.Text = daySellingQty;
                    lbldaySellingQty.TextAlign = ContentAlignment.TopCenter;
                    lbldaySellingQty.BackColor = Color.Transparent;
                    lbldaySellingQty.ForeColor = System.Drawing.Color.Red;
                    lbldaySellingQty.Location = new Point(15, 1 * (_Y + 1));
                    _Y++;

                    button.Size = new Size(130, 90);
                    button.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    button.Name = dsItemsinCatagory.Tables[0].Rows[i].ItemArray.GetValue(0).ToString();
                    button.Text = dsItemsinCatagory.Tables[0].Rows[i].ItemArray.GetValue(1).ToString();
                    button.BackColor = System.Drawing.Color.MediumTurquoise;
                    button.ForeColor = System.Drawing.Color.White;
                    button.Cursor = Cursors.Hand;
                    button.Location = new Point(10, 100 * (_Z + 1));
                    _Z++;
                    button.Click += new EventHandler(btnItems_Click);
                    flpItems.Controls.Add(button);

                    button.Controls.Add(lbldaySellingQty);
                }
                _Y = 0;
                _Z = 0;
            }
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            if (txtEPFNo.Text.Length > 0)
            {
                _SelectedItemId = Convert.ToInt32((sender as Button).Name);
                lblItem.Text = (sender as Button).Text;
            }
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = lblEnteredQty.Text + (sender as Button).Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblEnteredQty.Text = "0";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //if (gvSelectedItems.Rows.Count == 0)
            //{
            //    DataSet dsAddItemsToGrid = new DataSet();
            //    dsAddItemsToGrid = com.ReturnDataSet("SELECT ID, ItemName, UnitPrice, DaySellingQty FROM Items WHERE(ID = " + _SelectedItemId + ")");
            //    if (dsAddItemsToGrid.Tables[0].Rows.Count > 0)
            //    {
            //        _ItemName = dsAddItemsToGrid.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
            //        _UnitPrice = dsAddItemsToGrid.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
            //        _DaySellingQty = Convert.ToDecimal(dsAddItemsToGrid.Tables[0].Rows[0].ItemArray.GetValue(3).ToString());
            //    }
            //    if (_DaySellingQty >= Convert.ToDecimal(lblEnteredQty.Text))
            //    {
            //        decimal qty = Convert.ToDecimal(lblEnteredQty.Text);
            //        decimal untiPrice = Convert.ToDecimal(_UnitPrice);
            //        decimal total = (qty * untiPrice);

            //        var RemoveButton = new DataGridViewButtonColumn();
            //        RemoveButton.Name = "Remove";
            //        RemoveButton.HeaderText = "REMOVE";
            //        RemoveButton.Text = "REMOVE";
            //        RemoveButton.UseColumnTextForButtonValue = true;
            //        this.gvSelectedItems.Columns.Add(RemoveButton);

            //        gvSelectedItems.ColumnCount = 6;
            //        gvSelectedItems.Columns[0].Name = RemoveButton.Name;
            //        gvSelectedItems.Columns[1].Name = "ID";
            //        gvSelectedItems.Columns[1].Visible = false;
            //        gvSelectedItems.Columns[2].Name = "Item";
            //        gvSelectedItems.Columns[2].Width = 250;
            //        gvSelectedItems.Columns[3].Name = "Quantity";
            //        gvSelectedItems.Columns[4].Name = "Unit Price";
            //        gvSelectedItems.Columns[5].Name = "Total";

            //        string[] row = new string[] { "", Convert.ToString(_SelectedItemId), _ItemName, lblEnteredQty.Text, _UnitPrice, Convert.ToString(total) };
            //        gvSelectedItems.Rows.Add(row);

            //        lblEnteredQty.Text = "0";
            //        lblItem.Text = "";
            //        decimal existingOrderBalance = Convert.ToDecimal(lblOrderBalance.Text);
            //        decimal newOrderBalance = existingOrderBalance + total;
            //        lblOrderBalance.Text = Convert.ToString(newOrderBalance);
            //        decimal availabelBalance = Convert.ToDecimal(lblAvailableBalance.Text);
            //        decimal totalBalance = availabelBalance + newOrderBalance;
            //        lblTotal.Text = Convert.ToString(totalBalance);
            //    }
            //    else
            //    {
            //        lblEnteredQty.Text = "0";
            //        lblItem.Text = "";
            //        _SelectedItemId = 0;
            //        MessageBox.Show("Cannot Purchase Required Quantity", "Not Enough Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else 
            if (_SelectedItemId > 0)
            {
                int EnteredQty = Convert.ToInt32(lblEnteredQty.Text);
                if (EnteredQty > 0)
                {
                    if (gvSelectedItems.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow rows in gvSelectedItems.Rows)
                        {
                            int itemId = Convert.ToInt32(rows.Cells[1].Value.ToString());
                            if (itemId == _SelectedItemId)
                            {
                                _ItemFound = true;
                                lblEnteredQty.Text = "0";
                                lblItem.Text = "";
                                _SelectedItemId = 0;
                                MessageBox.Show("Item Already Selected. Please Select a Different Item", "Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                        }

                        _ItemFound = false;
                    }
                    if (_ItemFound == false)
                    {
                        DataSet dsAddItemsToGrid = new DataSet();
                        dsAddItemsToGrid = com.ReturnDataSet("SELECT ID, ItemName, UnitPrice, DaySellingQty FROM Items WHERE(ID = " + _SelectedItemId + ")");
                        if (dsAddItemsToGrid.Tables[0].Rows.Count > 0)
                        {
                            _ItemName = dsAddItemsToGrid.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
                            _UnitPrice = dsAddItemsToGrid.Tables[0].Rows[0].ItemArray.GetValue(2).ToString();
                            _DaySellingQty = Convert.ToDecimal(dsAddItemsToGrid.Tables[0].Rows[0].ItemArray.GetValue(3).ToString());

                            if (_DaySellingQty >= Convert.ToDecimal(lblEnteredQty.Text))
                            {
                                decimal qty = Convert.ToDecimal(lblEnteredQty.Text);
                                decimal untiPrice = Convert.ToDecimal(_UnitPrice);
                                decimal total = (qty * untiPrice);

                                var RemoveButton = new DataGridViewButtonColumn();
                                RemoveButton.Name = "Remove";
                                RemoveButton.HeaderText = "Remove";
                                RemoveButton.Text = "REMOVE";
                                RemoveButton.UseColumnTextForButtonValue = true;
                                this.gvSelectedItems.Columns.Add(RemoveButton);

                                gvSelectedItems.ColumnCount = 6;
                                gvSelectedItems.Columns[0].Name = RemoveButton.Name;
                                gvSelectedItems.Columns[1].Name = "ID";
                                gvSelectedItems.Columns[1].Visible = false;
                                gvSelectedItems.Columns[2].Name = "Item";
                                gvSelectedItems.Columns[2].Width = 250;
                                gvSelectedItems.Columns[3].Name = "Qty";
                                gvSelectedItems.Columns[4].Name = "Price";
                                gvSelectedItems.Columns[5].Name = "Total";

                                string[] row = new string[] { "", Convert.ToString(_SelectedItemId), _ItemName, lblEnteredQty.Text, _UnitPrice, Convert.ToString(total) };
                                gvSelectedItems.Rows.Add(row);

                                lblEnteredQty.Text = "0";
                                lblItem.Text = "";
                                decimal existingOrderBalance = Convert.ToDecimal(lblOrderBalance.Text);
                                decimal newOrderBalance = existingOrderBalance + total;
                                lblOrderBalance.Text = Convert.ToString(newOrderBalance);
                                decimal availabelBalance = Convert.ToDecimal(lblAvailableBalance.Text);
                                decimal totalBalance = availabelBalance + newOrderBalance;
                                lblTotal.Text = Convert.ToString(totalBalance);
                                _SelectedItemId = 0;
                            }
                            else
                            {
                                lblEnteredQty.Text = "0";
                                lblItem.Text = "";
                                _SelectedItemId = 0;
                                MessageBox.Show("Cannot Purchase Required Quantity", "Not Enough Items To Sell", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Enter Required Quantity", "No Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Item Not Selected", "Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblEnteredQty.Text = "0";
            }
            
        }

        private void gvSelectedItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string message = "Do You Want To Delete ?";
            string title = "Delete";
            MessageBoxButtons msgButtons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, msgButtons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.gvSelectedItems.Rows.RemoveAt(e.RowIndex);

                if (gvSelectedItems.Rows.Count > 0)
                {
                    foreach (DataGridViewRow gridRow in gvSelectedItems.Rows)
                    {
                        _ItemTotalAfterDelete = Convert.ToDecimal(gridRow.Cells[5].Value.ToString());
                        _CurrentOrderBalance = _CurrentOrderBalance + _ItemTotalAfterDelete;
                    }
                    lblOrderBalance.Text = Convert.ToString(_CurrentOrderBalance);
                    decimal UpdatedOrderBalance = Convert.ToDecimal(lblOrderBalance.Text);
                    decimal CurrentAvailableBalance = Convert.ToDecimal(lblAvailableBalance.Text);
                    lblTotal.Text = Convert.ToString(CurrentAvailableBalance + UpdatedOrderBalance);
                    _CurrentOrderBalance = 0;
                    _ItemTotalAfterDelete = 0;
                }
                else
                {
                    lblOrderBalance.Text = "0";
                    lblTotal.Text = "0";
                    gvSelectedItems.DataSource = null;
                    _CurrentOrderBalance = 0;
                    _ItemTotalAfterDelete = 0;
                }
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            btnPurchase.Enabled = false;
            if (gvSelectedItems.Rows.Count > 0)
            {
                decimal newAvailableBalance = Convert.ToDecimal(lblTotal.Text) * -1;

                if (newAvailableBalance >= _MinVal)
                {
                    foreach (DataGridViewRow gridRow in gvSelectedItems.Rows)
                    {
                        int itemId = Convert.ToInt32(gridRow.Cells[1].Value.ToString());
                        string ItemName = gridRow.Cells[2].Value.ToString();
                        decimal quantity = Convert.ToDecimal(gridRow.Cells[3].Value.ToString());
                        decimal unitPrice = Convert.ToDecimal(gridRow.Cells[4].Value.ToString());

                        DataSet dsAddItemsToGrid = new DataSet();
                        dsAddItemsToGrid = com.ReturnDataSet("SELECT ID, ItemName, UnitPrice, DaySellingQty FROM Items WHERE(ID = " + itemId + ")");
                        if (dsAddItemsToGrid.Tables[0].Rows.Count > 0)
                        {
                            decimal currentlyAvailableQty = Convert.ToDecimal(dsAddItemsToGrid.Tables[0].Rows[0].ItemArray.GetValue(3).ToString());
                            if (quantity <= currentlyAvailableQty)
                            {
                                try
                                {
                                    com.BeginTrans();
                                    SqlParameter[] Parameters = new SqlParameter[6];
                                    Parameters[0] = new SqlParameter("@EmployeeId", _EmployeeID);
                                    Parameters[1] = new SqlParameter("@ItemId", itemId);
                                    Parameters[2] = new SqlParameter("@Quantity", quantity);
                                    Parameters[3] = new SqlParameter("@UnitPrice", unitPrice);
                                    Parameters[4] = new SqlParameter("@FactoryId", _UserFactoryId);
                                    Parameters[5] = new SqlParameter("@UserId", _UserId);

                                    int saveDetails = 0;
                                    saveDetails = com.ExecuteProcedure("SP_InsertPurchasedItems", CommandType.StoredProcedure, Parameters);
                                    com.CommitTrans();
                                }
                                catch (Exception ex)
                                {
                                    com.RollbackTrans();
                                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                Variables._ListOfNotAvailableItemsWhenPurchase.Add(quantity + " pcs of " + ItemName + "was not available to purchase" + quantity);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Not Enough Items to Purchase", "Not Enough Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (Variables._ListOfNotAvailableItemsWhenPurchase.Count > 0)
                    {
                        var message = string.Join(Environment.NewLine, Variables._ListOfNotAvailableItemsWhenPurchase.ToArray());
                        MessageBox.Show(message, "Not Enough Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ClerControls();
                }
                else
                {
                    MessageBox.Show("Credit Balance Not Enough to Purchase Items", "Credit Balance Not Enough", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Items Not Selected to Purchase", "No Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClerControls();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            PurchaseScreen screen = new PurchaseScreen();
            screen.Show();
        }

        private void ClerControls()
        {
            txtEPFNo.Clear();
            txtEPFNo.Enabled = true;
            txtEPFNo.Focus();
            lblEpfNumber.Text = "";
            lblName.Text = "";
            lblAvailableBalance.Text = "0";
            lblOrderBalance.Text = "0";
            lblTotal.Text = "0";
            flpItems.Controls.Clear();
            lblItem.Text = "";
            lblEnteredQty.Text = "0";
            gvSelectedItems.DataSource = null;
            gvSelectedItems.Rows.Clear();
            gvSelectedItems.Columns.Clear();
            gvSelectedItems.Refresh();
            pbEmployeePicture.Image = null;
            lblMessage.Text = "";
        }

        public void EmployeeImage()
        {
            if (_EmployeeFactoryId == 1)
            {
                string path = $@"\\192.168.58.219\HRMS\Katunayake\{_EmployeeEPF}.JPG";
                pbEmployeePicture.ImageLocation = path;
                pbEmployeePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (_EmployeeFactoryId == 2)
            {
                string ZeroRemovedEmployeeCode= _EmployeeCode.TrimStart(new Char[] { '0' });
                string path = $@"\\192.168.58.219\HRMS\Wathupitiwala\{ZeroRemovedEmployeeCode}.JPG";
                pbEmployeePicture.ImageLocation = path;
                pbEmployeePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (_EmployeeFactoryId == 3)
            {
                string ZeroRemovedEmployeeCode = _EmployeeCode.TrimStart(new Char[] { '0' });
                string path = $@"\\192.168.58.219\HRMS\Malwatta\{ZeroRemovedEmployeeCode}.JPG";
                pbEmployeePicture.ImageLocation = path;
                pbEmployeePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (_EmployeeFactoryId == 4)
            {
                string path = $@"\\192.168.58.219\HRMS\Kantale\{_EmployeeCode}.JPG";
                pbEmployeePicture.ImageLocation = path;
                pbEmployeePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (_EmployeeFactoryId == 5)
            {
                string path = $@"\\192.168.58.219\HRMS\Galagedara\{_EmployeeCode}.JPG";
                pbEmployeePicture.ImageLocation = path;
                pbEmployeePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (_EmployeeFactoryId == 6)
            {
                string path = $@"\\192.168.58.219\HRMS\Dambulla\{_EmployeeCode}.JPG";
                pbEmployeePicture.ImageLocation = path;
                pbEmployeePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}