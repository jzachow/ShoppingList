using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using ShoppingList.Services;
using ShoppingListDAL;
using ShoppingListDAL.Models;

namespace ShoppingList.Controllers
{
    public class ProductsController : Controller
    {
        private readonly InventoryContext _context;
        private IShoppingCartModel _shoppingCart;

        public ProductsController(InventoryContext context, IShoppingCartModel shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;            
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult AddToCart(int productID)
        {
            Products newProduct = _context.Products.First(_ => _.Id == productID);
            _shoppingCart.Cart.Add(newProduct);
            _shoppingCart.Total += newProduct.Price;

            return View("ShoppingCart", _shoppingCart);
        }

        public IActionResult Checkout(ICheckoutService checkoutService)
        {
            var checkoutModel = checkoutService.ConvertCartToCheckout(_shoppingCart);

            return View(checkoutModel);
        }

    }
}
