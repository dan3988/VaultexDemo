using Demo.Website.Controllers.Models;
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

	[HttpPost]
	public async Task<IActionResult> Create(EmployeeModel model, CancellationToken cancellationToken)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var entity = model.ToEntity();

		await DbContext.AddAsync(entity, cancellationToken);
		await DbContext.SaveChangesAsync(cancellationToken);

		return Ok(entity.EmployeeId);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, EmployeeModel model, CancellationToken cancellationToken)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (!await DbContext.Employees.AnyAsync(v => v.EmployeeId == id, cancellationToken))
			return NotFound();

		var entity = model.ToEntity(id);

		DbContext.Update(entity);
		await DbContext.SaveChangesAsync(cancellationToken);

		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
	{
		var entity = await DbContext.Employees.SingleOrDefaultAsync(v => v.EmployeeId == id, cancellationToken);
		if (entity == null)
			return NotFound();

		DbContext.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);

		return Ok();
	}
}