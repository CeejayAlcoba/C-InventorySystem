using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISizeService
    {
        void UpdateSize(Size size, int Id);
        Size AddSize(Size size);
        void DeleteSize(int Id);

    }
}
