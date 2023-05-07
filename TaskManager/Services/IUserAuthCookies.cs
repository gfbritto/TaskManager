using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using TaskManager.Models.User.Requests;

namespace TaskManager.Services
{
    public interface IUserAuthCookies
    {
        Task<IActionResult> Login(UserAuth userAuth);
    }
}
