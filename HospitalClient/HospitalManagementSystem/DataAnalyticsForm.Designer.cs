namespace HospitalManagementSystem
{
    partial class DataAnalyticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView analyticsGridView;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private System.Windows.Forms.Label reportTypeLabel;

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
            this.analyticsGridView = new System.Windows.Forms.DataGridView();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.reportTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.analyticsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // analyticsGridView
            // 
            this.analyticsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.analyticsGridView.Location = new System.Drawing.Point(12, 51);
            this.analyticsGridView.Name = "analyticsGridView";
            this.analyticsGridView.RowHeadersWidth = 102;
            this.analyticsGridView.Size = new System.Drawing.Size(760, 200);
            this.analyticsGridView.TabIndex = 0;
            // 
            // generateReportButton
            // 
            this.generateReportButton.Location = new System.Drawing.Point(697, 257);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(75, 23);
            this.generateReportButton.TabIndex = 1;
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.UseVisualStyleBackColor = true;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
            // 
            // reportTypeComboBox
            // 
            this.reportTypeComboBox.FormattingEnabled = true;
            this.reportTypeComboBox.Items.AddRange(new object[] {
            "Patient Visits",
            "Common Ailments",
            "Medication Usage"});
            this.reportTypeComboBox.Location = new System.Drawing.Point(87, 12);
            this.reportTypeComboBox.Name = "reportTypeComboBox";
            this.reportTypeComboBox.Size = new System.Drawing.Size(200, 39);
            this.reportTypeComboBox.TabIndex = 2;
            // 
            // reportTypeLabel
            // 
            this.reportTypeLabel.AutoSize = true;
            this.reportTypeLabel.Location = new System.Drawing.Point(12, 15);
            this.reportTypeLabel.Name = "reportTypeLabel";
            this.reportTypeLabel.Size = new System.Drawing.Size(177, 32);
            this.reportTypeLabel.TabIndex = 3;
            this.reportTypeLabel.Text = "Report Type:";
            // 
            // DataAnalyticsForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 291);
            this.Controls.Add(this.reportTypeLabel);
            this.Controls.Add(this.reportTypeComboBox);
            this.Controls.Add(this.generateReportButton);
            this.Controls.Add(this.analyticsGridView);
            this.Name = "DataAnalyticsForm";
            this.Text = "Data Analytics";
            ((System.ComponentModel.ISupportInitialize)(this.analyticsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

    #endregion
}