using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILocationService
    {
        void UpdateLocation(Location location, int Id);
        Location AddLocation(Location location);
        void DeleteLocation(int Id);

    }
}
