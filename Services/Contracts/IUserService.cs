﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        void AddUser(User user);
        void UpdateUsername(User user, int userId);
        void DeleteUser(int userId);
    }
}
