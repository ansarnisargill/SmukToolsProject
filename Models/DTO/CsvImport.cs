using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmukToolsApp.Models.DTO
{
    public class CsvImport
    {
        public string OrderID { get; set; }
        public string Dato { get; set; }
        public string Holdnr { get; set; }
        public string Hold { get; set; }
        public string Placering { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }
        public string Formandnr { get; set; }
        public string Formandfornavn { get; set; }
        public string Formandefternavn { get; set; }
        public string FormandMail { get; set; }
        public string Bestiller { get; set; }
        public string Produkt { get; set; }
        public string Antal { get; set; }
        public string Status { get; set; }
        public string Kommentar { get; set; }
    }
}
