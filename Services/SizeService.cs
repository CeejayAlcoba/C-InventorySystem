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
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISizeRepository _sizeRepository;
        private readonly IProductService _productService;
        public SizeService(IUnitOfWork unitOfWork, ISizeRepository sizeRepository,IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _sizeRepository = sizeRepository;
            _productService = productService;

        }
        public Size AddSize(Size size)
        {
            var getItemByName = _sizeRepository.GetSizeByName(size.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {
                var newSize = new Size()
                {
                    Name = size.Name,
                    Description = size.Description

                };
                _unitOfWork.Sizes.Add(newSize);
                _unitOfWork.Complete();
                return newSize;
            }
            else return null;
        }

        public void DeleteSize(int Id)
        {
            var size = _unitOfWork.Sizes.GetById(Id);
            var productList = _unitOfWork.Products.GetAll().Where(c => c.SizeId == Id);
            if (size.IsDelete == true)
            {
                size.IsDelete = false;
            }
            else
            {
                size.IsDelete = true;
                _productService.DeleteProduct(productList);
            }
            _unitOfWork.Complete();

        }

        public void UpdateSize(Size size, int Id)
        {
            var getSize = _unitOfWork.Sizes.GetById(Id);
            getSize.Name = size.Name;
            getSize.Description = size.Description;
            _unitOfWork.Complete();

        }
    }
}
