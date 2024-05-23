using ApplicationLayer.DTOs.FinancialGoalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface IFinancialGoalService
    {
        Task<FinancialGoalDTO> CreateFinancialGoalAsync(CreateFinancialGoalDTO goalDTO, string userId);
        Task<FinancialGoalDTO> UpdateFinancialGoalAsync(UpdateFinancialGoalDTO goalDTO, string userId);
        Task<bool> DeleteFinancialGoalAsync(int id, string userId);
        Task<FinancialGoalDTO> GetFinancialGoalByIdAsync(int id, string userId);
        Task<IEnumerable<FinancialGoalDTO>> GetUserFinancialGoalsAsync(string userId);
    }
}
