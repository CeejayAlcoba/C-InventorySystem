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


            var newProduct = new Product()
            {

                Name = product.Name,
                Description = product.Description,
                UomId = product.UomId,
                Quantity = product.Quantity,
                BradnId = product.BradnId,
                CategoryId = product.CategoryId,
                SizeId = product.SizeId,
                ColourId = product.ColourId
            };
            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Complete();
            return newProduct;

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
            getProduct.BradnId = product.BradnId;
            getProduct.CategoryId = product.CategoryId;
            getProduct.SizeId = product.SizeId;
            getProduct.ColourId = product.ColourId;
            _unitOfWork.Complete();
        }
    }
}
