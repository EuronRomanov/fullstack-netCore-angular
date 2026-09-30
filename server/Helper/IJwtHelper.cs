using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Entities;

namespace server.Helper
{
    public interface IJwtHelper
    {
        string GenerateJwtToken(User user);

    }
}