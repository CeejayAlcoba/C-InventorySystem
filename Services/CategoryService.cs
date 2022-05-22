using Domain.Entities;
using Domain.Interfaces;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService :ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public void UpdateCategory(Category category, int Id)
        {
            var getCategory = _unitOfWork.Categories.GetById(Id);
            getCategory.Name = category.Name;
            getCategory.Description = category.Description;
            _unitOfWork.Complete();

        }
        public Category AddCategory(Category category)
        {
            var getCategory = _unitOfWork.Categories.GetCategoryByName(category.Name);
            if (getCategory == null)
            {
                var newCategory = new Category()
                {
                    Name = category.Name,
                    Description=category.Description
                };
                _unitOfWork.Categories.Add(newCategory);
                _unitOfWork.Complete();
                return newCategory;
            }
            return null;

        }
        public void DeleteCategory(int Id)
        {
            var category = _unitOfWork.Categories.GetById(Id);
            _unitOfWork.Categories.Remove(category);
            _unitOfWork.Complete();

        }

    }
}
