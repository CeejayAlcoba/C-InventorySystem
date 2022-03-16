using Domain.Entities;
using Domain.Interfaces;
using Services;
using Services.Contructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
    