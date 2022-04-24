using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryService _categoryService;
        public CategoryController(IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var categories = _unitOfWork.Categories.GetAll();
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            var getCategory = _categoryService.AddCategory(category);
            if (getCategory != null)
            {
                return Ok(getCategory);
            }
            return BadRequest("Name is already exist");

        }
        [HttpPatch]
        [Route("/api/category/id/{id}")]
        public IActionResult UpdateCategory(int Id, [FromBody] Category category)
        {
            var categoryId = _unitOfWork.Categories.GetById(Id);
            var getCategory = _unitOfWork.Categories.GetCategoryByName(category.Name);
            if (categoryId.Name != getCategory.Name)
            {
                if (getCategory == null)
                {
                    _categoryService.UpdateCategory(category, Id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Name is already exist");
                }

            }
            else
            {
                _categoryService.UpdateCategory(category, Id);
                return Ok();
            }

        }
        [HttpGet]
        [Route("/api/category/id/{id}")]
        public IActionResult GetCategoory(int Id)
        {
            var category = _unitOfWork.Categories.GetById(Id);
            return Ok(category);

        }
        [HttpDelete]
        [Route("/api/category/id/{id}")]
        public IActionResult DeleteCategory(int Id)
        {
            try
            {
                _categoryService.DeleteCategory(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
