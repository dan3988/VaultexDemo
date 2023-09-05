using Demo.Website.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Website.Controllers;

public sealed class EmployeeController : BaseApiController
{
	public EmployeeController(AppDbContext context, ILogger<EmployeeController> logger) : base(context, logger)
	{
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
	{
		var data = await DbContext.Employees.ToArrayAsync(cancellationToken);
		return Json(data);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
	{
		var data = await DbContext.Employees.FirstOrDefaultAsync(v => v.EmployeeId == id, cancellationToken);
		return data == null ? NotFound(null) : Json(data);
	}
}
