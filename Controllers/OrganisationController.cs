using Demo.Website.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Website.Controllers;

public sealed class OrganisationController : BaseApiController
{
	public OrganisationController(AppDbContext context, ILogger<OrganisationController> logger) : base(context, logger)
	{
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
	{
		var data = await DbContext.Organisations.ToArrayAsync(cancellationToken);
		return Json(data);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetByIdAsync(string id, CancellationToken cancellationToken)
	{
		var data = await DbContext.Organisations.FirstOrDefaultAsync(v => v.OrganisationNumber == id, cancellationToken);
		return Json(data);
	}
}