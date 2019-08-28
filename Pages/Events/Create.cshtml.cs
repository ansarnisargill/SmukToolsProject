using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmukToolsApp.Models;
using SmukToolsProject.Models;

namespace SmukToolsApp.Pages.Events
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class CreateModel : PageModel
    {
        private readonly SmukToolsApp.Models.SmukContext _context;

        public CreateModel(SmukToolsApp.Models.SmukContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProjectId"] = new SelectList(_context.Projects, "id", "title");
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}