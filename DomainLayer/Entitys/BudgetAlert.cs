using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entitys
{
    public class BudgetAlert
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public decimal BudgetLimit { get; set; }
        public bool IsActive { get; set; }
    }
}
