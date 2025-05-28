using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VVGames.Web.Models
{
    public class AddGameViewModel
    {
        public string Articul { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public List<int> SelectedGenres { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}