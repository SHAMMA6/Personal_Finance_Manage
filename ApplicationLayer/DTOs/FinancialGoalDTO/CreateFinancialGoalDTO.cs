using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs.FinancialGoalDTO
{
    public class CreateFinancialGoalDTO
    {
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime TargetDate { get; set; }
    }
}
