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
    public partial class DataAnalyticsForm : Form
    {
        private SqlConnection connection;

        public DataAnalyticsForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=THANHLENOVO\\SQLEXPRESS;Initial Catalog=MedicalInventory;Integrated Security=True;Encrypt=False";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            string reportType = reportTypeComboBox.SelectedItem.ToString();
            DataTable dataTable = new DataTable();

            switch (reportType)
            {
                case "Patient Visits":
                    dataTable = GeneratePatientVisitsReport();
                    break;
                case "Common Ailments":
                    dataTable = GenerateCommonAilmentsReport();
                    break;
                case "Medication Usage":
                    dataTable = GenerateMedicationUsageReport();
                    break;
                default:
                    MessageBox.Show("Please select a valid report type.");
                    return;
            }

            analyticsGridView.DataSource = dataTable;
        }

        private DataTable GeneratePatientVisitsReport()
        {
            string query = @"
                SELECT p.Name, v.VisitDate, v.Diagnosis
                FROM Visits v
                JOIN Patients p ON v.PatientId = p.Id
                ORDER BY v.VisitDate DESC";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        private DataTable GenerateCommonAilmentsReport()
        {
            string query = @"
                SELECT v.Diagnosis, COUNT(*) AS Occurrences
                FROM Visits v
                GROUP BY v.Diagnosis
                ORDER BY Occurrences DESC";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        private DataTable GenerateMedicationUsageReport()
        {
            string query = @"
                SELECT m.Name, SUM(mu.QuantityUsed) AS TotalUsage
                FROM MedicationUsage mu
                JOIN Medications m ON mu.MedicationId = m.Id
                GROUP BY m.Name
                ORDER BY TotalUsage DESC";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
