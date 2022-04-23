using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IColourService
    {
        void UpdateColour(Colour colour, int Id);
        Colour AddColour(Colour colour);
        void DeleteColour(int Id);

    }
}
