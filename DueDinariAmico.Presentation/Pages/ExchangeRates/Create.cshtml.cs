using DueDinariAmico.Core.Entities;
using DueDinariAmico.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DueDinariAmico.Presentation.Pages.ExchangeRates
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ExchangeRateList ExchangeRate { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ExchangeRateLists == null || ExchangeRate == null)
            {
                return Page();
            }

            _context.ExchangeRateLists.Add(ExchangeRate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
