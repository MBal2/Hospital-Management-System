using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using System.Data.SqlClient;
using HubConnection = Microsoft.AspNetCore.SignalR.Client.HubConnection;

namespace HospitalManagementSystem
{
    public partial class RealTimeCommunicationForm : Form
    {
        private SqlConnection connection;
        private HubConnection hubConnection;

        public RealTimeCommunicationForm()
        {
            InitializeComponent();
            InitializeSignalR();
            InitializeDatabaseConnection();
            InitializeGridColumns();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MedicalInventory;Integrated Security=True;Encrypt=False";
            connection = new SqlConnection(connectionString);
        }

            private async void InitializeSignalR()
        {
            hubConnection = new HubConnectionBuilder()
               .WithUrl("http://localhost:5139/inventoryHub")
               .Build();
            hubConnection.On<string, string>("SendMessage", (user, message) =>
            {
                this.Invoke((Action)(() =>
                {
                    chatListBox.Items.Add($"{user}: {message}");
                }));
            });

            hubConnection.On<string, string>("ReceivePatientVitals", (patientId, vitals) =>
            {
                this.Invoke((Action)(() =>
                {
                    UpdatePatientVitalsGrid();
                }));
            });

            hubConnection.On<string>("UpdateDashboard", (data) =>
            {
                this.Invoke((Action)(() =>
                {
                    UpdateDashboardGrid();
                }));
            });

            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void InitializeGridColumns()
        {
            this.patientVitalsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "PatientId", HeaderText = "Patient ID" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "PatientName", HeaderText = "Patient Name" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Timestamp", HeaderText = "Timestamp" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Vitals", HeaderText = "Vitals" }
            });

            this.dashboardGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "BedId", HeaderText = "Bed ID" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Emergency", HeaderText = "Emergency" }
            });
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the "Patient Monitoring" tab is active
            if (tabControl.SelectedTab == patientMonitoringTabPage)
            {
                UpdatePatientVitalsGrid();
            }
            else if (tabControl.SelectedTab == dashboardTabPage)
            {
                UpdateDashboardGrid();
            }
        }

        private void UpdatePatientVitalsGrid()
        {
            try
            {
                string query = @"
            SELECT pv.PatientId, p.Name AS PatientName, pv.Timestamp, pv.Vitals
            FROM PatientVitals pv
            JOIN Patients p ON pv.PatientId = p.Id";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                patientVitalsGridView.Rows.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    patientVitalsGridView.Rows.Add(row["PatientId"], row["PatientName"], row["Timestamp"], row["Vitals"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating patient vitals: {ex.Message}");
            }
        }

        private void UpdateDashboardGrid()
        {
            try
            {
                string query = "SELECT BedId, Status, Emergency FROM Dashboard";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dashboardGridView.Rows.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    dashboardGridView.Rows.Add(row["BedId"], row["Status"], row["Emergency"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating dashboard: {ex.Message}");
            }
        }

        private async void chatSendButton_Click(object sender, EventArgs e)
        {
            string user = chatUserTextBox.Text;
            string message = chatMessageTextBox.Text;

            try
            {
                await hubConnection.InvokeAsync("SendMessage", user, message);
                chatMessageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
