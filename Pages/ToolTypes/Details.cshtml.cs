using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmukToolsApp.Data;
using SmukToolsApp.Models;

namespace SmukToolsApp.Pages.ToolTypes
{
    public class DetailsModel : PageModel
    {
        private readonly SmukToolsApp.Data.ToolContext _context;

        public DetailsModel(SmukToolsApp.Data.ToolContext context)
        {
            _context = context;
        }

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
    }
}
