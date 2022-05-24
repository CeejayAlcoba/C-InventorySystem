
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class AccountService : IAccountService
    {


        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;

        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("username", user.Username),
                     new Claim("firstname", user.Firstname),
                      new Claim("lastname", user.Lastname),

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public byte[] GenerateSalt(string password)
        {
            var salt = new byte[128 / 8];

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return salt;
        }

        public string GenerateHashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;
        }


        public string GetUserToken(string username, string password)
        {
            var user = ValidateUser(username, password);

            if (user == null) return null;

            return "";
        }

        public Domain.Entities.User ValidateUser(string username, string password)
        {
            var user = _unitOfWork.Users.GetUserByUsername(username);
            if (user == null) return null;
            var hashedPassword = GenerateHashPassword(password, user.Salt);
            if (hashedPassword != user.HashPassword) return null;
                return user;
        }

       
    }
}
