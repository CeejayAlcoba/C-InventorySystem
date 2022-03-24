using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
        string GetUserToken(string username, string password);
        string GenerateHashPassword(string password, byte[] salt);
        byte[] GenerateSalt(string password);
        User ValidateUser(string username, string password);
        
       



    }
}
