﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmukToolsApp.Data;
using SmukToolsApp.Models;

namespace SmukToolsApp.Pages.ToolTypes
{
    public class IndexModel : PageModel
    {
        private readonly SmukToolsApp.Data.ToolContext _context;

        public IndexModel(SmukToolsApp.Data.ToolContext context)
        {
            _context = context;
        }

        public IList<ToolType> ToolType { get;set; }

        public async Task OnGetAsync()
        {
            ToolType = await _context.ToolTypes.ToListAsync();
        }
    }
}
