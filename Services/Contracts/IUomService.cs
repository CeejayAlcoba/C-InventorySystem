using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUomService
    {
        void UpdateUom(Uom uom, int Id);
        Uom AddUom(Uom uom);
        void DeleteUom(int Id);

    }
}
