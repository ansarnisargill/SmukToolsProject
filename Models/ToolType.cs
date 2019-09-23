using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmukToolsApp.Models
{
    public class ToolType
    {
        public enum PriceDurations
        {
            Dag,
            Time
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Titel { get; set; }
        public int Price { get; set; }
        public PriceDurations PriceDuration { get; set; }
        public bool RequiresApproval { get; set; }
    }
}
