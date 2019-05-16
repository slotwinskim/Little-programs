using System.Threading.Tasks;

namespace Chat.Common.Shared.Hubs
{
	public interface IChatHub
	{
		Task<string> GetConnectionId();
		Task Login(string name);
		Task SendMessage(string user, string message);
	}
}