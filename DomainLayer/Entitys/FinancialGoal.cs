using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entitys
{
    public class FinancialGoal
    {
        public int Id { get; set; }
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
