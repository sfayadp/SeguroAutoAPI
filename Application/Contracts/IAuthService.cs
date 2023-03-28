using Microsoft.AspNetCore.Mvc;

namespace SeguroAutoAPI.Application.Contracts
{
    public interface IAuthService
    {
        bool ValidateUser(string username, string password);
        IActionResult Login(string username, string password);
    }
}
