using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmukToolsApp.Data;

namespace SmukToolsApp.Pages
{
    public class EditBookingModel : PageModel
    {
        public ToolContext Context;
        public IActionResult OnGet(int id, string start, string end)
        {
            try
            {
                var booking = Context.Bookings.FirstOrDefault(x => x.Id == id);
                if (booking == null)
                {
                    return BadRequest();
                }
                booking.StartDate = DateTime.Parse(start);
                booking.EndDate = DateTime.Parse(end);
                Context.Entry(booking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Context.SaveChanges();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
        public EditBookingModel()
        {

        }

    }
}