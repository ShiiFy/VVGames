using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Entities.Product;
using VVGames.Domain.Entities.User;

namespace VVGames.Domain.Entities.Basket
{
    public class DBBasket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; } = 1;

        [ForeignKey("UserId")]
        public virtual DBUser User { get; set; }

        [ForeignKey("ProductId")]
        public virtual DBGames Product { get; set; }
    }
}
