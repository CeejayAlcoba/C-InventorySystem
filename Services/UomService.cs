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
        private readonly IUomRepository _uomRepository;

        public UomService(IUnitOfWork unitOfWork, IUomRepository uomRepository)
        {
            _unitOfWork = unitOfWork;
            _uomRepository = uomRepository;
        }
        public Uom AddUom(Uom uom)
        {
            var getItemByName = _uomRepository.GetUomByName(uom.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {
                var newUom = new Uom()
                {
                    Name = uom.Name,
                    Description = uom.Description,
                    MinimumStockAlert = uom.MinimumStockAlert
                };
                _unitOfWork.Uoms.Add(newUom);
                _unitOfWork.Complete();
                return newUom;
            }
            else return null;
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
            getUom.MinimumStockAlert = uom.MinimumStockAlert;
            _unitOfWork.Complete();

        }
    }
}
