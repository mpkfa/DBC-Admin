namespace CanDbcAdmin
{
    partial class MainForm
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
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.lblDatabases = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstDatabases
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFiles.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.IntegralHeight = false;
            this.lstFiles.ItemHeight = 20;
            this.lstFiles.Location = new System.Drawing.Point(12, 34);
            this.lstFiles.Name = "lstDatabases";
            this.lstFiles.Size = new System.Drawing.Size(265, 490);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstDatabases_SelectedIndexChanged);
            // 
            // lblDatabases
            // 
            this.lblDatabases.AutoSize = true;
            this.lblDatabases.Location = new System.Drawing.Point(12, 9);
            this.lblDatabases.Name = "lblDatabases";
            this.lblDatabases.Size = new System.Drawing.Size(74, 16);
            this.lblDatabases.TabIndex = 1;
            this.lblDatabases.Text = "Databases";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(280, 9);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(36, 16);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Data";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.Location = new System.Drawing.Point(15, 530);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 26);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(202, 530);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "CAN database files (*.dbc)|*.dbc";
            this.openFileDialog.Title = "Open CAN database file";
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstItems.FormattingEnabled = true;
            this.lstItems.IntegralHeight = false;
            this.lstItems.ItemHeight = 20;
            this.lstItems.Location = new System.Drawing.Point(283, 34);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(885, 490);
            this.lstItems.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 568);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblDatabases);
            this.Controls.Add(this.lstFiles);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAN Databases Admin";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Label lblDatabases;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox lstItems;
    }
}

