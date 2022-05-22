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

        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

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

            var getBrand = _unitOfWork.Brands.GetBrandByName(brand.Name);
            if (getBrand == null)
            {
                var NewBrand = new Brand()
                {
                   Name = brand.Name,
                   Description=brand.Description
                };
                _unitOfWork.Brands.Add(NewBrand);
                _unitOfWork.Complete();
                return NewBrand;
            }
            return null;
        }
        public void DeleteBrand(int Id)
        {
            var brand = _unitOfWork.Brands.GetById(Id);
            _unitOfWork.Brands.Remove(brand);
            _unitOfWork.Complete();

        }
    }
}
