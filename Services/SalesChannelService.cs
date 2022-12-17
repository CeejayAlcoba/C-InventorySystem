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
    public class SalesChannelService : ISalesChannelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISalesChannelRepository _salesChannelRepository;
        private readonly ISalesOrderService _salesOrderService;
        public SalesChannelService(IUnitOfWork unitOfWork,ISalesChannelRepository salesChannelRepository,ISalesOrderService salesOrderService)
        {
            _unitOfWork = unitOfWork;
            _salesChannelRepository = salesChannelRepository;
            _salesOrderService = salesOrderService;

        }
        public SalesChannel AddSalesChannel(SalesChannel salesChannel)
        {
            var getItemByName = _salesChannelRepository.GetSalesChannelByName(salesChannel.Name);
            if (getItemByName == null || getItemByName.IsDelete == true)
            {
                var newSalesChannel = new SalesChannel()
                {
                    Name = salesChannel.Name,
                    Description = salesChannel.Description
                };
                _unitOfWork.SalesChannels.Add(newSalesChannel);
                _unitOfWork.Complete();
                return newSalesChannel;

            }
            else return null;
           
            
        }

        public void DeleteSalesChannel(int Id)
        {
            var salesChannel = _unitOfWork.SalesChannels.GetById(Id);
            var salesOrderList = _unitOfWork.SalesOrders.GetAll().Where(c => c.SalesChannelId == Id);
            if (salesChannel.IsDelete == true)
            {
                salesChannel.IsDelete = false;
            }
            else
            {
                salesChannel.IsDelete = true;
                _salesOrderService.CancelSalesOrder(salesOrderList);
            }
            _unitOfWork.Complete();
        }

        public void UpdateSalesChannel(SalesChannel salesChannel, int Id)
        {
            var getSalesChannel = _unitOfWork.SalesChannels.GetById(Id);
            getSalesChannel.Name = salesChannel.Name;
            getSalesChannel.Description = salesChannel.Description;
            _unitOfWork.Complete();
        }
    }
}
