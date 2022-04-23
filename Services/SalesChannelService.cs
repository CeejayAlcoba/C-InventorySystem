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
            throw new NotImplementedException();
        }

        public void DeleteSalesChannel(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSalesChannel(SalesChannel salesChannel, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
