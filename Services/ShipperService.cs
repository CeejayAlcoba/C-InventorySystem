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
        private readonly IShipperRepository _shipperRepository;
        public ShipperService(IUnitOfWork unitOfWork, IShipperRepository shipperRepository)
        {
            _unitOfWork = unitOfWork;
            _shipperRepository = shipperRepository;

        }
        public Shipper AddShipper(Shipper shipper)
        {
            var getItemByName = _shipperRepository.GetShipperByName(shipper.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {

                var newShipper = new Shipper()
                {
                    Name = shipper.Name,
                    Description = shipper.Description,
                    Street = shipper.Street,
                    City = shipper.City,
                    State = shipper.State,
                    Phone = shipper.Phone,
                    ZipCode = shipper.ZipCode,
                    Email = shipper.Email
                };
                _unitOfWork.Shippers.Add(newShipper);
                _unitOfWork.Complete();
                return newShipper;

            }
            else return null;
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
            getShipper.ZipCode = shipper.ZipCode;
            getShipper.Phone = shipper.Phone;
            getShipper.Email = shipper.Email;
            _unitOfWork.Complete();
        }
    }
}
