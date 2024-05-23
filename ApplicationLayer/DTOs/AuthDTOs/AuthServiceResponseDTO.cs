using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs.AuthDTOs
{
    public class AuthServiceResponseDto
    {


        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }


    }
}
