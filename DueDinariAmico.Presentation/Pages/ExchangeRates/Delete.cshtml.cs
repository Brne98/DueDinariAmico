using DueDinariAmico.Core.Entities;
using DueDinariAmico.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DueDinariAmico.Presentation.Pages.ExchangeRates
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _context;

        public DeleteModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ExchangeRateLists == null)
            {
                return NotFound();
            }
            var exchangerate = await _context.ExchangeRateLists.FindAsync(id);

            if (exchangerate != null)
            {
                ExchangeRate = exchangerate;
                _context.ExchangeRateLists.Remove(ExchangeRate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
