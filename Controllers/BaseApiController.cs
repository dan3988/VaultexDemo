using Demo.Website.Data;

using Microsoft.AspNetCore.Mvc;

namespace Demo.Website.Controllers;

/// <summary>
/// Base class for controllers that retrieve / ingest raw data. Derived classes will have the route mapped by <see cref="ControllerEndpointRouteBuilderExtensions.MapControllers(IEndpointRouteBuilder)"/> and set to <c>"/api/[controller]"</c>, unless the <see cref="RouteAttribute"/> is added to the derived class.
/// </summary>
[ApiController, Route("/api/[controller]")]
public abstract class BaseApiController : Controller
{
	protected AppDbContext DbContext { get; }

	protected ILogger Logger { get; }

	protected BaseApiController(AppDbContext context, ILogger logger)
	{
		DbContext = context;
		Logger = logger;
	}
}
