using Application.DTOs.UserDTO;
using Application.Helpers;
using Application.Services.Interface;
using Domain.Entities;

namespace Application.Services.Implementation;

public class UserService(IApplicationDbContext context) : IUserService
{
    public User? Login(UserLoginModel model)
    {
        var user = context.Users
            .FirstOrDefault(x => x.EmailAddress == model.EmailAddress);
        if (user == null) return null;
        var hashPassword = HashHelper.BCryptHash(model.Password, user.Salt);
        if (user.Password != hashPassword) return null;
        return user;
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