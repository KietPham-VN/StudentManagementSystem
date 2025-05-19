using Application.DTOs.UserDTO;
using Domain.Entities;

namespace Application.Services.Interface
{
    public interface IUserService
    {
        public int Register(UserRegisterModel model);

        public User? Login(UserLoginModel model);

        string GenerateJwt(User model);
    }
}