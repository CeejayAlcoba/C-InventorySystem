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

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Supplier AddSupplier(Supplier supplier)
        {
            var getSupplier = _unitOfWork.Suppliers.GetSupplierByName(supplier.Name);
            if (getSupplier == null)
            {
                var newSupplier = new Supplier()
                {
                    Name = supplier.Name,
                    Description = supplier.Description,
                    Street = supplier.Street,
                    City = supplier.City,
                    State = supplier.State,
                    Phone = supplier.Phone,
                    Email = supplier.Email
                };
                _unitOfWork.Suppliers.Add(newSupplier);
                _unitOfWork.Complete();
                return newSupplier;
            }
            return null;

        }

        public void DeleteSupplier(int Id)
        {
            var supplier = _unitOfWork.Suppliers.GetById(Id);
            _unitOfWork.Suppliers.Remove(supplier);
            _unitOfWork.Complete();

        }

        public void UpdateSupplier(Supplier supplier, int Id)
        {
            var getSupplier = _unitOfWork.Suppliers.GetById(Id);
            getSupplier.Name = supplier.Name;
            getSupplier.Description = supplier.Description;
            getSupplier.Street = supplier.Street;
            getSupplier.City = supplier.City;
            getSupplier.State = supplier.State;
            getSupplier.Phone = supplier.Phone;
            getSupplier.Email = supplier.Email;
            _unitOfWork.Complete();

        }
    }
}
