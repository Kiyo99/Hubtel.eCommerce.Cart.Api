using Hubtel.eCommerce.Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.CartData
{
    public class SqlCartData : ICart
    {

        private CartContext _cartContext;
        public SqlCartData(CartContext cartContext)
        {
            _cartContext = cartContext;
        }

        public CartItem AddItem(CartItem cartItem)
        { 
            //Creating a new ID for the cart Item

            cartItem.Id = Guid.NewGuid();
            _cartContext.Carts.Add(cartItem);
            _cartContext.SaveChanges();
            
            return cartItem;
        }

        public void DeleteItem(CartItem cartItem)
        {
            _cartContext.Carts.Remove(cartItem);
            _cartContext.SaveChanges();
        }

        public CartItem GetItem(Guid id)
        {
            var singleItem = _cartContext.Carts.Find(id);
            return singleItem;
        }

        public List<CartItem> GetItems()
        {
            //figure out how to filter or sort and add it in part of the queries

            return _cartContext.Carts.OrderBy(x => x.itemName).ToList();

        }

        public CartItem UpdateItem(int newQuantity, CartItem cartItem)
        {
            //Updating the quantity
            int oldQuantity = cartItem.quantity;

            int updatedQuantity = oldQuantity + newQuantity;
            cartItem.quantity = updatedQuantity;
            _cartContext.Carts.Update(cartItem);
            _cartContext.SaveChanges();

            return cartItem;
            
        }
    }
}
