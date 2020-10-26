using ShoppingListDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class ShoppingCartModel
    {
        public List<Products> Cart { get; set; } = new List<Products>();

        public decimal Total { get; set; }
    }
}
