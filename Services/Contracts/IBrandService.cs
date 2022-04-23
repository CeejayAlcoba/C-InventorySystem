using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBrandService
    {
        void UpdateBrand(Brand brand, int Id);
        Brand AddBrand(Brand brand);
        void DeleteBrand(int Id);

    }
}
