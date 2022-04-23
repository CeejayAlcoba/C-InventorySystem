using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        void UpdateCategory(Category category, int Id);
        Category AddCategory(Category category);
        void DeleteCategory(int Id);

    }
}
