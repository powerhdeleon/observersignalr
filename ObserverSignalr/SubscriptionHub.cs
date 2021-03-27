using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverSignalr
{
    public class SubscriptionHub : Hub
    {
        public async Task SendMessage(string room, string message)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            await Clients.Group(room).SendAsync("ReceiveMessage", message);
        }

        public async Task AddToGroup(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            await Clients.All
                .SendAsync("ShowWho", $"{Context.ConnectionId} se ha unido al grupo {room}.");
        }

        public async Task RemoveFromGroup(string room)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);

            await Clients.Group(room)
                .SendAsync("ShowWho", $"{Context.ConnectionId} salio del grupo {room}.");
        }
    }
}
