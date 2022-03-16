using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contructs
{
    public interface IUserService
    {
        void AddUser(string firstName, string lastName, string username, string password);
        void UpdateUsername(string username,int userId);
    }
}
