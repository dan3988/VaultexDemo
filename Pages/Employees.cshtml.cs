using Demo.Website.Data;
using Demo.Website.Data.Entities;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo.Website.Pages
{
	public class EmployeesModel : PageModel
	{
		private readonly ILogger<EmployeesModel> _logger;
		private readonly AppDbContext _context;

		public IReadOnlyList<Employee> Employees { get; private set; } = Array.Empty<Employee>();

		public EmployeesModel(ILogger<EmployeesModel> logger, AppDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task OnGetAsync()
		{
			Employees = await _context.Employees.Include(v => v.Organisation).ToArrayAsync();
		}
	}
}