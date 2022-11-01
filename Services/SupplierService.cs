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
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(IUnitOfWork unitOfWork,ISupplierRepository supplierRepository)
        {
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;

        }
        public Supplier AddSupplier(Supplier supplier)
        {
            var getSupplierByName = _supplierRepository.GetSupplierByName(supplier.Name);
            if (getSupplierByName == null || getSupplierByName.IsDelete == true)
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
            else return null;

        }

        public void DeleteSupplier(int Id)
        {
            var item = _unitOfWork.Suppliers.GetById(Id);
            if (item.IsDelete == true)
            {
                item.IsDelete = false;
                _unitOfWork.Complete();
            }
            else
            {
                item.IsDelete = true;
                _unitOfWork.Complete();
            }

        }

        public Supplier UpdateSupplier(Supplier supplier, int Id)
        {
            var getSupplierByName = _supplierRepository.GetSupplierByName(supplier.Name);
            var supplierId = _unitOfWork.Suppliers.GetById(Id);
            if (getSupplierByName.SupplierId==supplierId.SupplierId ||  getSupplierByName == null)
            {
                var getSupplier = _unitOfWork.Suppliers.GetById(Id);
                getSupplier.Name = supplier.Name;
                getSupplier.Description = supplier.Description;
                getSupplier.Street = supplier.Street;
                getSupplier.City = supplier.City;
                getSupplier.State = supplier.State;
                getSupplier.Phone = supplier.Phone;
                getSupplier.Email = supplier.Email;
                getSupplier.IsDelete = false;
                _unitOfWork.Complete();
                return getSupplier;
            }
            else return null;

        }
    }
}
