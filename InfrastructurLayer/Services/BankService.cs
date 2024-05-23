using ApplicationLayer.IServices;
using DomainLayer.Entitys;
using InfrastructurLayer.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructurLayer.Services
{
    public class BankService : IBankService
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly UserManager<AppUser> _userManager;

        public BankService(AppDbContext context, HttpClient httpClient , UserManager<AppUser> userManager)
        {
            _context = context;
            _httpClient = httpClient;
            _userManager = userManager;
        }

        public async Task<bool> ConnectBankAccountAsync(string userId, string bankAccountDetails)
        {
            var user =  _userManager.Users.SingleOrDefault(x=>x.Id == userId);
            if (user == null)
            {
                return false;
            }

            // Simulate an API call to connect the bank account
            var response = await _httpClient.PostAsync("https://api.example.com/connect",
                new StringContent(JsonSerializer.Serialize(new { userId, bankAccountDetails })));

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            user.BankAccountDetails = bankAccountDetails;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ImportBankTransactionsAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            // Simulate an API call to fetch transactions
            var response = await _httpClient.GetAsync($"https://api.example.com/transactions?userId={userId}");
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var transactionsJson = await response.Content.ReadAsStringAsync();
            var transactions = JsonSerializer.Deserialize<List<Transaction>>(transactionsJson);

            foreach (var transaction in transactions)
            {
                transaction.UserId = userId;
                _context.Transactions.Add(transaction);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
