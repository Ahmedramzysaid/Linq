using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public record CustomerDetails(string Country, int Count, decimal TotalOrderValue) { }
   
}
