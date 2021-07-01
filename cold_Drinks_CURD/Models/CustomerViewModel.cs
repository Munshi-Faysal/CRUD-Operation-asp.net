using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cold_Drinks_CURD.Models
{
    public class CustomerViewModel
    {
        public int intColdDrinksId { get; set; }
        public string strColdDrinksName { get; set; }
        public decimal numQuantity { get; set; }
        public decimal numUnitPrice { get; set; }
    }
}