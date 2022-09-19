using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace StrawberrySignSystem.Hubs
{
    public class CustomerWatcherHub : Hub
    {
        public Task NotifyConnection()
        {
            return Clients.All.SendAsync("TestBrodcasting", $"Testing a Basic HUB at {DateTime.Now.ToLocalTime()}");
        }
    }
}
