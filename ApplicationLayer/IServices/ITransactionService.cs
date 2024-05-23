using ApplicationLayer.DTOs.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface ITransactionService
    {
        Task<TransactionDTO> AddTransactionAsync(CreateTransactionDTO transactionDTO, string userId);
        Task<TransactionDTO> UpdateTransactionAsync(UpdateTransactionDTO transactionDTO, string userId);
        Task<bool> DeleteTransactionAsync(int id, string userId);
        Task<TransactionDTO> GetTransactionByIdAsync(int id, string userId);
        Task<IEnumerable<TransactionDTO>> GetUserTransactionsAsync(string userId);
    }
}
