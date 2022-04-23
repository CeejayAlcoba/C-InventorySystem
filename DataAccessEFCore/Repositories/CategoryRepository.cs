﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ApplicationContext context) : base(context)
        {
        }

        public Category GetCategoryByName(string name)
        {
            return _context.Categories.FirstOrDefault(x => x.Name == name);
        }
    }
}
