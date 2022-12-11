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
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductService _productService;
        public BrandService(IUnitOfWork unitOfWork, IBrandRepository brandRepository,IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _brandRepository = brandRepository;
            _productService = productService;

        }
        public void UpdateBrand(Brand brand, int Id)
        {
            var getbrand = _unitOfWork.Brands.GetById(Id);
            getbrand.Name = brand.Name;
            getbrand.Description = brand.Description;
            _unitOfWork.Complete();
        }
        public Brand AddBrand(Brand brand)
        {
            var getItemByName = _brandRepository.GetBrandByName(brand.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {
                var NewBrand = new Brand()
                {
                    Name = brand.Name,
                    Description = brand.Description
                };
                _unitOfWork.Brands.Add(NewBrand);
                _unitOfWork.Complete();
                return NewBrand;

            }
            else return null;
        }
        public void DeleteBrand(int id)
        {
            var brand = _unitOfWork.Brands.GetById(id);
            var productList = _unitOfWork.Products.GetAll().Where(c=>c.BrandId==id);

            if (brand.IsDelete == true)
            {
                brand.IsDelete = false;
            }
            else
            {
                brand.IsDelete = true;
                _productService.DeleteProduct(productList);
            }
            _unitOfWork.Complete();

        }
    }
}
