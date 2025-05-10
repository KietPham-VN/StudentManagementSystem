using Application.DTOs.UserDTO;

namespace TodoWeb.Application.Services.User
{
    public interface IUserService
    {
        public int Register(RegisterUserModel user);

        public bool Login(UserLoginModel user);
    }
}