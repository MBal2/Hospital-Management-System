using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class AppointmentSchedulingForm : Form
    {
        public AppointmentSchedulingForm()
        {
            InitializeComponent();
        }

        private void AppointmentSchedulingForm_Load(object sender, EventArgs e)
        {
            
            this.appointmentsTableAdapter.Fill(this.medicalInventoryDataSet.Appointments);
            
            this.visitsTableAdapter.Fill(this.medicalInventoryDataSet.Visits);

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string reason = (string)textBox_reason.Text;
            string status = (string)textBox_status.Text;
            DateTime date = DateTime.Parse(dateTimePicker1.Text);

            MedicalInventoryDataSet.AppointmentsRow newAppointmentsRow =
                medicalInventoryDataSet.Appointments.NewAppointmentsRow();
            
            newAppointmentsRow.Reason = reason;
            newAppointmentsRow.Status = status;
            newAppointmentsRow.AppointmentDate = date;

            medicalInventoryDataSet.Appointments.Rows.Add(newAppointmentsRow);
            this.appointmentsTableAdapter.Update(this.medicalInventoryDataSet.Appointments);

            medicalInventoryDataSet.AcceptChanges();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            // Get the ID of the selected row
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            // Find the corresponding DataRow in the DataSet
            MedicalInventoryDataSet.AppointmentsRow rowToDelete = medicalInventoryDataSet.Appointments.FindById(id);


            // Delete the row from the DataSet
            rowToDelete.Delete();

            // Update the database to reflect the changes
            this.appointmentsTableAdapter.Update(medicalInventoryDataSet.Appointments);


            medicalInventoryDataSet.AcceptChanges();


            MessageBox.Show("Appointment canceled.");
        }
        
    }
}
