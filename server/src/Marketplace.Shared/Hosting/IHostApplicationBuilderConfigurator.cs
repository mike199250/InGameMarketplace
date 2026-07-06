using Microsoft.Extensions.Hosting;

namespace Marketplace.Shared.Hosting;

public interface IHostApplicationBuilderConfigurator
{
	void Configure(IHostApplicationBuilder builder);
}
