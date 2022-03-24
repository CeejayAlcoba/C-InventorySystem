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
        private readonly IAccountService _accountService;
        public ProductService(IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }

        public void AddProduct(Product product)
        {
            var newProduct = new Product()
            {
                Code = product.Code,
                ProductName = product.ProductName,
                Brand = product.Brand,
                Price = product.Price,
                Quantity = product.Quantity,
                TotalPrice = product.Price * product.Quantity
            };
            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Complete();
        }



        public void UpdateProduct(Product product)
        {
            var getProductId = _unitOfWork.Products.GetById(product.ProductId);
            getProductId.Code = product.Code;
            getProductId.ProductName = product.ProductName;
            getProductId.Brand = product.Brand;
            getProductId.Price = product.Price;
            getProductId.Quantity = product.Quantity;
            getProductId.TotalPrice = getProductId.Price * getProductId.Quantity;
            _unitOfWork.Complete();
        }
        public void DeleteProduct(Product product)
        {
            var getProductId = _unitOfWork.Products.GetById(product.ProductId);
            _unitOfWork.Products.Remove(getProductId);
            _unitOfWork.Complete();
        }
    }
}
