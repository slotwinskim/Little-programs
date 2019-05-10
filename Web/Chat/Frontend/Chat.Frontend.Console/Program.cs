using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.Frontend.Console
{
	internal class Program
	{
		private static async Task Main()
		{
			System.Console.WriteLine("What's Your name?");
			var name = System.Console.ReadLine();

			var connection = new HubConnectionBuilder()
				.WithUrl("http://localhost:5000/ChatHub")
				.Build();

			connection.On<string, string>("ReceiveMessage", (user, message) =>
			{
				System.Console.WriteLine($"{user}: {message}");
			});

			connection.StartAsync().ContinueWith(task =>
			{
				System.Console.WriteLine("You're connected, You can start typing!");

				while (true)
				{
					var message = System.Console.ReadLine();
					if (string.IsNullOrEmpty(message)) break;

					connection.InvokeAsync<string>("SendMessage",
						name, message).ContinueWith(t =>
					{
						System.Console.WriteLine(t.Result);
					});
				}
			}).Wait();

			System.Console.ReadLine();
			await connection.StopAsync();
		}
	}
}