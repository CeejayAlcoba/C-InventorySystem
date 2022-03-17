using Domain.Entities;
using Domain.Interfaces;
using Services.Contructs;
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
                ProductName = product.ProductName,
                Brand = product.Brand,
                Quantity = product.Quantity
            };
            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Complete();
        }



        public void UpdateProduct(Product product)
        {
            var getProductId = _unitOfWork.Products.GetById(product.ProductId);
            getProductId.ProductName = product.ProductName;
            getProductId.Brand = product.Brand;
            getProductId.Quantity = product.Quantity;
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
