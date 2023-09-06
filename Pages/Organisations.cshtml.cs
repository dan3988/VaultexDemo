using Demo.Website.Data;
using Demo.Website.Data.Entities;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo.Website.Pages
{
	public class OrganisationsModel : PageModel
	{
		private readonly AppDbContext _context;

		public IReadOnlyList<Organisation> Organisations { get; private set; } = Array.Empty<Organisation>();

		public OrganisationsModel(AppDbContext context)
		{
			_context = context;
		}

		public async Task OnGetAsync()
		{
			Organisations = await _context.Organisations.ToListAsync();
		}
	}
}
