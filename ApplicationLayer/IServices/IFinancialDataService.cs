using ApplicationLayer.DTOs.FinancialDataDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface IFinancialDataService
    {
        Task<FinancialDataDTO> GetUserFinancialDataAsync(string userId);
    }
}
