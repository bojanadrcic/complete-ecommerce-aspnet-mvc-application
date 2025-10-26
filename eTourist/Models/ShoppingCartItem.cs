using System.ComponentModel.DataAnnotations;

namespace eTourist.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Arrangement Arrangement { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
