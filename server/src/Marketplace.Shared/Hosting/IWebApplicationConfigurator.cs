using Microsoft.AspNetCore.Builder;

namespace Marketplace.Shared.Hosting;

public interface IWebApplicationConfigurator
{
	void Configure(WebApplication app);
}
