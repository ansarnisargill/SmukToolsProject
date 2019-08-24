using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SmukToolsApp.Models;
using SmukToolsProject.Models;
using SmukToolsProject.Models.DTO;

namespace SmukToolsApp.Pages
{
    public class CRUDDemoModel : PageModel
    {
        private SmukContext _context;
        [BindProperty]
        public string Resources { get; set; }
        [BindProperty]
        public string Events { get; set; }
        public void OnGet()
        {
            var listOfProjects = _context.Projects.ToList();
            var listOfResource = new List<Resources>();
            foreach (var item in listOfProjects)
            {
                var obj = new Resources();
                obj.id = item.id;
                obj.title = item.title;
                if (item.iscomplete)
                {
                    obj.status = "Completed";
                    obj.eventColor = "green";
                }
                else
                {
                    obj.status = "On Going";
                    obj.eventColor = "red";
                }
                listOfResource.Add(obj);

            }
            Resources = JsonConvert.SerializeObject(listOfResource);

            var listOfEvents = _context.Events.ToList();
            var listOfEventResources = new List<EventResources>();
            foreach (var item in listOfEvents)
            {
                var obj = new EventResources();
                obj.title = item.title;
                obj.resourceId = item.ProjectId;
                obj.id = item.id;
                obj.start = item.StartDate.ToString("yyyy-MM-ddTHH:mm:ss");
                obj.end = item.EndDate.ToString("yyyy-MM-ddTHH:mm:ss");
                listOfEventResources.Add(obj);
            }
            Events = JsonConvert.SerializeObject(listOfEventResources);

        }
        public CRUDDemoModel(SmukContext context)
        {
            _context = context;
        }
       
    }
}
