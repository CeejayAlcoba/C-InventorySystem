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

        public BrandService(IUnitOfWork unitOfWork, IBrandRepository brandRepository)
        {
            _unitOfWork = unitOfWork;
            _brandRepository = brandRepository;

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
        public void DeleteBrand(int Id)
        {
            var brand = _unitOfWork.Brands.GetById(Id);
            _unitOfWork.Brands.Remove(brand);
            _unitOfWork.Complete();

        }
    }
}
