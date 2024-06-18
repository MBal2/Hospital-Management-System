using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class Form1 : Form
    {
        public Users user;
        public Form1()
        {
            InitializeComponent();
        }
        public void SetUser(Users u)
        {
            user = u;
        }

        private void button_patientManagement_Click(object sender, EventArgs e)
        {
             PatientManagementForm patientManagementForm = new PatientManagementForm();
             patientManagementForm.Show();
        }

        private void button_appointmentScheduling_Click(object sender, EventArgs e)
        {
             AppointmentSchedulingForm appointmentSchedulingForm = new AppointmentSchedulingForm();
             appointmentSchedulingForm.Show();
        }

        private void button_inventoryManagement_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryManagementForm = new InventoryForm();
            inventoryManagementForm.Show();
        }

        private void button_dataAnalytics_Click(object sender, EventArgs e)
        {
            DataAnalyticsForm dataAnalyticsForm = new DataAnalyticsForm();
            dataAnalyticsForm.Show();
        }

        private void button_communicationUpdates_Click(object sender, EventArgs e)
        {
            RealTimeCommunicationForm realTimeCommunicationForm = new RealTimeCommunicationForm();
            realTimeCommunicationForm.Show();
        }

    }
}
