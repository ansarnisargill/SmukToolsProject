using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmukToolsApp.Data;
using SmukToolsApp.Models;

namespace SmukToolsApp.Pages.ToolTypes
{
    public class CreateModel : PageModel
    {
        private readonly SmukToolsApp.Data.ToolContext _context;

        public CreateModel(SmukToolsApp.Data.ToolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToolType ToolType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToolTypes.Add(ToolType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}