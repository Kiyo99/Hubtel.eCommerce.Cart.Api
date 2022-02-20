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
            //figure out how ot filter or sort and add it in part of the queries
            return _cartContext.Carts.ToList();

        }

        public CartItem UpdateItem(CartItem cartItem)
        {
           
            //Updating the quantity
            var item = _cartContext.Carts.Find(cartItem.Id);

            var oldQuantity = item.quantity;
            var newQuantity = cartItem.quantity;
            var updatedQuantity = oldQuantity + newQuantity;
            cartItem.quantity = updatedQuantity;
            _cartContext.Carts.Update(cartItem);
            _cartContext.SaveChanges();

            return cartItem;
        }
    }
}
