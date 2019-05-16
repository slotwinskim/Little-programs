using System.Threading.Tasks;
using Chat.Common.Shared.Hubs;

namespace Chat.Frontend.Console.Hubs
{
	public class ChatHubClient : IChatHubClient
	{
		public Task Greet(string message)
		{
			System.Console.WriteLine(message);
			return Task.CompletedTask;
		}

		public Task ReceiveMessage(string user, string message)
		{
			System.Console.WriteLine($"{user}: {message}");
			return Task.CompletedTask;
		}
	}
}