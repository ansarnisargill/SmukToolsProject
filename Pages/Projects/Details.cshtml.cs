using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmukToolsApp.Models;
using SmukToolsProject.Models;

namespace SmukToolsApp.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly SmukToolsApp.Models.SmukContext _context;

        public DetailsModel(SmukToolsApp.Models.SmukContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects.FirstOrDefaultAsync(m => m.id == id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}