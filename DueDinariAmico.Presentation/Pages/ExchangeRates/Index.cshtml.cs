using DueDinariAmico.Core.Entities;
using DueDinariAmico.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DueDinariAmico.Presentation.Pages.ExchangeRates
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IList<ExchangeRateList> ExchangeRate { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ExchangeRateLists != null)
            {
                ExchangeRate = await _context.ExchangeRateLists.ToListAsync();
            }
        }
    }
}
