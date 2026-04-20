using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace ApplicationLayer.DTOs
{
    public  class ProductExpensiveandCheapest
    {
                public Product CheapestProduct { get; set; }
                public Product MostExpensiveProduct { get; set; }
    }
}
