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
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Sale AddSale(Sale newSale)
        {
            var sale = new Sale()
            {
                CustomerId = newSale.CustomerId,
                ProductId = newSale.ProductId,
                Date = newSale.Date,
                Quantity = newSale.Quantity,
                Total = newSale.Product.Price * newSale.Quantity

            };
            _unitOfWork.Sales.Add(sale);
            _unitOfWork.Complete();
            return sale;
        }

        public void DeleteSale(int saleId)
        {
            var result = _unitOfWork.Sales.GetById(saleId);
            _unitOfWork.Sales.Remove(result);
            _unitOfWork.Complete();
        }

        public Sale GetSale(int saleId)
        {
            return _unitOfWork.Sales.GetPurchase(saleId,true,true);
        }

        public Sale UpdateSale(Sale newSale)
        {
            var sale = _unitOfWork.Sales.GetById(newSale.SaleId);
            sale.ProductId = newSale.ProductId;
            sale.CustomerId = newSale.CustomerId;
            sale.Date = newSale.Date;
            sale.Quantity = newSale.Quantity;
            sale.Total = newSale.Product.ProductId * newSale.Quantity;
            return (sale);
        }
    }
}
