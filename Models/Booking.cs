using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmukToolsApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
