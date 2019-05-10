using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Backend.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSignalR();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSignalR(routes =>
			{
				routes.MapHub<Hubs.ChatHub>("/chathub");
			});
		}
	}
}