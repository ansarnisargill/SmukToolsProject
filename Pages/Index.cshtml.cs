using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmukToolsApp.Data;
using SmukToolsApp.Models;
using SmukToolsProject.Models;

namespace SmukToolsApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
    private ToolContext _context;

        public void OnGet()
        {

        }
        public IndexModel(ToolContext contex)
        {
            _context=contex;
        }
    }
}
