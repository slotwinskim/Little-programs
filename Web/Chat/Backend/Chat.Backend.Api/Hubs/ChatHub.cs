using System.Threading.Tasks;
using Chat.Common.Shared.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Backend.Api.Hubs
{
	public class ChatHub : Hub<IChatHubClient>, IChatHub
	{
		public async Task<string> GetConnectionId()
		{
			return await Task.FromResult(Context.ConnectionId);
		}

		public async Task Login(string name)
		{
			await Clients.Caller.Greet(name);
		}

		public async Task SendMessage(string user, string message)
		{
			await Clients.All.ReceiveMessage(user, message);
		}
	}
}