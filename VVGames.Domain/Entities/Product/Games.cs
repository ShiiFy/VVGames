using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVGames.Domain.Entities.Product
{
    public class Games
    {
        public List<GameGenre> GameGenres { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
