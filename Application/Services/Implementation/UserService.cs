using Application.DTOs.UserDTO;
using Application.Helpers;
using Application.Services.Interface;
using Domain.Entities;

namespace Application.Services.Implementation;

public class UserService(IApplicationDbContext context) : IUserService
{
    public bool Login(UserLoginModel model)
    {
        var user = context.Users
            .FirstOrDefault(x => x.EmailAddress == model.EmailAddress);

        return user != null &&
            HashHelper.BCryptVerify(model.Password, user.Password, user.Salt);
    }

    public int Register(UserRegisterModel model)
    {
        bool existed = context.Users.Any(u =>
            u.UserName == model.Username || u.EmailAddress == model.Email);
        if (existed) return -1;

        var salt = HashHelper.GenerateSalt();
        var hashPassword = HashHelper.BCryptHash(model.Password, salt);

        var data = new User
        {
            UserName = model.Username,
            EmailAddress = model.Email,
            Password = hashPassword,
            Salt = salt
        };

        context.Users.Add(data);
        context.SaveChanges();
        return data.Id;
    }
}