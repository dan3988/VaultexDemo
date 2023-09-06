using Demo.Website.Controllers.Models;
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

	[HttpPost]
	public async Task<IActionResult> Create(OrganisationModel model, CancellationToken cancellationToken)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (await DbContext.Organisations.AnyAsync(v => v.OrganisationNumber == model.OrganisationNumber, cancellationToken))
		{
			ModelState.AddModelError("organisationNumber", "Duplicate organisation number.");
			return BadRequest(ModelState);
		}

		var entity = model.ToEntity();

		await DbContext.AddAsync(entity, cancellationToken);
		await DbContext.SaveChangesAsync(cancellationToken);

		return Ok();
	}

	[HttpPut]
	public async Task<IActionResult> Update(OrganisationModel model, CancellationToken cancellationToken)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (!await DbContext.Organisations.AnyAsync(v => v.OrganisationNumber == model.OrganisationNumber, cancellationToken))
			return NotFound();

		var entity = model.ToEntity();

		DbContext.Update(entity);
		await DbContext.SaveChangesAsync(cancellationToken);

		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
	{
		var entity = await DbContext.Organisations.SingleOrDefaultAsync(v => v.OrganisationNumber == id, cancellationToken);
		if (entity == null)
			return NotFound();

		DbContext.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);

		return Ok();
	}
}