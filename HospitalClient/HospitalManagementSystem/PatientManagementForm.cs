using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class PatientManagementForm : Form
    {
        public PatientManagementForm()
        {
            InitializeComponent();
        }
        
        private void PatientManagementForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medicalInventoryDataSet1.Patients' table. You can move, or remove it, as needed.
            this.patientsTableAdapter.Fill(this.medicalInventoryDataSet1.Patients);
            comboBox_gender.Items.Clear();
            comboBox_gender.Items.Add("Male");
            comboBox_gender.Items.Add("Female");
            comboBox_gender.SelectedIndex = 0;
            GridView.Columns[0].ReadOnly = true;
            gridCombobox();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            string name = (string)textBox_name.Text;
            string gender = (string)comboBox_gender.Text;
            DateTime date = DateTime.Parse(dateTimePicker1.Text);

            MedicalInventoryDataSet.PatientsRow newPatientsRow = 
                medicalInventoryDataSet1.Patients.NewPatientsRow();
            newPatientsRow.Name = name;
            newPatientsRow.Gender = gender;
            newPatientsRow.DateOfBirth = date;
            
            medicalInventoryDataSet1.Patients.Rows.Add(newPatientsRow);
            this.patientsTableAdapter.Update(this.medicalInventoryDataSet1.Patients);
            
            medicalInventoryDataSet1.AcceptChanges();


        }

        private void button_update_Click(object sender, EventArgs e)
        {               
            this.patientsTableAdapter.Update(this.medicalInventoryDataSet1.Patients);
            medicalInventoryDataSet1.AcceptChanges();

        }

        private void gridCombobox() 
        {
            /// Create a DataGridViewComboBoxColumn for Gender column
            DataGridViewComboBoxColumn genderColumn = new DataGridViewComboBoxColumn();
            genderColumn.HeaderText = "Gender";
            genderColumn.DataPropertyName = "Gender"; 
            genderColumn.Name = "comboBoxGenderColumn"; 
            
            genderColumn.Items.AddRange("Male", "Female");

            
            int columnIndex = 3; // Find the index of the existing "Gender" column
            GridView.Columns.RemoveAt(columnIndex); // Remove the existing column
            GridView.Columns.Insert(columnIndex, genderColumn); // Insert the combo box column at the same index

            
            GridView.Refresh();


        }

        private void button_delete_Click(object sender, EventArgs e)
        {

            // Get the ID of the selected row
            int id = (int)GridView.SelectedRows[0].Cells[0].Value;

            // Find the corresponding DataRow in the DataSet
            MedicalInventoryDataSet.PatientsRow rowToDelete = medicalInventoryDataSet1.Patients.FindById(id);


            // Delete the row from the DataSet
            rowToDelete.Delete();

            // Update the database to reflect the changes
            this.patientsTableAdapter.Update(medicalInventoryDataSet1.Patients);

            
            medicalInventoryDataSet1.AcceptChanges();

            
            MessageBox.Show("Row deleted successfully.");
        }
    }
}
