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
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;

        }
        public Product AddProduct(Product product)
        {
            var getItemByName = _productRepository.GetProductByName(product.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {
                if (product.PurchaseTax == 0)
                {
                    var newProduct = new Product()
                    {
                        Name = product.Name,
                        Description = product.Description,
                        UomId = product.UomId,
                        Quantity = product.Quantity,
                        BrandId = product.BrandId,
                        CategoryId = product.CategoryId,
                        SizeId = product.SizeId,
                        ColourId = product.ColourId,
                        PurchasePrice = product.PurchasePrice,
                        SalesPrice = product.SalesPrice,
                        PurchaseTax = product.PurchaseTax,
                        SalesTax = product.SalesTax,
                        TotalPrice = (product.Quantity * product.PurchasePrice)
                    };
                    _unitOfWork.Products.Add(newProduct);
                    _unitOfWork.Complete();
                }
                else
                {
                    var newProduct = new Product()
                    {
                        Name = product.Name,
                        Description = product.Description,
                        UomId = product.UomId,
                        Quantity = product.Quantity,
                        BrandId = product.BrandId,
                        CategoryId = product.CategoryId,
                        SizeId = product.SizeId,
                        ColourId = product.ColourId,
                        PurchasePrice = product.PurchasePrice,
                        SalesPrice = product.SalesPrice,
                        PurchaseTax = product.PurchaseTax,
                        SalesTax = product.SalesTax,
                        TotalPrice = (product.Quantity * product.PurchasePrice) - (product.Quantity * product.PurchasePrice) * (0.01 * product.PurchaseTax)
                    };
                    _unitOfWork.Products.Add(newProduct);
                    _unitOfWork.Complete();
                }
                return product;

            }
            else return null;
           

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
            getProduct.PurchasePrice = product.PurchasePrice;
            getProduct.SalesPrice = product.SalesPrice;
            getProduct.PurchaseTax = product.PurchaseTax;
            getProduct.SalesTax = product.SalesTax;
            _unitOfWork.Complete();
        }
    }
}
