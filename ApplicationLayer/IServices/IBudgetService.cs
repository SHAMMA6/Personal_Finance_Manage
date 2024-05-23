using ApplicationLayer.DTOs.BudgetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface IBudgetService
    {
        Task<BudgetDTO> CreateBudgetAsync(CreateBudgetDTO budgetDTO, string userId);
        Task<BudgetDTO> UpdateBudgetAsync(UpdateBudgetDTO budgetDTO, string userId);
        Task<bool> DeleteBudgetAsync(int id, string userId);
        Task<BudgetDTO> GetBudgetByIdAsync(int id, string userId);
        Task<IEnumerable<BudgetDTO>> GetUserBudgetsAsync(string userId);
    }
}
