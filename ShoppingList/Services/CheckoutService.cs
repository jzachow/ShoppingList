using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ShoppingList.Services
{
    public class CheckoutService : ICheckoutService
    {
        public CheckoutModel ConvertCartToCheckout(IShoppingCartModel shoppingCart)
        {
            var checkout = new CheckoutModel
            {
                Cart = shoppingCart.Cart,
                Total = shoppingCart.Total
            };

            return checkout;
        }
    }
}
