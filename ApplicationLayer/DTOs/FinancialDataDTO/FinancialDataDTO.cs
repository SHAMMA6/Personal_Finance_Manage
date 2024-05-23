using ApplicationLayer.DTOs.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs.FinancialDataDTO
{
    public class FinancialDataDTO
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionDataDTO> Transactions { get; set; }
    }
}
