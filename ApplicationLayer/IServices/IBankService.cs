using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface IBankService
    {
        Task<bool> ConnectBankAccountAsync(string userId, string bankAccountDetails);
        Task<bool> ImportBankTransactionsAsync(string userId);
    }
}
