using System.Threading.Tasks;

namespace Chat.Common.Shared.Hubs
{
	public interface IChatHubClient
	{
		Task Greet(string message);
		Task ReceiveMessage(string user, string message);
	}
}