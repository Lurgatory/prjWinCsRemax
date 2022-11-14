
namespace prjWinCsRemaxWindowsApp.GUI
{
    partial class frmSearchAgent
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboAgent = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.rdbAllAgent = new System.Windows.Forms.RadioButton();
            this.rdbAgentNumber = new System.Windows.Forms.RadioButton();
            this.gridAgent = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.cboAgent);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.rdbAllAgent);
            this.groupBox1.Controls.Add(this.rdbAgentNumber);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(30, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 245);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Agent";
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
            // cboAgent
            // 
            this.cboAgent.FormattingEnabled = true;
            this.cboAgent.Location = new System.Drawing.Point(327, 77);
            this.cboAgent.Name = "cboAgent";
            this.cboAgent.Size = new System.Drawing.Size(259, 27);
            this.cboAgent.TabIndex = 3;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(617, 77);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(129, 43);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // rdbAllAgent
            // 
            this.rdbAllAgent.AutoSize = true;
            this.rdbAllAgent.Location = new System.Drawing.Point(25, 138);
            this.rdbAllAgent.Name = "rdbAllAgent";
            this.rdbAllAgent.Size = new System.Drawing.Size(203, 23);
            this.rdbAllAgent.TabIndex = 1;
            this.rdbAllAgent.TabStop = true;
            this.rdbAllAgent.Text = "Search All Agent";
            this.rdbAllAgent.UseVisualStyleBackColor = true;
            this.rdbAllAgent.CheckedChanged += new System.EventHandler(this.rdbAllAgent_CheckedChanged);
            // 
            // rdbAgentNumber
            // 
            this.rdbAgentNumber.AutoSize = true;
            this.rdbAgentNumber.Location = new System.Drawing.Point(25, 77);
            this.rdbAgentNumber.Name = "rdbAgentNumber";
            this.rdbAgentNumber.Size = new System.Drawing.Size(269, 23);
            this.rdbAgentNumber.TabIndex = 0;
            this.rdbAgentNumber.TabStop = true;
            this.rdbAgentNumber.Text = "Search by Agent Number";
            this.rdbAgentNumber.UseVisualStyleBackColor = true;
            this.rdbAgentNumber.CheckedChanged += new System.EventHandler(this.rdbAgentNumber_CheckedChanged);
            // 
            // gridAgent
            // 
            this.gridAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAgent.Location = new System.Drawing.Point(30, 273);
            this.gridAgent.Name = "gridAgent";
            this.gridAgent.RowTemplate.Height = 23;
            this.gridAgent.Size = new System.Drawing.Size(790, 339);
            this.gridAgent.TabIndex = 2;
            // 
            // frmSearchAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridAgent);
            this.Name = "frmSearchAgent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSearchAgent";
            this.Load += new System.EventHandler(this.frmSearchAgent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAgent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboAgent;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.RadioButton rdbAllAgent;
        private System.Windows.Forms.RadioButton rdbAgentNumber;
        private System.Windows.Forms.DataGridView gridAgent;
    }
}