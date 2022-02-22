using Hubtel.eCommerce.Cart.Models;
using System;
using System.Collections.Generic;

namespace Hubtel.eCommerce.Cart.CartData
{
    public interface ICart
    {

        List<CartItem> GetItems();

        CartItem GetItem(Guid id);

        void DeleteItem(CartItem cartItem);

        CartItem AddItem(CartItem cartItem);

        CartItem UpdateItem(int newQuantity, CartItem cartItem); 

    }
}
