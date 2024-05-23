using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs.FinancialDataDTO
{
    public class TransactionDataDTO
    {
        public int Id { get; set; }
        public string Type { get; set; } // Income or Expense
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}
