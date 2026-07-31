using Marketplace.Shared.Authentication;
using Marketplace.Shared.Hosting;
using Marketplace.Shared.Identity.Payloads;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Marketplace.Shared.Identity;

internal class IdentityConfigurator : IWebApplicationConfigurator
{
	public void Configure(WebApplication app)
	{
		app.MapPost(IdentityRoutes.Internal.DirectLogin.Cookie, async (HttpContext context, DirectLoginRequest request) =>
		{
			var userId = request.UserId ?? Guid.CreateVersion7();
			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
			};

			var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, AuthenticationSchemeNames.Cookie));
			await context.SignInAsync(AuthenticationSchemeNames.Cookie, principal);

			return Results.Ok();
		});
		app.MapGet(IdentityRoutes.Logout.Cookie, async (HttpContext context) =>
		{
			await context.SignOutAsync(AuthenticationSchemeNames.Cookie);
			return Results.Ok();
		});
	}
}
