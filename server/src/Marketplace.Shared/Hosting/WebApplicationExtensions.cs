using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Shared.Hosting;

public static class WebApplicationExtensions
{
	public static WebApplication ApplyConfigurators(this WebApplication webApplication)
	{
		var configurators = webApplication.Services.GetServices<IWebApplicationConfigurator>();
		foreach (var configurator in configurators)
		{
			configurator.Configure(webApplication);
		}

		return webApplication;
	}
}
