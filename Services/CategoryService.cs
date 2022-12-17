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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductService _productService;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository,IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _productService = productService;

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
            var getItemByName = _categoryRepository.GetCategoryByName(category.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {
                var newCategory = new Category()
                {
                    Name = category.Name,
                    Description = category.Description
                };
                _unitOfWork.Categories.Add(newCategory);
                _unitOfWork.Complete();
                return newCategory;

            }
            else return null;

        }
        public void DeleteCategory(int Id)
        {
            var category = _unitOfWork.Categories.GetById(Id);
            var productList = _unitOfWork.Products.GetAll().Where(c => c.CategoryId == Id);
            if (category.IsDelete == true)
            {
                category.IsDelete = false;

            }
            else
            {
                category.IsDelete = true;
                _productService.DeleteProduct(productList);
            }
            _unitOfWork.Complete();
        }

    }
}
