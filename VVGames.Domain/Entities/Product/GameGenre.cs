using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVGames.Domain.Entities.Product
{
    [Flags]
    public enum GameGenre
    {
        None = 0,
        Strategii = 1,
        Shooter = 2,
        RPG = 4,
        Simulator = 8
    }
}
