using System;

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
