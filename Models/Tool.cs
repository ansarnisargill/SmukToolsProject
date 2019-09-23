using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmukToolsApp.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isComplete { get; set; }
    }
}
