using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MedicalInventoryServer
{
    public class InventoryHub : Hub
    {
        public async Task SendInventoryUpdate()
        {
            await Clients.All.SendAsync("UpdateInventory");
        }

        public async Task NotifyLowStock(string itemName, int quantity)
        {
            await Clients.All.SendAsync("LowStockAlert", itemName, quantity);
        }

        public async Task NotifyStockUpdated(string itemName, int quantity)
        {
            await Clients.All.SendAsync("StockUpdatedAlert", itemName, quantity);
        }

        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("SendMessage", user, message);
        }

        public async Task UpdatePatientVitals()
        {
            await Clients.All.SendAsync("ReceivePatientVitals");
        }

        public async Task UpdateDashboard(string data)
        {
            await Clients.All.SendAsync("ReceiveDashboardUpdate", data);
        }
    }

    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
