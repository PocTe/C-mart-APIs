using C_mart_APIs.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace C_mart_APIs.Repository
{
    public class TokenHandler : ITokenHandler

    {   
        private readonly IConfiguration configuration;
        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateTokenAsync(User user)
        {
            
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.Firstname));
            claims.Add(new Claim(ClaimTypes.Surname, user.lastname));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            //loop into user roles
            //user.Roles.ForEach((role) =>
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //});
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                 configuration["Jwt:Audience"],
                 claims,
                 expires: DateTime.Now.AddDays(30),
                 signingCredentials: credentials );
          return  Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
