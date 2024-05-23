using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entitys
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; } // Income or Expense
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
