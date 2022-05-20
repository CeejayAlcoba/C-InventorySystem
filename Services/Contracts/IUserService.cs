using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        void AddUser(User user);
        User UpdateUsername(User user, int userId);
        User DeleteUser(int userId);
        User RecoverUser(int userId);
        IEnumerable GetUser(bool isDelete = false);
    }
}
