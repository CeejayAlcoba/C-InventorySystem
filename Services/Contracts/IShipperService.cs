using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IShipperService
    {
        void UpdateShipper(Shipper shipper, int Id);
        Shipper AddShipper(Shipper shipper);
        void DeleteShipper(int Id);

    }
}
