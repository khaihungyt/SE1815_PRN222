using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class ArticleHub : Hub
    {
        public async Task SendUpdate()
        {
            await Clients.All.SendAsync("ReceiveUpdate");
        }
        public async Task SendCreate()
        {
            await Clients.All.SendAsync("ReceiveCreate");
        }
    }
}
