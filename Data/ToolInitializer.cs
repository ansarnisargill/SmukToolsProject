using SmukToolsApp.Models;
using System;
using System.Linq;

namespace SmukToolsApp.Data
{
    public class ToolInitializer
    {
        public static void Initialize(ToolContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Tools.Any())
            {
                var tools = new Tool[]
                {
                    new Tool{Title="KBL",isComplete=false},
                    new Tool{Title="GBL",isComplete=false},
                };
                foreach (var item in tools)
                {
                    context.Tools.Add(item);
                }
                context.SaveChanges();
            }


            if (!context.Bookings.Any())
            {
                var bookings = new Booking[]
                {
                    new Booking{ToolId=1, Title="KBL01",StartDate=DateTime.Parse("2019-09-01"), EndDate=DateTime.Parse("2019-09-10")},
                    new Booking{ToolId=2, Title="KBL02",StartDate=DateTime.Parse("2019-09-03"), EndDate=DateTime.Parse("2019-09-13")},

                };
                foreach (var item in bookings)
                {
                    context.Bookings.Add(item);
                }
                context.SaveChanges();
            }


            if (!context.ToolTypes.Any())
            {
                var toolTypes = new ToolType[]
                {
                    new ToolType{Code = "MTB", Titel = "Mountainbike", Price = 10, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "ECY", Titel = "El - cykel", Price = 50, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},

                    new ToolType{Code = "GBK", Titel = "Golfbil med alukasse", Price = 350, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "GBL", Titel = "Golfbil med lad", Price = 350, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "GB6P", Titel = "GolfBil, 6 personer", Price = 0, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},

                    new ToolType{Code = "KB", Titel = "Kassebil", Price = 290, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "KBL", Titel = "Kassebil Med Lift", Price = 500, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "KBM", Titel = "Kassebil, Mini", Price = 290, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "KBS", Titel = "Kassebil, Stor", Price = 290, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},

                    new ToolType{Code = "LB", Titel = "Ladbil", Price = 540, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "LBD", Titel = "Ladbil - Dobbeltkabine", Price = 540, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},


                    new ToolType{Code = "MB", Titel = "Minibus", Price = 700, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},

                    new ToolType{Code = "PBE", Titel = "Person bil EL ", Price = 180, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "PB", Titel = "Personbil", Price = 280, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "PBS", Titel = "Personbil, Stationcar", Price = 280, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "POL", Titel = "Polaris", Price = 375, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},

                    new ToolType{Code = "SCL30", Titel = "Scooter M Lad, 30kmt ", Price = 125, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "SCL45", Titel = "Scooter M Lad, 45kmt", Price = 125, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "SC30", Titel = "Scooter, 30 kmt", Price = 125, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},
                    new ToolType{Code = "SC45", Titel = "Scooter, 45 kmt", Price = 125, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},

                    new ToolType{Code = "TRL", Titel = "Trailer", Price = 0, PriceDuration = ToolType.PriceDurations.Dag, RequiresApproval = false},

                };
                foreach (var item in toolTypes)
                {
                    context.ToolTypes.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}
