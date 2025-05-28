using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VVGames.Web.Models
{
    [Flags]
    public enum GameGenreViewModel
    {
        None = 0,
        Strategii = 1,
        Shooter = 2,
        RPG = 4,
        Simulator = 8
    }
}