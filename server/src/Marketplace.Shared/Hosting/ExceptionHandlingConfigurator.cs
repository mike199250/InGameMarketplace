using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Marketplace.Shared.Hosting;

internal class ExceptionHandlingConfigurator : IHostApplicationBuilderConfigurator, IWebApplicationConfigurator
{
	public void Configure(IHostApplicationBuilder builder)
	{
		builder.Services.AddProblemDetails();
	}

	public void Configure(WebApplication app)
	{
		app.UseExceptionHandler();
	}
}
