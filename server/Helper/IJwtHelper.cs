using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Entities;
using System.Security.Claims;

namespace server.Helper
{
    public interface IJwtHelper
    {
        string GenerateJwtToken(User user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}
