using ApplicationLayer.IServices;
using DomainLayer.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresintationLayer.Controllers
{
    //[Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class DataExportController : ControllerBase
    {
        private readonly IDataExportService _dataExportService;
        private readonly UserManager<AppUser> _userManager;

        public DataExportController(IDataExportService dataExportService, UserManager<AppUser> userManager)
        {
            _dataExportService = dataExportService;
            _userManager = userManager;
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportUserData()
        {
            var userId = _userManager.GetUserId(User);
            var data = await _dataExportService.ExportUserDataAsync(userId);
            return File(data, "application/octet-stream", "userDataExport.zip");
        }

        [HttpPost("backup")]
        public async Task<IActionResult> BackupUserData()
        {
            var userId = _userManager.GetUserId(User);
            var result = await _dataExportService.BackupUserDataAsync(userId);
            if (!result)
            {
                return BadRequest("Failed to backup user data.");
            }
            return Ok("User data backed up successfully.");
        }

        [HttpPost("restore")]
        public async Task<IActionResult> RestoreUserData([FromBody] byte[] backupData)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _dataExportService.RestoreUserDataAsync(userId, backupData);
            if (!result)
            {
                return BadRequest("Failed to restore user data.");
            }
            return Ok("User data restored successfully.");
        }
    }
}
