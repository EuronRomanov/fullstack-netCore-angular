using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dto
{
    public class LoginUserReqDto
    {
        public string Email{get; set;}
        public string Password{get; set;}
    }


    public class LoginUserResDto
    {
        public string AccessToken{get; set;}
        
    }
}