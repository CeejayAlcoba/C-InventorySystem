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
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Location AddLocation(Location location)
        {
            var getLocation = _unitOfWork.Locations.GetLocationByName(location.Name);
            if (getLocation == null)
            {
                var newLocation = new Location()
                {
                    Name=location.Name,
                    Description=location.Description
                };
                _unitOfWork.Locations.Add(newLocation);
                _unitOfWork.Complete();
                return newLocation;
            }
            return null;


        }

        public void DeleteLocation(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLocation(Location location, int Id)
        {
            var getLocation = _unitOfWork.Locations.GetById(Id);
            getLocation.Name = location.Name;
            getLocation.Description = location.Description;
            _unitOfWork.Complete();

        }
    }
}
