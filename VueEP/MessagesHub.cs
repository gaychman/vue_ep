using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEP
{
    public class MessagesHub : Hub
    {
        public async Task InboxChanged(Int32 UserId)
        {
            await Clients.AllExcept(new[] { UserId.ToString() }).InvokeAsync("OnInboxChanged", UserId);
        }
    }
}
