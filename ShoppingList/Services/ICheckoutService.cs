using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services
{
    public interface ICheckoutService
    {
        public CheckoutModel ConvertCartToCheckout(IShoppingCartModel cart);        
    }
}
