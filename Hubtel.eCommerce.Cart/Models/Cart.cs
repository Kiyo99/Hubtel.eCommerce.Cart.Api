using System;
using System.ComponentModel.DataAnnotations;

namespace Hubtel.eCommerce.Cart.Models
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long")]
        public string itemName { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public double unitPrice { get; set; }
    }
}
