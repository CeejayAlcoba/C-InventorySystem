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
        private readonly IColourRepository _colourRepository;

        public ColourService(IUnitOfWork unitOfWork,IColourRepository colourRepository)
        {
            _unitOfWork = unitOfWork;
            _colourRepository = colourRepository;

        }
        public Colour AddColour(Colour colour)
        {
            var getItemByName = _colourRepository.GetColourByName(colour.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {
                var newColour = new Colour()
                {
                    Name = colour.Name,
                    Description = colour.Description
                };
                _unitOfWork.Colours.Add(newColour);
                _unitOfWork.Complete();
                return newColour;

            }
            else return null;
          
            

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
