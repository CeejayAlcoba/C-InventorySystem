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
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
        public SupplierService(IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }
        public void AddSupplier(Supplier supplier)
        {
            var newSupplier = new Supplier
            {
                SupplierName = supplier.SupplierName,
                Address = supplier.Address,
                ContactNumber = supplier.ContactNumber
            };
            _unitOfWork.Suppliers.Add(newSupplier);
            _unitOfWork.Complete();

        }

        public void DeleteSupplier(Supplier supplier)
        {
            var getSupplierById = _unitOfWork.Suppliers.GetById(supplier.SupplierId);
            _unitOfWork.Suppliers.Remove(getSupplierById);
            _unitOfWork.Complete();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            var getSupplierById = _unitOfWork.Suppliers.GetById(supplier.SupplierId);
            getSupplierById.SupplierName = supplier.SupplierName;
            getSupplierById.Address = supplier.Address;
            getSupplierById.ContactNumber = supplier.ContactNumber;
            _unitOfWork.Complete();

        }
        
    }
}
