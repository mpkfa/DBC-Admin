namespace DBC_Admin
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
            this.lstListBox = new System.Windows.Forms.ListBox();
            this.lblDatabases = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lstData = new System.Windows.Forms.ListView();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstListBox
            // 
            this.lstListBox.FormattingEnabled = true;
            this.lstListBox.ItemHeight = 16;
            this.lstListBox.Location = new System.Drawing.Point(12, 34);
            this.lstListBox.Name = "lstListBox";
            this.lstListBox.Size = new System.Drawing.Size(222, 404);
            this.lstListBox.TabIndex = 0;
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
            this.lblData.Location = new System.Drawing.Point(255, 9);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(36, 16);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Data";
            // 
            // lstData
            // 
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(258, 34);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(530, 404);
            this.lstData.TabIndex = 3;
            this.lstData.UseCompatibleStateImageBehavior = false;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(15, 444);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(159, 444);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblDatabases);
            this.Controls.Add(this.lstListBox);
            this.Name = "MainForm";
            this.Text = "CAN Databases Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstListBox;
        private System.Windows.Forms.Label lblDatabases;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDelete;
    }
}

