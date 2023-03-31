using DueDinariAmico.Core.Entities;
using DueDinariAmico.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DueDinariAmico.Presentation.Pages.ExchangeRates
{
    public class DetailsModel : PageModel
    {
        private readonly DataContext _context;

        public DetailsModel(DataContext context)
        {
            _context = context;
        }

      public ExchangeRateList ExchangeRate { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ExchangeRateLists == null)
            {
                return NotFound();
            }

            var exchangerate = await _context.ExchangeRateLists.FirstOrDefaultAsync(m => m.Id == id);
            if (exchangerate == null)
            {
                return NotFound();
            }
            else 
            {
                ExchangeRate = exchangerate;
            }
            return Page();
        }
    }
}
