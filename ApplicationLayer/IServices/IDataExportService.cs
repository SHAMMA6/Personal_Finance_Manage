using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface IDataExportService
    {
        Task<byte[]> ExportUserDataAsync(string userId);
        Task<bool> BackupUserDataAsync(string userId);
        Task<bool> RestoreUserDataAsync(string userId, byte[] backupData);
    }
}
