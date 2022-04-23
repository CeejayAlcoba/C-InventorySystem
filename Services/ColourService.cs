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
    public class ColourService : IColourService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColourService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Colour AddColour(Colour colour)
        {
            var getColour = _unitOfWork.Colours.GetColourByName(colour.Name);
            if (getColour == null)
            {
                var newColour = new Colour()
                {
                    Name = colour.Name,
                    Description=colour.Description
                };
                _unitOfWork.Colours.Add(newColour);
                _unitOfWork.Complete();
                return newColour;
            }
            return null;

        }

        public void DeleteColour(int Id)
        {
            var colour = _unitOfWork.Colours.GetById(Id);
            _unitOfWork.Colours.Remove(colour);
            _unitOfWork.Complete();

        }

        public void UpdateColour(Colour colour, int Id)
        {
            var getColour = _unitOfWork.Colours.GetById(Id);
            getColour.Name = colour.Name;
            getColour.Description = colour.Description;
            _unitOfWork.Complete();

        }
    }
}
