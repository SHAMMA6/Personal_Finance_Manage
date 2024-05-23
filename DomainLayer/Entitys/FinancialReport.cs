using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entitys
{
    public class FinancialReport
    {
        public int Id { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string ReportType { get; set; } // Summary, Detailed
        public string Data { get; set; } // JSON or another format for report data

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }

}
