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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Product AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
            return product;

        }

        public void DeleteProduct(int Id)
        {
            var product = _unitOfWork.Products.GetById(Id);
            _unitOfWork.Products.Remove(product);
            _unitOfWork.Complete();
        }

        public void UpdateProduct(Product product, int Id)
        {
            var getProduct = _unitOfWork.Products.GetById(Id);
            getProduct.Name = product.Name;
            getProduct.Description = product.Description;
            getProduct.UomId = product.UomId;
            getProduct.Quantity = product.Quantity;
            getProduct.BrandId = product.BrandId;
            getProduct.CategoryId = product.CategoryId;
            getProduct.SizeId = product.SizeId;
            getProduct.ColourId = product.ColourId;
            _unitOfWork.Complete();
        }
    }
}
