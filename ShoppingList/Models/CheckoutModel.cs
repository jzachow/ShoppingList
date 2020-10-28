using ShoppingListDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ShoppingList.Models
{
    public class CheckoutModel
    {
        public List<Products> Cart { get; set; } = new List<Products>();

        public decimal Total { get; set; }

        public const decimal MichiganTaxRate = 1.06m;

        public decimal GrandTotal { get; set; }

        public CheckoutModel()
        {
            GrandTotal = Total * MichiganTaxRate;
        }

    }
}
