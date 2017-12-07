using TokenManager.Api.Models;

namespace TokenManager.Api.Services
{
    public interface IAccountService
    {
        void SignUp(string username, string password);
        JsonWebToken SignIn(string username, string password);
        JsonWebToken RefreshAccessToken(string token);
        void RevokeRefreshToken(string token);
    }
}