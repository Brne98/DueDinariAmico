using DueDinariAmico.Core.Entities;
using DueDinariAmico.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DueDinariAmico.Presentation.Pages.ExchangeRates
{
    public class EditModel : PageModel
    {
        private readonly DataContext _context;

        public EditModel(DataContext context)
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

            var exchangerate =  await _context.ExchangeRateLists.FirstOrDefaultAsync(m => m.Id == id);
            if (exchangerate == null)
            {
                return NotFound();
            }
            ExchangeRate = exchangerate;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExchangeRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExchangeRateExists(ExchangeRate.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExchangeRateExists(int id)
        {
          return (_context.ExchangeRateLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
