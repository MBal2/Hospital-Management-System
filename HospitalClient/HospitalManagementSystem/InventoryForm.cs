using HospitalManagementSystem.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class InventoryForm : Form
    {
        private SqlConnection connection;
        private HubConnection hubConnection;
        private const int LowStockThreshold = 1;

        public InventoryForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeSignalR();
            LoadInventory();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=THANHLENOVO\\SQLEXPRESS;Initial Catalog=MedicalInventory;Integrated Security=True;Encrypt=False";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private async void InitializeSignalR()
        {
            hubConnection = new HubConnectionBuilder()
               .WithUrl("http://localhost:5139/inventoryHub")
               .Build();

            hubConnection.On("UpdateInventory", () =>
            {
                this.Invoke((Action)LoadInventory);
            });

            hubConnection.On("LowStockAlert", (string itemName, int quantity) =>
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show($"Low stock alert: {itemName} only has {quantity} items left.");
                }));
            });

            hubConnection.On("StockUpdatedAlert", (string itemName, int quantity) =>
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show($"Stock updated: {itemName} now has {quantity} items.");
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

        private void LoadInventory()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Medications", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            medicationsGridView.DataSource = dataTable;

            // Check for low stock items
            foreach (DataRow row in dataTable.Rows)
            {
                string itemName = row["Name"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);
                if (quantity < LowStockThreshold)
                {
                    NotifyLowStock(itemName, quantity).GetAwaiter().GetResult();
                }
            }
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            int quantity = (int)quantityNumericUpDown.Value;
            DateTime expirationDate = expirationDateTimePicker.Value;

            string query = "INSERT INTO Medications (Name, Quantity, ExpirationDate) VALUES (@Name, @Quantity, @ExpirationDate)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            cmd.ExecuteNonQuery();

            LoadInventory();
            await SendInventoryUpdate();
            await NotifyStockUpdated(name, quantity);
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (medicationsGridView.SelectedRows.Count > 0)
            {
                int id = (int)medicationsGridView.SelectedRows[0].Cells["Id"].Value;
                string name = nameTextBox.Text;
                int quantity = (int)quantityNumericUpDown.Value;
                DateTime expirationDate = expirationDateTimePicker.Value;

                string query = "UPDATE Medications SET Name = @Name, Quantity = @Quantity, ExpirationDate = @ExpirationDate WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                cmd.ExecuteNonQuery();

                LoadInventory();
                await SendInventoryUpdate();
                await NotifyStockUpdated(name, quantity);

                if (quantity < LowStockThreshold)
                {
                    await NotifyLowStock(name, quantity);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to update.");
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (medicationsGridView.SelectedRows.Count > 0)
            {
                int id = (int)medicationsGridView.SelectedRows[0].Cells["Id"].Value;
                string name = medicationsGridView.SelectedRows[0].Cells["Name"].Value.ToString();
                string query = "DELETE FROM Medications WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                LoadInventory();
                await SendInventoryUpdate();
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }

        private async Task SendInventoryUpdate()
        {
            try
            {
                await hubConnection.InvokeAsync("SendInventoryUpdate");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task NotifyLowStock(string itemName, int quantity)
        {
            try
            {
                await hubConnection.InvokeAsync("NotifyLowStock", itemName, quantity);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task NotifyStockUpdated(string itemName, int quantity)
        {
            try
            {
                await hubConnection.InvokeAsync("NotifyStockUpdated", itemName, quantity);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void medicationsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (medicationsGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = medicationsGridView.SelectedRows[0];
                nameTextBox.Text = selectedRow.Cells["Name"].Value.ToString();
                quantityNumericUpDown.Value = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                expirationDateTimePicker.Value = Convert.ToDateTime(selectedRow.Cells["ExpirationDate"].Value);
            }
        }
    }
}
