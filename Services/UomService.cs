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
    public class UomService : IUomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Uom AddUom(Uom uom)
        {

                var newUom = new Uom()
                {
                    Name=uom.Name,
                    Description=uom.Description
                };
                _unitOfWork.Uoms.Add(newUom);
                _unitOfWork.Complete();
                return newUom;
          

        }

        public void DeleteUom(int Id)
        {
            var uom = _unitOfWork.Uoms.GetById(Id);
            _unitOfWork.Uoms.Remove(uom);
            _unitOfWork.Complete();

        }

        public void UpdateUom(Uom uom, int Id)
        {
            var getUom = _unitOfWork.Uoms.GetById(Id);
            getUom.Name = uom.Name;
            getUom.Description = uom.Description;
            _unitOfWork.Complete();

        }
    }
}
