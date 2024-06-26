﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class RoleRepositoy : GenericRepository<Role>, IRoleRepository
    {

        public RoleRepositoy(ApplicationContext context) : base(context)
        {
        }
    }
}
