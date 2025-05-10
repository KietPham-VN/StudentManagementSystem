using Application.DTOs.UserDTO;
using Application.Helpers;

namespace TodoWeb.Application.Services.User
{
    //brute force
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _context;

        public UserService(IApplicationDbContext context)
        {
            _context = context;
        }

        //Salting: đã mặn thêm muối
        public bool Login(UserLoginModel loginModel)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.EmailAddress == loginModel.EmailAddress);
            return user != null &&
                HashHelper.BCriptVerify(loginModel.Password, user.Password);
        }

        public int Register(RegisterUserModel user)
        {
            //kiểm tra xem user id có bị trùng hay không
            var id = _context.Users.Find(user.Id);
            if (id != null || user.Id <= 1)
            {
                return -1;
            }
            var hashPassword = HashHelper.BCriptHash(user.Password);

            var data = new Domain.Entities.User
            {
                UserName = user.Username,
                EmailAddress = user.Email,
                Password = hashPassword,
            };

            _context.Users.Add(data);
            _context.SaveChanges();
            return data.Id;
        }
    }
}