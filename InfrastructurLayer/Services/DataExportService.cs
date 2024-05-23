using ApplicationLayer.IServices;
using DomainLayer.Entitys;
using InfrastructurLayer.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructurLayer.Services
{
    public class DataExportService : IDataExportService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DataExportService(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<byte[]> ExportUserDataAsync(string userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Transactions)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var userData = new
            {
                User = user,
                Transactions = user.Transactions
            };

            var json = JsonSerializer.Serialize(userData);
            return System.Text.Encoding.UTF8.GetBytes(json);
        }

        public async Task<bool> BackupUserDataAsync(string userId)
        {
            var userData = await ExportUserDataAsync(userId);
            var backupPath = GetBackupPath(userId);

            await File.WriteAllBytesAsync(backupPath, userData);
            return true;
        }

        public async Task<bool> RestoreUserDataAsync(string userId, byte[] backupData)
        {
            var json = System.Text.Encoding.UTF8.GetString(backupData);
            var userData = JsonSerializer.Deserialize<UserData>(json);

            var user =  _userManager.Users.SingleOrDefault(x=>x.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            // Update user data
            user.BankAccountDetails = userData.User.BankAccountDetails;

            // Remove existing transactions
            var existingTransactions = await _context.Transactions
                .Where(t => t.UserId == userId)
                .ToListAsync();

            _context.Transactions.RemoveRange(existingTransactions);

            // Add restored transactions
            foreach (var transaction in userData.Transactions)
            {
                transaction.UserId = userId; // Ensure the UserId is set
                _context.Transactions.Add(transaction);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private string GetBackupPath(string userId)
        {
            var backupDirectory = Path.Combine(AppContext.BaseDirectory, "Backups");
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }

            return Path.Combine(backupDirectory, $"{userId}_backup.json");
        }

        private class UserData
        {
            public AppUser User { get; set; }
            public List<Transaction> Transactions { get; set; }
        }
    }
}
