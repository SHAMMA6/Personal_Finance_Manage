using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs.BudgetDTO
{
    public class CreateBudgetDTO
    {
        public string Category { get; set; }
        public decimal Limit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
