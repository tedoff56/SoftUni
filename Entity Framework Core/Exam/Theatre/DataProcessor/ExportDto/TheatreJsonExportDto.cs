using System.Collections.Generic;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ExportDto
{
    public class TheatreJsonExportDto
    {
        public string Name { get; set; }

        public int Halls { get; set; }

        public decimal TotalIncome { get; set; }

        public IEnumerable<TicketJsonExportDto> Tickets { get; set; }
    }
}