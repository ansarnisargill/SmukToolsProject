using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SmukToolsApp.Data;
using SmukToolsApp.Models;
using SmukToolsProject.Models;
using SmukToolsProject.Models.DTO;

namespace SmukToolsApp.Pages
{
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class CRUDDemoModel : PageModel
    {
        private ToolContext _context;
        [BindProperty]
        public string Resources { get; set; }
        [BindProperty]
        public string Bookings { get; set; }
        [BindProperty]
        public int DaysInMonth { get; set; }=DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month);
        public void OnGet()
        {
            var listOfProjects = _context.Tools.ToList();
            var listOfResource = new List<Resources>();
            foreach (var item in listOfProjects)
            {
                var obj = new Resources();
                obj.id = item.Id;
                obj.title = item.Title;
                if (item.isComplete)
                {
                    obj.status = "Completed";
                    obj.eventColor = "green";
                }
                else
                {
                    obj.status = "On Going";
                    obj.eventColor = "#aa98ce";
                }
                listOfResource.Add(obj);

            }
            Resources = JsonConvert.SerializeObject(listOfResource);

            var listOfEvents = _context.Bookings.ToList();
            var listOfEventResources = new List<EventResources>();
            foreach (var item in listOfEvents)
            {
                var obj = new EventResources();
                obj.title = item.Title;
                obj.resourceId = item.ToolId;
                obj.id = item.Id;
                obj.start = item.StartDate.ToString("yyyy-MM-ddTHH:mm:ss");
                obj.end = item.EndDate.ToString("yyyy-MM-ddTHH:mm:ss");
                listOfEventResources.Add(obj);
            }
            Bookings = JsonConvert.SerializeObject(listOfEventResources);

        }
        public CRUDDemoModel(ToolContext context)
        {
            _context = context;
        }
       
    }
}
