using Application.DTOs.UserDTO;

namespace Application.Services.Interface
{
    public interface IUserService
    {
        public int Register(UserRegisterModel model);

        public bool Login(UserLoginModel model);
    }
}