using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmukToolsApp.Data;

namespace SmukToolsApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public ToolContext Context;

        public HomeController(
            ToolContext context)
        {
            Context = context;
        }

        // GET: api/Home
        [HttpGet]
        public string Get()
        {
            var events = Context.Bookings.ToList();
            return JsonConvert.SerializeObject(events);
        }


        public string GetEvents()
        {
            var events = Context.Bookings.ToList();
            return JsonConvert.SerializeObject(events);
            //return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
