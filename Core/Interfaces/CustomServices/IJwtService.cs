using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Core.Interfaces.CustomServices
{
    public interface IJwtService
    {
        IEnumerable<Claim> SetClaims(ApplicationUser user);
        string CreateToken(ApplicationUser user);
    }
}
