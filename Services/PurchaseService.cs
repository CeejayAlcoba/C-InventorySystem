﻿using Domain.Entities;
using Domain.Interfaces;
using Services.Contracts;
using System;
using System.Globalization;

namespace Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Purchase AddPurchase(Purchase newPurchase)
        {
            var getProduct = _unitOfWork.Products.GetById(newPurchase.ProductId);
            var purchase = new Purchase {
                SupplierId = newPurchase.SupplierId,
                ProductId = newPurchase.ProductId,  
                Date = newPurchase.Date,
                Quantity= newPurchase.Quantity,
                Total = getProduct.Price * newPurchase.Quantity
                
            };
            getProduct.Quantity = getProduct.Quantity + purchase.Quantity;
            _unitOfWork.Purchases.Add(purchase);
            _unitOfWork.Complete();
            return purchase;
        }

        public void DeletePurchase(int purchaseId)
        {
            var result = _unitOfWork.Purchases.GetById(purchaseId);
            _unitOfWork.Purchases.Remove(result);
            _unitOfWork.Complete();
        }

        public Purchase GetPurchase(int purchaseId)
        {
            return _unitOfWork.Purchases.GetPurchase(purchaseId);
        }

        public Purchase UpdatePurchase(Purchase newPurchase)
        {
            var purchase = _unitOfWork.Purchases.GetById(newPurchase.PurchaseId);
            purchase.SupplierId = newPurchase.SupplierId;
            purchase.ProductId = newPurchase.ProductId;
            purchase.Date = newPurchase.Date;
            purchase.Quantity = newPurchase.Quantity;
            purchase.Total = newPurchase.Product.Price * newPurchase.Quantity;
            _unitOfWork.Complete();
            return purchase;
        }
    }
}
