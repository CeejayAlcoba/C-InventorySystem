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
            throw new NotImplementedException();
        }

        public void DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
