using Demo.Website.Data;
using Demo.Website.Data.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo.Website.Pages
{
	public class OrganisationModel : PageModel
	{
		private readonly ILogger<OrganisationModel> _logger;
		private readonly AppDbContext _context;

		public Organisation Value { get; private set; } = null!;

		public OrganisationModel(ILogger<OrganisationModel> logger, AppDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> OnGetAsync([FromRoute] string id, CancellationToken cancellationToken)
		{
			var organisation = await _context.Organisations.FirstOrDefaultAsync(v => v.OrganisationNumber == id, cancellationToken);
			if (organisation == null)
			{
				_logger.LogWarning("Organisation not found: {id}", id);
				return Redirect("/Organisations");
			}

			Value = organisation;
			return Page();
		}

	}
}
