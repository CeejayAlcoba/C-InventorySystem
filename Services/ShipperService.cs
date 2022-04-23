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
    public class ShipperService : IShipperService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShipperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Shipper AddShipper(Shipper shipper)
        {
            var getShipper = _unitOfWork.Shippers.GetShipperByName(shipper.Name);
            if (getShipper == null)
            {
                var newShipper = new Shipper()
                {
                    Name = shipper.Name,
                    Description = shipper.Description,
                    Street = shipper.Street,
                    City = shipper.City,
                    State = shipper.State,
                    Phone = shipper.Phone,
                    Email = shipper.Email
                };
                _unitOfWork.Shippers.Add(newShipper);
                _unitOfWork.Complete();
                return newShipper;
            }
            return null;



        }

        public void DeleteShipper(int Id)
        {
            var shipper = _unitOfWork.Shippers.GetById(Id);
            _unitOfWork.Shippers.Remove(shipper);
            _unitOfWork.Complete();
        }

        public void UpdateShipper(Shipper shipper, int Id)
        {
            var getShipper = _unitOfWork.Shippers.GetById(Id);
            getShipper.Name = shipper.Name;
            getShipper.Description = shipper.Description;
            getShipper.Street = shipper.Street;
            getShipper.City = shipper.City;
            getShipper.State = shipper.State;
            getShipper.Phone = shipper.Phone;
            getShipper.Email = shipper.Email;
            _unitOfWork.Complete();
        }
    }
}
