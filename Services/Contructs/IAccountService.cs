using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contructs
{
    public interface IAccountService
    {
        string GenerateJwtToken(string username);
        string GetUserToken(string username, string password);
        string GenerateHashPassword(string password, byte[] salt);
        byte[] GenerateSalt(string password);
        User ValidateUser(string username, string password);
        void ChangePassword(string username, string newHashedPassword);
        void EditUsername(string username, string newUsername);
        void ChangeName(string username, string firstname, string lastname);



    }
}
