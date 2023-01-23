using Microsoft.AspNetCore.SignalR;

namespace NetDevChallange.MvcWebUI
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            if (string.IsNullOrEmpty(user))
                await Clients.All.SendAsync("ReceiveMessage", message);
            else
                await Clients.User(user).SendAsync("ReceiveMessage", message);
        }

        //public override Task OnConnectedAsync()
        //{
        //    //get conntection Id Context.ConnectionId;
        //    return base.OnConnectedAsync();
        //}
        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    return base.OnDisconnectedAsync(exception);
        //}
    }
}
