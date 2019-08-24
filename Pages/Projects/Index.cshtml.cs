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
    public class IndexModel : PageModel
    {
        private readonly SmukToolsApp.Models.SmukContext _context;

        public IndexModel(SmukToolsApp.Models.SmukContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync()
        {
            Project = await _context.Projects.ToListAsync();
        }
    }
}
