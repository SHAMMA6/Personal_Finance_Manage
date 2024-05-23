using ApplicationLayer.DTOs.TransactionDTOs;
using ApplicationLayer.IServices;
using DomainLayer.Entitys;
using InfrastructurLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructurLayer.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionDTO> AddTransactionAsync(CreateTransactionDTO transactionDTO, string userId)
        {
            var transaction = new Transaction
            {
                Type = transactionDTO.Type,
                Amount = transactionDTO.Amount,
                Category = transactionDTO.Category,
                Date = transactionDTO.Date,
                Description = transactionDTO.Description,
                UserId = userId
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return new TransactionDTO
            {
                Type = transaction.Type,
                Amount = transaction.Amount,
                Category = transaction.Category,
                Date = transaction.Date,
                Description = transaction.Description
            };
        }

        public async Task<TransactionDTO> UpdateTransactionAsync(UpdateTransactionDTO transactionDTO, string userId)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == transactionDTO.Id && t.UserId == userId);

            if (transaction == null)
            {
                return null;
            }

            transaction.Type = transactionDTO.Type;
            transaction.Amount = transactionDTO.Amount;
            transaction.Category = transactionDTO.Category;
            transaction.Date = transactionDTO.Date;
            transaction.Description = transactionDTO.Description;

            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();

            return new TransactionDTO
            {
                Type = transaction.Type,
                Amount = transaction.Amount,
                Category = transaction.Category,
                Date = transaction.Date,
                Description = transaction.Description
            };
        }

        public async Task<bool> DeleteTransactionAsync(int id, string userId)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
            {
                return false;
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TransactionDTO> GetTransactionByIdAsync(int id, string userId)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
            {
                return null;
            }

            return new TransactionDTO
            {
                Type = transaction.Type,
                Amount = transaction.Amount,
                Category = transaction.Category,
                Date = transaction.Date,
                Description = transaction.Description
            };
        }

        public async Task<IEnumerable<TransactionDTO>> GetUserTransactionsAsync(string userId)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId)
                .Select(t => new TransactionDTO
                {
                    Type = t.Type,
                    Amount = t.Amount,
                    Category = t.Category,
                    Date = t.Date,
                    Description = t.Description
                })
                .ToListAsync();
        }
    }
}
