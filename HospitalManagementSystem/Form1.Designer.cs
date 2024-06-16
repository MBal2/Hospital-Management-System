namespace HospitalManagementSystem
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_patientManagement = new System.Windows.Forms.Button();
            this.button_inventoryManagement = new System.Windows.Forms.Button();
            this.button_dataAnalytics = new System.Windows.Forms.Button();
            this.button_appointmentScheduling = new System.Windows.Forms.Button();
            this.button_communicationUpdates = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(114, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hospital Management System";
            // 
            // button_patientManagement
            // 
            this.button_patientManagement.Location = new System.Drawing.Point(110, 162);
            this.button_patientManagement.Name = "button_patientManagement";
            this.button_patientManagement.Size = new System.Drawing.Size(140, 60);
            this.button_patientManagement.TabIndex = 1;
            this.button_patientManagement.Text = "Patient Management";
            this.button_patientManagement.UseVisualStyleBackColor = true;
            this.button_patientManagement.Click += new System.EventHandler(this.button_patientManagement_Click);
            // 
            // button_inventoryManagement
            // 
            this.button_inventoryManagement.Location = new System.Drawing.Point(279, 223);
            this.button_inventoryManagement.Name = "button_inventoryManagement";
            this.button_inventoryManagement.Size = new System.Drawing.Size(140, 60);
            this.button_inventoryManagement.TabIndex = 2;
            this.button_inventoryManagement.Text = "Medical Inventory Management";
            this.button_inventoryManagement.UseVisualStyleBackColor = true;
            this.button_inventoryManagement.Click += new System.EventHandler(this.button_inventoryManagement_Click);
            // 
            // button_dataAnalytics
            // 
            this.button_dataAnalytics.Location = new System.Drawing.Point(444, 161);
            this.button_dataAnalytics.Name = "button_dataAnalytics";
            this.button_dataAnalytics.Size = new System.Drawing.Size(140, 60);
            this.button_dataAnalytics.TabIndex = 3;
            this.button_dataAnalytics.Text = "Data Analytics";
            this.button_dataAnalytics.UseVisualStyleBackColor = true;
            this.button_dataAnalytics.Click += new System.EventHandler(this.button_dataAnalytics_Click);
            // 
            // button_appointmentScheduling
            // 
            this.button_appointmentScheduling.Location = new System.Drawing.Point(109, 282);
            this.button_appointmentScheduling.Name = "button_appointmentScheduling";
            this.button_appointmentScheduling.Size = new System.Drawing.Size(140, 60);
            this.button_appointmentScheduling.TabIndex = 4;
            this.button_appointmentScheduling.Text = "Appointment Scheduling";
            this.button_appointmentScheduling.UseVisualStyleBackColor = true;
            this.button_appointmentScheduling.Click += new System.EventHandler(this.button_appointmentScheduling_Click);
            // 
            // button_communicationUpdates
            // 
            this.button_communicationUpdates.Location = new System.Drawing.Point(444, 281);
            this.button_communicationUpdates.Name = "button_communicationUpdates";
            this.button_communicationUpdates.Size = new System.Drawing.Size(140, 60);
            this.button_communicationUpdates.TabIndex = 5;
            this.button_communicationUpdates.Text = "Real-time Communication and Updates";
            this.button_communicationUpdates.UseVisualStyleBackColor = true;
            this.button_communicationUpdates.Click += new System.EventHandler(this.button_communicationUpdates_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_communicationUpdates);
            this.Controls.Add(this.button_appointmentScheduling);
            this.Controls.Add(this.button_dataAnalytics);
            this.Controls.Add(this.button_inventoryManagement);
            this.Controls.Add(this.button_patientManagement);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_patientManagement;
        private System.Windows.Forms.Button button_inventoryManagement;
        private System.Windows.Forms.Button button_dataAnalytics;
        private System.Windows.Forms.Button button_appointmentScheduling;
        private System.Windows.Forms.Button button_communicationUpdates;
    }
}

