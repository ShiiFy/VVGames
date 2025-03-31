using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Entities.Product;

namespace VVGames.Domain.Entities.Basket
{
    public class Basket
    {
        public List<Games> BasketProduct { get; set; }
        public uint ProductCount { get; set; }
        public int UserID { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
