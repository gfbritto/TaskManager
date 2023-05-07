using RestEase;
using TaskManager.Models.Base;
using TaskManager.Models.User;
using TaskManager.Models.User.Requests;

namespace TaskManager.Services
{
    [Header("content-type", "application/json")]
    public interface IUserService
    {
        [Post("/user/new/")]
        Task<UserCreateResponse> Create([Body] UserRegister user);

        [Post("/user/update/")]
        Task<BaseResponse> Update([Body] UserRegister user);

        [Post("/user/delete/")]
        Task<BaseResponse> Delete([Body] UserAuth userAuth);

        [Post("/user/login/")]
        Task<UserLoginResponse> Login([Body] UserAuth userAuth);
    }
}
