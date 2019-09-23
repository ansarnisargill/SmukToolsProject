using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmukToolsApp.Data;
using SmukToolsApp.Models;

namespace SmukToolsApp.Pages.ToolTypes
{
    public class EditModel : PageModel
    {
        private readonly SmukToolsApp.Data.ToolContext _context;

        public EditModel(SmukToolsApp.Data.ToolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToolType ToolType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToolType = await _context.ToolTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (ToolType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToolType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolTypeExists(ToolType.Id))
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

        private bool ToolTypeExists(int id)
        {
            return _context.ToolTypes.Any(e => e.Id == id);
        }
    }
}
