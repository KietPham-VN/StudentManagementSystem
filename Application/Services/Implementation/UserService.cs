using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs.UserDTO;
using Application.Helpers;
using Application.Services.Interface;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Implementation;

public class UserService(IApplicationDbContext context, IOptions<JwtSettings> jwtSettingOptions) : IUserService
{
    public string GenerateJwt(User model)
    {
        var jwtSetings = jwtSettingOptions.Value;
        var key = jwtSetings.SecretKey;
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, model.UserName),
            new Claim(ClaimTypes.Email, model.EmailAddress),
            new Claim(ClaimTypes.Role, model.Role.ToString())
        };
        var token = new JwtSecurityToken(
            issuer: jwtSetings.Issuer,
            audience: jwtSetings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSetings.ExpirationInMinutes),
            signingCredentials: new SigningCredentials
            (
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256
            )
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public User? Login(UserLoginModel model)
    {
        var user = context.Users
            .FirstOrDefault(x => x.EmailAddress == model.EmailAddress);

        if (user == null) return null;

        // So sánh mật khẩu đúng cách
        bool isPasswordValid = HashHelper.BCryptVerify(model.Password, user.Password);
        if (!isPasswordValid) return null;

        return user;
    }

    public int Register(UserRegisterModel model)
    {
        bool existed = context.Users.Any(u =>
            u.UserName.ToLower() == model.Username.ToLower() ||
            u.EmailAddress.ToLower() == model.Email.ToLower()
        );

        if (existed) return -1;

        var hashPassword = HashHelper.BCryptHash(model.Password);

        var data = new User
        {
            UserName = model.Username,
            EmailAddress = model.Email,
            Password = hashPassword,
        };

        context.Users.Add(data);
        context.SaveChanges();
        return data.Id;
    }
}