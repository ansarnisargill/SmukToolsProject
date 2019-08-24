using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmukToolsApp.Models;
using SmukToolsProject.Models;

namespace SmukToolsApp.Pages
{
    public class IndexModel : PageModel
    {
    private SmukContext _context;

        public void OnGet()
        {

        }
        public IndexModel(SmukContext contex)
        {
            _context=contex;
            Initializedb();
        }
         private void Initializedb()
        {
            if (!_context.Projects.Any())
            {
                _context.Projects.Add(new Project()
                {
                    title = "Test Project",
                    iscomplete = false

                });
                _context.SaveChanges();
                _context.Events.Add(new Event()
                {
                    ProjectId = _context.Projects.First().id,
                    title = "Test Event",
                    StartDate = DateTime.Now.AddDays(-7),
                    EndDate = DateTime.Now
                });
                _context.SaveChanges();
            }
        }
    }
}
