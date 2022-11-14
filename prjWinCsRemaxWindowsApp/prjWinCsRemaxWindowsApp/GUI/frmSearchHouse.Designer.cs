
namespace prjWinCsRemaxWindowsApp.GUI
{
    partial class frmSearchHouse
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
            this.gridHouse = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboHouse = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rdbAllHouse = new System.Windows.Forms.RadioButton();
            this.rdbHouseNumber = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridHouse)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridHouse
            // 
            this.gridHouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHouse.Location = new System.Drawing.Point(87, 272);
            this.gridHouse.Name = "gridHouse";
            this.gridHouse.RowTemplate.Height = 23;
            this.gridHouse.Size = new System.Drawing.Size(790, 339);
            this.gridHouse.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.cboHouse);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rdbAllHouse);
            this.groupBox1.Controls.Add(this.rdbHouseNumber);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(87, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 245);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search House";
            // 
            // cboHouse
            // 
            this.cboHouse.FormattingEnabled = true;
            this.cboHouse.Location = new System.Drawing.Point(327, 77);
            this.cboHouse.Name = "cboHouse";
            this.cboHouse.Size = new System.Drawing.Size(259, 27);
            this.cboHouse.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(617, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdbAllHouse
            // 
            this.rdbAllHouse.AutoSize = true;
            this.rdbAllHouse.Location = new System.Drawing.Point(25, 138);
            this.rdbAllHouse.Name = "rdbAllHouse";
            this.rdbAllHouse.Size = new System.Drawing.Size(203, 23);
            this.rdbAllHouse.TabIndex = 1;
            this.rdbAllHouse.TabStop = true;
            this.rdbAllHouse.Text = "Search All House";
            this.rdbAllHouse.UseVisualStyleBackColor = true;
            this.rdbAllHouse.CheckedChanged += new System.EventHandler(this.rdbAllHouse_CheckedChanged);
            // 
            // rdbHouseNumber
            // 
            this.rdbHouseNumber.AutoSize = true;
            this.rdbHouseNumber.Location = new System.Drawing.Point(25, 77);
            this.rdbHouseNumber.Name = "rdbHouseNumber";
            this.rdbHouseNumber.Size = new System.Drawing.Size(269, 23);
            this.rdbHouseNumber.TabIndex = 0;
            this.rdbHouseNumber.TabStop = true;
            this.rdbHouseNumber.Text = "Search by House Number";
            this.rdbHouseNumber.UseVisualStyleBackColor = true;
            this.rdbHouseNumber.CheckedChanged += new System.EventHandler(this.rdbHouseNumber_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(617, 149);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 43);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSearchHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 623);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridHouse);
            this.Name = "frmSearchHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSearchHouse";
            this.Load += new System.EventHandler(this.frmSearchHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridHouse)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridHouse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboHouse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdbAllHouse;
        private System.Windows.Forms.RadioButton rdbHouseNumber;
        private System.Windows.Forms.Button btnClose;
    }
}