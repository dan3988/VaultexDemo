using Demo.Website.Data;

using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Demo.Tests;

[SetUpFixture]
internal static class Testing
{
	private static WebApplicationFactory<Program>? _factory;

	public static HttpClient GetClient()
	{
		if (_factory == null)
			throw new InvalidOperationException("SetUpServicesAsync has not been called.");

		return _factory.CreateClient();
	}

	[OneTimeSetUp]
	public static void SetUpServicesAsync()
	{
		_factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
		{
			builder.ConfigureTestServices(services =>
			{
				//remove the DbContext options added by Program.cs
				var descriptor = services.SingleOrDefault(v => v.ServiceType == typeof(DbContextOptions<AppDbContext>));
				if (descriptor != null)
					services.Remove(descriptor);

				services.AddDbContext<AppDbContext>(options =>
				{
					options.UseInMemoryDatabase("test_data");
				});
			});
		});
	}
}
