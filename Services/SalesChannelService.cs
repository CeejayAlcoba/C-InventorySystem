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

        public SalesChannelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public SalesChannel AddSalesChannel(SalesChannel salesChannel)
        {
            var getSalesChannel = _unitOfWork.SalesChannels.GetSalesChannelByName(salesChannel.Name);
            if (getSalesChannel == null)
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
            else
                return null;
            
        }

        public void DeleteSalesChannel(int Id)
        {
            var salesChannel = _unitOfWork.SalesChannels.GetById(Id);
            _unitOfWork.SalesChannels.Remove(salesChannel);
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
