using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using ShoppingListDAL;
using ShoppingListDAL.Models;

namespace ShoppingList.Controllers
{
    public class ProductsController : Controller
    {
        private readonly InventoryContext _context;
        private ShoppingCartModel _shoppingCart;

        public ProductsController(InventoryContext context, ShoppingCartModel shoppingCart)
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
            Products newProduct = (Products)_context.Products.First(_ => _.Id == productID);
            _shoppingCart.Cart.Add(newProduct);

            return View("ShoppingCart", _shoppingCart);
        }

    }
}
