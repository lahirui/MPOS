namespace POS
{
    partial class POS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbEmployeeDetails = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEpfNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblOrderBalance = new System.Windows.Forms.Label();
            this.lblAvailableBalance = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbEmployeePicture = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEPFNo = new MetroFramework.Controls.MetroTextBox();
            this.gbCatagories = new System.Windows.Forms.GroupBox();
            this.flpCatagories = new System.Windows.Forms.FlowLayoutPanel();
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.flpItems = new System.Windows.Forms.FlowLayoutPanel();
            this.gbKeyboard = new System.Windows.Forms.GroupBox();
            this.lblEnteredQty = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnSix = new System.Windows.Forms.Button();
            this.btnSeven = new System.Windows.Forms.Button();
            this.btnNine = new System.Windows.Forms.Button();
            this.btnEight = new System.Windows.Forms.Button();
            this.gbSelectedItems = new System.Windows.Forms.GroupBox();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.gvSelectedItems = new System.Windows.Forms.DataGridView();
            this.btnScreen = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblUserEPF = new System.Windows.Forms.Label();
            this.lblCashierEpf = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCahierFactory = new System.Windows.Forms.Label();
            this.gbEmployeeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmployeePicture)).BeginInit();
            this.gbCatagories.SuspendLayout();
            this.gbItems.SuspendLayout();
            this.gbKeyboard.SuspendLayout();
            this.gbSelectedItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEmployeeDetails
            // 
            this.gbEmployeeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEmployeeDetails.Controls.Add(this.lblMessage);
            this.gbEmployeeDetails.Controls.Add(this.label3);
            this.gbEmployeeDetails.Controls.Add(this.lblEpfNumber);
            this.gbEmployeeDetails.Controls.Add(this.lblName);
            this.gbEmployeeDetails.Controls.Add(this.lblTotal);
            this.gbEmployeeDetails.Controls.Add(this.lblOrderBalance);
            this.gbEmployeeDetails.Controls.Add(this.lblAvailableBalance);
            this.gbEmployeeDetails.Controls.Add(this.label5);
            this.gbEmployeeDetails.Controls.Add(this.label4);
            this.gbEmployeeDetails.Controls.Add(this.pbEmployeePicture);
            this.gbEmployeeDetails.Controls.Add(this.label2);
            this.gbEmployeeDetails.Controls.Add(this.label1);
            this.gbEmployeeDetails.Controls.Add(this.txtEPFNo);
            this.gbEmployeeDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEmployeeDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gbEmployeeDetails.Location = new System.Drawing.Point(23, 38);
            this.gbEmployeeDetails.Name = "gbEmployeeDetails";
            this.gbEmployeeDetails.Size = new System.Drawing.Size(1550, 159);
            this.gbEmployeeDetails.TabIndex = 1;
            this.gbEmployeeDetails.TabStop = false;
            this.gbEmployeeDetails.Text = "EMPLOYEE DETAILS";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(6, 103);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(959, 30);
            this.lblMessage.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(986, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Current Amount:";
            // 
            // lblEpfNumber
            // 
            this.lblEpfNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpfNumber.ForeColor = System.Drawing.Color.Red;
            this.lblEpfNumber.Location = new System.Drawing.Point(307, 27);
            this.lblEpfNumber.Name = "lblEpfNumber";
            this.lblEpfNumber.Size = new System.Drawing.Size(223, 34);
            this.lblEpfNumber.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(600, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(385, 126);
            this.lblName.TabIndex = 10;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(1164, 108);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(170, 31);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderBalance
            // 
            this.lblOrderBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderBalance.ForeColor = System.Drawing.Color.Red;
            this.lblOrderBalance.Location = new System.Drawing.Point(1163, 64);
            this.lblOrderBalance.Name = "lblOrderBalance";
            this.lblOrderBalance.Size = new System.Drawing.Size(171, 31);
            this.lblOrderBalance.TabIndex = 8;
            this.lblOrderBalance.Text = "0";
            this.lblOrderBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAvailableBalance
            // 
            this.lblAvailableBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableBalance.ForeColor = System.Drawing.Color.Red;
            this.lblAvailableBalance.Location = new System.Drawing.Point(1163, 17);
            this.lblAvailableBalance.Name = "lblAvailableBalance";
            this.lblAvailableBalance.Size = new System.Drawing.Size(171, 31);
            this.lblAvailableBalance.TabIndex = 7;
            this.lblAvailableBalance.Text = "0";
            this.lblAvailableBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(986, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "New Balance :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(986, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Order Balance :";
            // 
            // pbEmployeePicture
            // 
            this.pbEmployeePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbEmployeePicture.Image = ((System.Drawing.Image)(resources.GetObject("pbEmployeePicture.Image")));
            this.pbEmployeePicture.Location = new System.Drawing.Point(1408, 17);
            this.pbEmployeePicture.Name = "pbEmployeePicture";
            this.pbEmployeePicture.Size = new System.Drawing.Size(132, 136);
            this.pbEmployeePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEmployeePicture.TabIndex = 4;
            this.pbEmployeePicture.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "EPF :";
            // 
            // txtEPFNo
            // 
            // 
            // 
            // 
            this.txtEPFNo.CustomButton.Image = null;
            this.txtEPFNo.CustomButton.Location = new System.Drawing.Point(194, 2);
            this.txtEPFNo.CustomButton.Name = "";
            this.txtEPFNo.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtEPFNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEPFNo.CustomButton.TabIndex = 1;
            this.txtEPFNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEPFNo.CustomButton.UseSelectable = true;
            this.txtEPFNo.CustomButton.Visible = false;
            this.txtEPFNo.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtEPFNo.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtEPFNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtEPFNo.Lines = new string[0];
            this.txtEPFNo.Location = new System.Drawing.Point(8, 29);
            this.txtEPFNo.MaxLength = 10;
            this.txtEPFNo.Name = "txtEPFNo";
            this.txtEPFNo.PasswordChar = '\0';
            this.txtEPFNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEPFNo.SelectedText = "";
            this.txtEPFNo.SelectionLength = 0;
            this.txtEPFNo.SelectionStart = 0;
            this.txtEPFNo.ShortcutsEnabled = true;
            this.txtEPFNo.Size = new System.Drawing.Size(222, 30);
            this.txtEPFNo.TabIndex = 0;
            this.txtEPFNo.UseSelectable = true;
            this.txtEPFNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEPFNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
            this.txtEPFNo.TextChanged += new System.EventHandler(this.txtEPFNo_TextChanged);
            // 
            // gbCatagories
            // 
            this.gbCatagories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCatagories.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbCatagories.Controls.Add(this.flpCatagories);
            this.gbCatagories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCatagories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gbCatagories.Location = new System.Drawing.Point(23, 208);
            this.gbCatagories.Name = "gbCatagories";
            this.gbCatagories.Size = new System.Drawing.Size(196, 678);
            this.gbCatagories.TabIndex = 2;
            this.gbCatagories.TabStop = false;
            this.gbCatagories.Text = "CATAGORIES";
            // 
            // flpCatagories
            // 
            this.flpCatagories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpCatagories.AutoScroll = true;
            this.flpCatagories.Location = new System.Drawing.Point(0, 17);
            this.flpCatagories.Name = "flpCatagories";
            this.flpCatagories.Size = new System.Drawing.Size(196, 661);
            this.flpCatagories.TabIndex = 0;
            // 
            // gbItems
            // 
            this.gbItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbItems.Controls.Add(this.flpItems);
            this.gbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbItems.ForeColor = System.Drawing.Color.Blue;
            this.gbItems.Location = new System.Drawing.Point(225, 208);
            this.gbItems.Name = "gbItems";
            this.gbItems.Size = new System.Drawing.Size(370, 678);
            this.gbItems.TabIndex = 3;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "ITEMS";
            // 
            // flpItems
            // 
            this.flpItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpItems.AutoScroll = true;
            this.flpItems.Location = new System.Drawing.Point(0, 17);
            this.flpItems.Name = "flpItems";
            this.flpItems.Size = new System.Drawing.Size(372, 661);
            this.flpItems.TabIndex = 0;
            // 
            // gbKeyboard
            // 
            this.gbKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbKeyboard.Controls.Add(this.lblEnteredQty);
            this.gbKeyboard.Controls.Add(this.lblItem);
            this.gbKeyboard.Controls.Add(this.btnOne);
            this.gbKeyboard.Controls.Add(this.btnTwo);
            this.gbKeyboard.Controls.Add(this.btnClear);
            this.gbKeyboard.Controls.Add(this.btnThree);
            this.gbKeyboard.Controls.Add(this.btnEnter);
            this.gbKeyboard.Controls.Add(this.btnZero);
            this.gbKeyboard.Controls.Add(this.btnFour);
            this.gbKeyboard.Controls.Add(this.btnFive);
            this.gbKeyboard.Controls.Add(this.btnDot);
            this.gbKeyboard.Controls.Add(this.btnSix);
            this.gbKeyboard.Controls.Add(this.btnSeven);
            this.gbKeyboard.Controls.Add(this.btnNine);
            this.gbKeyboard.Controls.Add(this.btnEight);
            this.gbKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbKeyboard.ForeColor = System.Drawing.Color.Red;
            this.gbKeyboard.Location = new System.Drawing.Point(595, 208);
            this.gbKeyboard.Name = "gbKeyboard";
            this.gbKeyboard.Size = new System.Drawing.Size(321, 678);
            this.gbKeyboard.TabIndex = 4;
            this.gbKeyboard.TabStop = false;
            this.gbKeyboard.Text = "KEYBOARD";
            // 
            // lblEnteredQty
            // 
            this.lblEnteredQty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnteredQty.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblEnteredQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnteredQty.Location = new System.Drawing.Point(8, 115);
            this.lblEnteredQty.Name = "lblEnteredQty";
            this.lblEnteredQty.Size = new System.Drawing.Size(307, 109);
            this.lblEnteredQty.TabIndex = 13;
            this.lblEnteredQty.Text = "0";
            this.lblEnteredQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItem
            // 
            this.lblItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(8, 20);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(307, 95);
            this.lblItem.TabIndex = 23;
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOne
            // 
            this.btnOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOne.BackColor = System.Drawing.Color.PeachPuff;
            this.btnOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOne.Location = new System.Drawing.Point(8, 227);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(98, 86);
            this.btnOne.TabIndex = 1;
            this.btnOne.Text = "1";
            this.btnOne.UseVisualStyleBackColor = false;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // btnTwo
            // 
            this.btnTwo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTwo.BackColor = System.Drawing.Color.PeachPuff;
            this.btnTwo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTwo.Location = new System.Drawing.Point(112, 227);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(98, 86);
            this.btnTwo.TabIndex = 2;
            this.btnTwo.Text = "2";
            this.btnTwo.UseVisualStyleBackColor = false;
            this.btnTwo.Click += new System.EventHandler(this.btnTwo_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.PeachPuff;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(217, 503);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 86);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnThree
            // 
            this.btnThree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThree.BackColor = System.Drawing.Color.PeachPuff;
            this.btnThree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThree.Location = new System.Drawing.Point(216, 227);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(98, 86);
            this.btnThree.TabIndex = 3;
            this.btnThree.Text = "3";
            this.btnThree.UseVisualStyleBackColor = false;
            this.btnThree.Click += new System.EventHandler(this.btnThree_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.BackColor = System.Drawing.Color.PeachPuff;
            this.btnEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(8, 595);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(307, 73);
            this.btnEnter.TabIndex = 13;
            this.btnEnter.Text = "ENTER";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnZero
            // 
            this.btnZero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZero.BackColor = System.Drawing.Color.PeachPuff;
            this.btnZero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZero.Location = new System.Drawing.Point(113, 503);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(98, 86);
            this.btnZero.TabIndex = 11;
            this.btnZero.Text = "0";
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnFour
            // 
            this.btnFour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFour.BackColor = System.Drawing.Color.PeachPuff;
            this.btnFour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFour.Location = new System.Drawing.Point(8, 319);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(98, 86);
            this.btnFour.TabIndex = 4;
            this.btnFour.Text = "4";
            this.btnFour.UseVisualStyleBackColor = false;
            this.btnFour.Click += new System.EventHandler(this.btnFour_Click);
            // 
            // btnFive
            // 
            this.btnFive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFive.BackColor = System.Drawing.Color.PeachPuff;
            this.btnFive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFive.Location = new System.Drawing.Point(112, 319);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(98, 86);
            this.btnFive.TabIndex = 5;
            this.btnFive.Text = "5";
            this.btnFive.UseVisualStyleBackColor = false;
            this.btnFive.Click += new System.EventHandler(this.btnFive_Click);
            // 
            // btnDot
            // 
            this.btnDot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDot.BackColor = System.Drawing.Color.PeachPuff;
            this.btnDot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDot.Location = new System.Drawing.Point(8, 503);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(99, 86);
            this.btnDot.TabIndex = 10;
            this.btnDot.Text = ".";
            this.btnDot.UseVisualStyleBackColor = false;
            this.btnDot.Click += new System.EventHandler(this.btnDot_Click);
            // 
            // btnSix
            // 
            this.btnSix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSix.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSix.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSix.Location = new System.Drawing.Point(216, 319);
            this.btnSix.Name = "btnSix";
            this.btnSix.Size = new System.Drawing.Size(98, 86);
            this.btnSix.TabIndex = 6;
            this.btnSix.Text = "6";
            this.btnSix.UseVisualStyleBackColor = false;
            this.btnSix.Click += new System.EventHandler(this.btnSix_Click);
            // 
            // btnSeven
            // 
            this.btnSeven.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeven.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSeven.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeven.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeven.Location = new System.Drawing.Point(8, 411);
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Size = new System.Drawing.Size(98, 86);
            this.btnSeven.TabIndex = 7;
            this.btnSeven.Text = "7";
            this.btnSeven.UseVisualStyleBackColor = false;
            this.btnSeven.Click += new System.EventHandler(this.btnSeven_Click);
            // 
            // btnNine
            // 
            this.btnNine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNine.BackColor = System.Drawing.Color.PeachPuff;
            this.btnNine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNine.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNine.Location = new System.Drawing.Point(216, 411);
            this.btnNine.Name = "btnNine";
            this.btnNine.Size = new System.Drawing.Size(98, 86);
            this.btnNine.TabIndex = 9;
            this.btnNine.Text = "9";
            this.btnNine.UseVisualStyleBackColor = false;
            this.btnNine.Click += new System.EventHandler(this.btnNine_Click);
            // 
            // btnEight
            // 
            this.btnEight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEight.BackColor = System.Drawing.Color.PeachPuff;
            this.btnEight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEight.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEight.Location = new System.Drawing.Point(112, 411);
            this.btnEight.Name = "btnEight";
            this.btnEight.Size = new System.Drawing.Size(98, 86);
            this.btnEight.TabIndex = 8;
            this.btnEight.Text = "8";
            this.btnEight.UseVisualStyleBackColor = false;
            this.btnEight.Click += new System.EventHandler(this.btnEight_Click);
            // 
            // gbSelectedItems
            // 
            this.gbSelectedItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectedItems.Controls.Add(this.btnPurchase);
            this.gbSelectedItems.Controls.Add(this.gvSelectedItems);
            this.gbSelectedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSelectedItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gbSelectedItems.Location = new System.Drawing.Point(920, 208);
            this.gbSelectedItems.Name = "gbSelectedItems";
            this.gbSelectedItems.Size = new System.Drawing.Size(653, 678);
            this.gbSelectedItems.TabIndex = 5;
            this.gbSelectedItems.TabStop = false;
            this.gbSelectedItems.Text = "SELECTED ITEMS";
            // 
            // btnPurchase
            // 
            this.btnPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.Location = new System.Drawing.Point(13, 581);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(634, 91);
            this.btnPurchase.TabIndex = 24;
            this.btnPurchase.Text = "PURCHASE";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // gvSelectedItems
            // 
            this.gvSelectedItems.AllowUserToAddRows = false;
            this.gvSelectedItems.AllowUserToDeleteRows = false;
            this.gvSelectedItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSelectedItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSelectedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSelectedItems.Location = new System.Drawing.Point(13, 22);
            this.gvSelectedItems.Name = "gvSelectedItems";
            this.gvSelectedItems.ReadOnly = true;
            this.gvSelectedItems.RowHeadersVisible = false;
            this.gvSelectedItems.RowTemplate.Height = 24;
            this.gvSelectedItems.Size = new System.Drawing.Size(630, 553);
            this.gvSelectedItems.TabIndex = 0;
            this.gvSelectedItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSelectedItems_CellClick);
            // 
            // btnScreen
            // 
            this.btnScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScreen.ForeColor = System.Drawing.Color.Black;
            this.btnScreen.Location = new System.Drawing.Point(1233, -3);
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.Size = new System.Drawing.Size(124, 49);
            this.btnScreen.TabIndex = 6;
            this.btnScreen.Text = "SCREEN";
            this.btnScreen.UseVisualStyleBackColor = false;
            this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1431, -3);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(124, 49);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1028, -3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 49);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Date : ";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.Location = new System.Drawing.Point(92, 9);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(0, 20);
            this.lblClock.TabIndex = 10;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblUserEPF
            // 
            this.lblUserEPF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserEPF.AutoSize = true;
            this.lblUserEPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserEPF.Location = new System.Drawing.Point(460, 6);
            this.lblUserEPF.Name = "lblUserEPF";
            this.lblUserEPF.Size = new System.Drawing.Size(86, 20);
            this.lblUserEPF.TabIndex = 11;
            this.lblUserEPF.Text = "Cashier :";
            // 
            // lblCashierEpf
            // 
            this.lblCashierEpf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashierEpf.AutoSize = true;
            this.lblCashierEpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashierEpf.Location = new System.Drawing.Point(553, 6);
            this.lblCashierEpf.Name = "lblCashierEpf";
            this.lblCashierEpf.Size = new System.Drawing.Size(0, 20);
            this.lblCashierEpf.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(749, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Factory :";
            // 
            // lblCahierFactory
            // 
            this.lblCahierFactory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCahierFactory.AutoSize = true;
            this.lblCahierFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCahierFactory.Location = new System.Drawing.Point(839, 6);
            this.lblCahierFactory.Name = "lblCahierFactory";
            this.lblCahierFactory.Size = new System.Drawing.Size(0, 20);
            this.lblCahierFactory.TabIndex = 14;
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 909);
            this.Controls.Add(this.lblCahierFactory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCashierEpf);
            this.Controls.Add(this.lblUserEPF);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnScreen);
            this.Controls.Add(this.gbSelectedItems);
            this.Controls.Add(this.gbKeyboard);
            this.Controls.Add(this.gbItems);
            this.Controls.Add(this.gbCatagories);
            this.Controls.Add(this.gbEmployeeDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "POS";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.POS_Load);
            this.gbEmployeeDetails.ResumeLayout(false);
            this.gbEmployeeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmployeePicture)).EndInit();
            this.gbCatagories.ResumeLayout(false);
            this.gbItems.ResumeLayout(false);
            this.gbKeyboard.ResumeLayout(false);
            this.gbSelectedItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectedItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbEmployeeDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCatagories;
        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.GroupBox gbKeyboard;
        private System.Windows.Forms.GroupBox gbSelectedItems;
        private System.Windows.Forms.PictureBox pbEmployeePicture;
        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnNine;
        private System.Windows.Forms.Button btnEight;
        private System.Windows.Forms.Button btnSeven;
        private System.Windows.Forms.Button btnSix;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnFour;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblOrderBalance;
        private System.Windows.Forms.Label lblAvailableBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEpfNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.DataGridView gvSelectedItems;
        private System.Windows.Forms.Button btnScreen;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpItems;
        private System.Windows.Forms.FlowLayoutPanel flpCatagories;
        private System.Windows.Forms.Label lblEnteredQty;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblUserEPF;
        private System.Windows.Forms.Label lblCashierEpf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCahierFactory;
        private MetroFramework.Controls.MetroTextBox txtEPFNo;
    }
}

