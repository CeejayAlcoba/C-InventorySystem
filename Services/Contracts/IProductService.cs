using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Contracts
{
    public interface IProductService
    {
        void UpdateProduct(Product product,int Id);
        Product AddProduct(Product product);
        void DeleteProduct(int Id);
    }
}
