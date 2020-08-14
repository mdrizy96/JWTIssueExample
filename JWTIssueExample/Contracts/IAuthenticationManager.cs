using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace JWTIssueExample.Contracts
{
    public interface IAuthenticationManager
    {
        Task<string> CreateToken();

        bool ValidateToken(string token);

        string GetXApiTokenFromHeader(HttpContext httpContext);

        string GetClaim(string token, string claimType);
    }
}