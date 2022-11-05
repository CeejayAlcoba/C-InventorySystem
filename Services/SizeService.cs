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
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISizeRepository _sizeRepository;

        public SizeService(IUnitOfWork unitOfWork, ISizeRepository sizeRepository)
        {
            _unitOfWork = unitOfWork;
            _sizeRepository = sizeRepository;

        }
        public Size AddSize(Size size)
        {
            var getItemByName = _sizeRepository.GetSizeByName(size.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {
                var newSize = new Size()
                {
                    Name = size.Name,
                    Description = size.Description

                };
                _unitOfWork.Sizes.Add(newSize);
                _unitOfWork.Complete();
                return newSize;
            }
            else return null;
        }

        public void DeleteSize(int Id)
        {
            var size = _unitOfWork.Sizes.GetById(Id);
            _unitOfWork.Sizes.Remove(size);
            _unitOfWork.Complete();

        }

        public void UpdateSize(Size size, int Id)
        {
            var getSize = _unitOfWork.Sizes.GetById(Id);
            getSize.Name = size.Name;
            getSize.Description = size.Description;
            _unitOfWork.Complete();

        }
    }
}
