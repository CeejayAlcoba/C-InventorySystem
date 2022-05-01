using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetProduct(
  int productId,
  bool includeUom,
  bool includeBrand,
  bool includeCategory,
  bool includeSize,
  bool includeColour);
        IEnumerable GetAllProduct(
  bool includeUom,
  bool includeBrand,
  bool includeCategory,
  bool includeSize,
  bool includeColour);
        Product GetProductByName(string name);
        IEnumerable GetMinimumStocks(bool includeUom, bool includeBrand, bool includeCategory, bool includeSize, bool includeColour);
    }
}
