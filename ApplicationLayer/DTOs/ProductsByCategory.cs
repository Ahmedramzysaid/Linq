using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public class ProductsByCategory
    {
       public  string CategoryName { get; set; }
        public List<Product> ProductList { get; set; }

        public int CountProduct { get; set; }

    }
}
