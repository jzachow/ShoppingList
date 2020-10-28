using ShoppingListDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public interface IShoppingCartModel
    {
        public List<Products> Cart { get; set; }

        public decimal Total { get; set; }
    }
}
