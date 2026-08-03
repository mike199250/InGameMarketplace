using Marketplace.Infrastructure.DependencyInjection;
using Marketplace.Shared.Hosting;
using Marketplace.Shared.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
	.AddMarketplaceDefaults()
	.AddMarketplaceAuthentication()
	.AddMarketplaceIdentity()
	.AddMarketplaceInfrastructure()
	.AddMarketplaceDataProtection()
	;
builder.ApplyConfigurators();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MapControllers();

app.ApplyConfigurators();

app.Run();
