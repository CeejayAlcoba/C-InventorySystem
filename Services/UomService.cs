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
        private readonly IProductService _productService;
        public UomService(IUnitOfWork unitOfWork, IUomRepository uomRepository,IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _uomRepository = uomRepository;
            _productService = productService;
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
            var productList = _unitOfWork.Products.GetAll().Where(c => c.UomId == Id);
            if (uom.IsDelete == true)
            {
                uom.IsDelete = false;
            }
            else
            {
                uom.IsDelete = true;
                _productService.DeleteProduct(productList);
            }
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
