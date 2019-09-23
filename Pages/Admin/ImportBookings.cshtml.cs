using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmukToolsApp.Models;
using SmukToolsApp.Models.DTO;

namespace SmukToolsApp.Pages.Admin
{
    public class ImportBookingsModel : PageModel
    {
        private readonly SmukToolsApp.Data.ToolContext _context;

        public ImportBookingsModel(SmukToolsApp.Data.ToolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IFormFile files { get; set; }

        Dictionary<string, string> months = new Dictionary<string, string>()
        {
            { "jan", "01"},
            { "feb", "02"},
            { "mar", "03"},
            { "apr", "04"},
            { "may", "05"},
            { "jun", "06"},
            { "jul", "07"},
            { "aug", "08"},
            { "sep", "09"},
            { "okt", "10"},
            { "nov", "11"},
            { "dec", "12"},
        };

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Database.ExecuteSqlCommandAsync(@"DELETE FROM Bookings");
            await _context.Database.ExecuteSqlCommandAsync(@"DELETE FROM Tools");

            int lineCount = 0;
            try
            {

                using (var streamReader = new StreamReader(files.OpenReadStream()))
                using (var csv = new CsvReader(streamReader))
                {
                    //csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.Trim(new Char[] { ' ', '*', '.' });
                    csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.Replace(" ", string.Empty).Replace(".", string.Empty);

                    csv.Configuration.HeaderValidated = null;
                    var record = new CsvImport();
                    var records = csv.EnumerateRecords(record);


                    foreach (var r in records)
                    {
                        char[] charsToTrim = { '"', '\'' };
                        string startData = r.Fra;
                        string endDate = r.Til;

                        foreach (var month in months)
                        {
                            if (startData.ToLower().Contains(month.Key))
                            {
                                startData = startData.ToLower().Replace(month.Key, month.Value);
                                startData = startData.Replace(" ", "-").Trim(charsToTrim);
                            }
                            if (endDate.ToLower().Contains(month.Key))
                            {
                                endDate = endDate.ToLower().Replace(month.Key, month.Value);
                                endDate = endDate.Replace(" ", "-").Trim(charsToTrim);
                            }
                        }

                        var tool = new Tool()
                        {
                            isComplete = false,
                            Title = r.Produkt,
                        };
                        _context.Tools.Add(tool);

                        await _context.SaveChangesAsync();
                        var booking = new Booking()
                        {
                            ToolId = tool.Id,
                            Title = r.Hold,
                            StartDate = DateTime.ParseExact(startData, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                            EndDate = DateTime.ParseExact(endDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        };
                        _context.Bookings.Add(booking);
                        await _context.SaveChangesAsync();
                    }

                }
                /*
                using (var streamReader = new StreamReader(files.OpenReadStream()))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        lineCount++;
#if DEBUG
                        if (lineCount == 30) Console.Write("Break");
#endif
                        var line = streamReader.ReadLine();
                        if (lineCount == 1) continue;
                        var data = line.Split(new[] { ';' });
                        //DateTime myDate = new DateTime();
                        //DateTime.TryParseExact(data[3], "d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out myDate);

                        char[] charsToTrim = { '"', '\'' };
                        string startData = data[(int)MembaExport.Fra];
                        string endDate = data[(int)MembaExport.Til];

                        foreach (var month in months)
                        {
                            if (startData.ToLower().Contains(month.Key))
                            {
                                startData = startData.ToLower().Replace(month.Key, month.Value);
                                startData = startData.Replace(" ", "-").Trim(charsToTrim);
                            }
                            if (endDate.ToLower().Contains(month.Key))
                            {
                                endDate = endDate.ToLower().Replace(month.Key, month.Value);
                                endDate = endDate.Replace(" ", "-").Trim(charsToTrim);
                            }
                        }

                        var tool = new Tool()
                        {
                            isComplete = false,
                            Title = data[(int)MembaExport.Produkt],
                        };
                        _context.Tools.Add(tool);

                        await _context.SaveChangesAsync();
                        var booking = new Booking()
                        {
                            ToolId = tool.Id,
                            Title = data[(int)MembaExport.Hold],
                            StartDate = DateTime.ParseExact(startData, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                            EndDate = DateTime.ParseExact(endDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        };
                        _context.Bookings.Add(booking);
                        await _context.SaveChangesAsync();

                    }
                }*/
            }
            catch (Exception exp)
            {

                TempData["Message-Type"] = "danger";
                TempData["Message-Content"] = "Could not import file. Error in line " + lineCount.ToString() + ". " + exp.Message;
                return Page();
            }

            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Details), new { id = areaFile.AreaID });

            // _context.Projects.Add(Project);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}