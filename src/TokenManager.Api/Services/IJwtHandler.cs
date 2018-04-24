using System.Collections.Generic;
using System.Security.Claims;
using TokenManager.Api.Models;

namespace TokenManager.Api.Services
{
    public interface IJwtHandler
    {
        JsonWebToken Create(string username);
    }
}