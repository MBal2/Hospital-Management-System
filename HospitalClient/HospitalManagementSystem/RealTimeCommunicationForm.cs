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

namespace HospitalManagementSystem
{
    public partial class RealTimeCommunicationForm : Form
    {
        private HubConnection hubConnection;

        public RealTimeCommunicationForm()
        {
            InitializeComponent();
            InitializeSignalR();
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
                    UpdatePatientVitalsGrid(patientId, vitals);
                }));
            });

            hubConnection.On<string>("UpdateDashboard", (data) =>
            {
                this.Invoke((Action)(() =>
                {
                    UpdateDashboardGrid(data);
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

        private void UpdatePatientVitalsGrid(string patientId, string vitals)
        {
            try
            {
                var vitalsData = JsonSerializer.Deserialize<PatientVitals>(vitals);

                // Check if the patient already exists in the grid
                var existingRow = patientVitalsGridView.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(row => row.Cells["PatientId"].Value.ToString() == patientId);

                if (existingRow != null)
                {
                    // Update existing row
                    existingRow.Cells["PatientName"].Value = vitalsData.PatientName;
                    existingRow.Cells["Timestamp"].Value = vitalsData.Timestamp;
                    existingRow.Cells["Vitals"].Value = vitalsData.Vitals;
                }
                else
                {
                    // Add new row
                    patientVitalsGridView.Rows.Add(vitalsData.PatientId, vitalsData.PatientName, vitalsData.Timestamp, vitalsData.Vitals);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating patient vitals: {ex.Message}");
            }
        }

        private void UpdateDashboardGrid(string data)
        {
            try
            {
                var dashboardDataList = JsonSerializer.Deserialize<List<DashboardData>>(data);

                dashboardGridView.Rows.Clear();

                foreach (var dashboardData in dashboardDataList)
                {
                    dashboardGridView.Rows.Add(dashboardData.BedId, dashboardData.Status, dashboardData.Emergency);
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
    }
}
