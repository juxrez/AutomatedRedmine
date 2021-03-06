﻿namespace Redmine_for_dummies
{
    partial class MainWindow
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
            this.btnCredentials = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.chkBoxEdit = new System.Windows.Forms.CheckBox();
            this.btnTFS = new System.Windows.Forms.Button();
            this.btnGetTeams = new System.Windows.Forms.Button();
            this.comboProjects = new System.Windows.Forms.ComboBox();
            this.comboTeams = new System.Windows.Forms.ComboBox();
            this.btnToken = new System.Windows.Forms.Button();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.menuStripManageRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStripManageRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCredentials
            // 
            this.btnCredentials.Enabled = false;
            this.btnCredentials.Location = new System.Drawing.Point(420, 338);
            this.btnCredentials.Name = "btnCredentials";
            this.btnCredentials.Size = new System.Drawing.Size(75, 23);
            this.btnCredentials.TabIndex = 0;
            this.btnCredentials.Text = "Log Time";
            this.btnCredentials.UseVisualStyleBackColor = true;
            this.btnCredentials.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(108, 338);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(75, 23);
            this.Data.TabIndex = 6;
            this.Data.Text = "Import File";
            this.Data.UseVisualStyleBackColor = true;
            this.Data.Click += new System.EventHandler(this.Data_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.Enabled = false;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView.Location = new System.Drawing.Point(64, 133);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(563, 199);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDown);
            this.dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserDeletedRow);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "json";
            this.openFileDialog.Filter = "Json files (*.json)|*.json";
            this.openFileDialog.Title = "Open File";
            // 
            // chkBoxEdit
            // 
            this.chkBoxEdit.AutoSize = true;
            this.chkBoxEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkBoxEdit.Location = new System.Drawing.Point(64, 110);
            this.chkBoxEdit.Name = "chkBoxEdit";
            this.chkBoxEdit.Size = new System.Drawing.Size(44, 17);
            this.chkBoxEdit.TabIndex = 9;
            this.chkBoxEdit.Text = "Edit";
            this.chkBoxEdit.UseVisualStyleBackColor = true;
            this.chkBoxEdit.CheckedChanged += new System.EventHandler(this.chkBoxEdit_CheckedChanged);
            // 
            // btnTFS
            // 
            this.btnTFS.Location = new System.Drawing.Point(420, 71);
            this.btnTFS.Name = "btnTFS";
            this.btnTFS.Size = new System.Drawing.Size(75, 23);
            this.btnTFS.TabIndex = 10;
            this.btnTFS.Text = "TFS";
            this.btnTFS.UseVisualStyleBackColor = true;
            this.btnTFS.Click += new System.EventHandler(this.btnTFS_Click);
            // 
            // btnGetTeams
            // 
            this.btnGetTeams.Enabled = false;
            this.btnGetTeams.Location = new System.Drawing.Point(189, 71);
            this.btnGetTeams.Name = "btnGetTeams";
            this.btnGetTeams.Size = new System.Drawing.Size(75, 23);
            this.btnGetTeams.TabIndex = 12;
            this.btnGetTeams.Text = "Get Teams";
            this.btnGetTeams.UseVisualStyleBackColor = true;
            this.btnGetTeams.Click += new System.EventHandler(this.btnGetTeams_Click);
            // 
            // comboProjects
            // 
            this.comboProjects.FormattingEnabled = true;
            this.comboProjects.Location = new System.Drawing.Point(62, 73);
            this.comboProjects.Name = "comboProjects";
            this.comboProjects.Size = new System.Drawing.Size(121, 21);
            this.comboProjects.TabIndex = 14;
            this.comboProjects.DataSourceChanged += new System.EventHandler(this.comboProjects_DataSourceChanged);
            // 
            // comboTeams
            // 
            this.comboTeams.FormattingEnabled = true;
            this.comboTeams.Location = new System.Drawing.Point(293, 73);
            this.comboTeams.Name = "comboTeams";
            this.comboTeams.Size = new System.Drawing.Size(121, 21);
            this.comboTeams.TabIndex = 16;
            // 
            // btnToken
            // 
            this.btnToken.Location = new System.Drawing.Point(420, 34);
            this.btnToken.Name = "btnToken";
            this.btnToken.Size = new System.Drawing.Size(75, 23);
            this.btnToken.TabIndex = 15;
            this.btnToken.Text = "Set Token";
            this.btnToken.UseVisualStyleBackColor = true;
            this.btnToken.Click += new System.EventHandler(this.btnToken_Click);
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(62, 34);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(352, 20);
            this.txtToken.TabIndex = 17;
            // 
            // menuStripManageRow
            // 
            this.menuStripManageRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.menuStripManageRow.Name = "menuStripManageRow";
            this.menuStripManageRow.Size = new System.Drawing.Size(153, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 414);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.comboTeams);
            this.Controls.Add(this.btnToken);
            this.Controls.Add(this.comboProjects);
            this.Controls.Add(this.btnGetTeams);
            this.Controls.Add(this.btnTFS);
            this.Controls.Add(this.chkBoxEdit);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.btnCredentials);
            this.Name = "MainWindow";
            this.Text = "Log Redmine Time";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStripManageRow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCredentials;
        private System.Windows.Forms.Button Data;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox chkBoxEdit;
        private System.Windows.Forms.Button btnTFS;
        private System.Windows.Forms.Button btnGetTeams;
        private System.Windows.Forms.ComboBox comboProjects;
        private System.Windows.Forms.ComboBox comboTeams;
        private System.Windows.Forms.Button btnToken;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.ContextMenuStrip menuStripManageRow;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

