using ApplicationLayer.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface IAuthService
    {
        Task<AuthServiceResponseDto> RegisterAsync(RegisterDTO registerDto);
        Task<AuthServiceResponseDto> LoginAsync(LoginDTO loginDto);
    }
}
