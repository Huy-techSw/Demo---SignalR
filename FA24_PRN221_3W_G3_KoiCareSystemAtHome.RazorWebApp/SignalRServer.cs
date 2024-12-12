using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using Microsoft.AspNetCore.SignalR;


namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.RazorWebApp
{
    public class SignalRServer : Hub
    {
        public async Task BroadcastNewPond(Pond pond)
        {
            await Clients.All.SendAsync("LoadPond", pond);
        }
    }
}
