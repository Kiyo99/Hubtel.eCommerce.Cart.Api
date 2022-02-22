using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Hubtel.eCommerce.Cart.CartData;
using Hubtel.eCommerce.Cart.Models;

namespace Hubtel.eCommerce.Cart.Controllers
{
   
    [ApiController]
    public class CartsController : ControllerBase
    {

        private ICart _iCart;

        public CartsController(ICart iCart)
        {
            _iCart = iCart;
        }

        [HttpGet("")]
        [Route("api/[controller]")]

        public IActionResult GetItems()
        {
            return Ok(_iCart.GetItems());
        }

       [HttpGet("")]
       [Route("api/[controller]/{id}")]

        public IActionResult GetItem(Guid id)
        {

            var item = _iCart.GetItem(id);

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound($"The Cart Item with id: {id} was not found"); 
        }

        [HttpDelete("")]
        [Route("api/[controller]/delete/{id}")]
        public IActionResult DeleteItem(Guid id)
        {

            var item = _iCart.GetItem(id);

            if (item != null)
            {
                _iCart.DeleteItem(item);
                return Ok($"Employee with ID: {id} was deleted");
            }

            return NotFound($"The Cart Item with id: {id} was not found");
        }

        [HttpPost("")]
        [Route("api/[controller]/add/{id?}")]

        public IActionResult AddItem(CartItem cartItem, Guid? id = null)
        {
            //Checking to see if a similar item with the same ID has been added already

            if (id.HasValue)
            {
                var item = _iCart.GetItem((Guid)id);

                if (item != null)
                {
                    //Means a similar ID was found, hence all that needs to be done is to update the quantity
                    //Updating the quantity

                    _iCart.UpdateItem(cartItem);
                    return Ok($"The item with ID: {id} was updated");
                }
               else
                {
                    return NotFound($"The item with ID: {id} was not found");
                }
            }
         
            else
            {
                //Means no ID has been entered, hence what needs to be done is to create a new Id and save everything
                //Creating a new ID for the cart Item
                _iCart.AddItem(cartItem);
                return Ok($"The item with ID: {id} was created");
            }
            
        }

    }
}
