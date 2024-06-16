namespace HospitalManagementSystem
{
    partial class RealTimeCommunicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage chatTabPage;
        private System.Windows.Forms.TabPage patientMonitoringTabPage;
        private System.Windows.Forms.TabPage dashboardTabPage;
        private System.Windows.Forms.TextBox chatMessageTextBox;
        private System.Windows.Forms.Button chatSendButton;
        private System.Windows.Forms.ListBox chatListBox;
        private System.Windows.Forms.TextBox chatUserTextBox;
        private System.Windows.Forms.DataGridView patientVitalsGridView;
        private System.Windows.Forms.DataGridView dashboardGridView;

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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.chatTabPage = new System.Windows.Forms.TabPage();
            this.patientMonitoringTabPage = new System.Windows.Forms.TabPage();
            this.dashboardTabPage = new System.Windows.Forms.TabPage();
            this.chatMessageTextBox = new System.Windows.Forms.TextBox();
            this.chatSendButton = new System.Windows.Forms.Button();
            this.chatListBox = new System.Windows.Forms.ListBox();
            this.chatUserTextBox = new System.Windows.Forms.TextBox();
            this.patientVitalsGridView = new System.Windows.Forms.DataGridView();
            this.dashboardGridView = new System.Windows.Forms.DataGridView();

            this.tabControl.SuspendLayout();
            this.chatTabPage.SuspendLayout();
            this.patientMonitoringTabPage.SuspendLayout();
            this.dashboardTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientVitalsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardGridView)).BeginInit();
            this.SuspendLayout();

            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.chatTabPage);
            this.tabControl.Controls.Add(this.patientMonitoringTabPage);
            this.tabControl.Controls.Add(this.dashboardTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 437);
            this.tabControl.TabIndex = 0;
            // 
            // chatTabPage
            // 
            this.chatTabPage.Controls.Add(this.chatMessageTextBox);
            this.chatTabPage.Controls.Add(this.chatSendButton);
            this.chatTabPage.Controls.Add(this.chatListBox);
            this.chatTabPage.Controls.Add(this.chatUserTextBox);
            this.chatTabPage.Location = new System.Drawing.Point(4, 22);
            this.chatTabPage.Name = "chatTabPage";
            this.chatTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.chatTabPage.Size = new System.Drawing.Size(752, 411);
            this.chatTabPage.TabIndex = 0;
            this.chatTabPage.Text = "Chat";
            this.chatTabPage.UseVisualStyleBackColor = true;
            // 
            // chatMessageTextBox
            // 
            this.chatMessageTextBox.Location = new System.Drawing.Point(6, 375);
            this.chatMessageTextBox.Name = "chatMessageTextBox";
            this.chatMessageTextBox.Size = new System.Drawing.Size(660, 20);
            this.chatMessageTextBox.TabIndex = 0;
            // 
            // chatSendButton
            // 
            this.chatSendButton.Location = new System.Drawing.Point(672, 373);
            this.chatSendButton.Name = "chatSendButton";
            this.chatSendButton.Size = new System.Drawing.Size(75, 23);
            this.chatSendButton.TabIndex = 1;
            this.chatSendButton.Text = "Send";
            this.chatSendButton.UseVisualStyleBackColor = true;
            this.chatSendButton.Click += new System.EventHandler(this.chatSendButton_Click);
            // 
            // chatListBox
            // 
            this.chatListBox.FormattingEnabled = true;
            this.chatListBox.Location = new System.Drawing.Point(6, 6);
            this.chatListBox.Name = "chatListBox";
            this.chatListBox.Size = new System.Drawing.Size(741, 355);
            this.chatListBox.TabIndex = 2;
            // 
            // chatUserTextBox
            // 
            this.chatUserTextBox.Location = new System.Drawing.Point(6, 349);
            this.chatUserTextBox.Name = "chatUserTextBox";
            this.chatUserTextBox.Size = new System.Drawing.Size(200, 20);
            this.chatUserTextBox.TabIndex = 3;
            // 
            // patientMonitoringTabPage
            // 
            this.patientMonitoringTabPage.Controls.Add(this.patientVitalsGridView);
            this.patientMonitoringTabPage.Location = new System.Drawing.Point(4, 22);
            this.patientMonitoringTabPage.Name = "patientMonitoringTabPage";
            this.patientMonitoringTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.patientMonitoringTabPage.Size = new System.Drawing.Size(752, 411);
            this.patientMonitoringTabPage.TabIndex = 1;
            this.patientMonitoringTabPage.Text = "Patient Monitoring";
            this.patientMonitoringTabPage.UseVisualStyleBackColor = true;
            // 
            // patientVitalsGridView
            // 
            this.patientVitalsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientVitalsGridView.Location = new System.Drawing.Point(6, 6);
            this.patientVitalsGridView.Name = "patientVitalsGridView";
            this.patientVitalsGridView.Size = new System.Drawing.Size(740, 399);
            this.patientVitalsGridView.TabIndex = 0;
            // 
            // dashboardTabPage
            // 
            this.dashboardTabPage.Controls.Add(this.dashboardGridView);
            this.dashboardTabPage.Location = new System.Drawing.Point(4, 22);
            this.dashboardTabPage.Name = "dashboardTabPage";
            this.dashboardTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.dashboardTabPage.Size = new System.Drawing.Size(752, 411);
            this.dashboardTabPage.TabIndex = 2;
            this.dashboardTabPage.Text = "Dashboard";
            this.dashboardTabPage.UseVisualStyleBackColor = true;
            // 
            // dashboardGridView
            // 
            this.dashboardGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dashboardGridView.Location = new System.Drawing.Point(6, 6);
            this.dashboardGridView.Name = "dashboardGridView";
            this.dashboardGridView.Size = new System.Drawing.Size(740, 399);
            this.dashboardGridView.TabIndex = 0;
            // 
            // RealTimeCommunicationForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl);
            this.Name = "RealTimeCommunicationForm";
            this.Text = "Real-Time Communication";

            this.tabControl.ResumeLayout(false);
            this.chatTabPage.ResumeLayout(false);
            this.chatTabPage.PerformLayout();
            this.patientMonitoringTabPage.ResumeLayout(false);
            this.dashboardTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientVitalsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}