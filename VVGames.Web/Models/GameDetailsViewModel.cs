using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VVGames.Web.Models
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Name { get; set; }
        public string Genres { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}