using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Models
{
    public class CartContext: DbContext
    {
        public CartContext(DbContextOptions<CartContext> options): base(options)
        {

        }

        public DbSet<CartItem> Carts { get; set; }
    }
}
