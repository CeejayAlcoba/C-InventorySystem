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
        private readonly ILocationRepository _locationRepository;

        public LocationService(IUnitOfWork unitOfWork, ILocationRepository locationRepository)
        {
            _unitOfWork = unitOfWork;
            _locationRepository = locationRepository;

        }
        public Location AddLocation(Location location)
        {
            var getItemByName = _locationRepository.GetLocationByName(location.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {
                var newLocation = new Location()    
                {
                    Name = location.Name,
                    Description = location.Description
                };
                _unitOfWork.Locations.Add(newLocation);
                _unitOfWork.Complete();
                return newLocation;

            }
            else return null;
          
            

        }

        public void DeleteLocation(int Id)
        {
            var location = _unitOfWork.Locations.GetById(Id);
            _unitOfWork.Locations.Remove(location);
            _unitOfWork.Complete();
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
