using ApplicationLayer.DataSeeder;
using ApplicationLayer.Serivces;
using ApplicationLayer.DTOs;
using System.Collections;
namespace PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var products = Source.ProductList;
            var customers = Source.CustomerList;
           
            var Services = new ProductService(products , customers );
            //=============================================================================
            var productByCategory = Services.GetProductByCategory("Seafood");
            foreach (var item in productByCategory)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.ProductPrice}");
            }
            Console.WriteLine(new string('=', 70));
            //=============================================================================
            var namesAllProducts = Services.GetNamesAllProducts();
            foreach (var item in namesAllProducts)
            {
                Console.WriteLine($"Product Name: {item.ProductName}");
            }
            Console.WriteLine(new string('=', 70));
            //=============================================================================
            var allProductAscByUnitPrice = Services.GetAllProductAscByUnitPrice();
            foreach (var item in allProductAscByUnitPrice)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.ProductPrice}");
            }
            //=============================================================================
            Console.WriteLine(new string('=', 70));
            var allDataProductBetweenRange10and30 = Services.GetAllDataProductBetweenRange10and30();
            foreach (var item in allDataProductBetweenRange10and30)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.ProductID}, Category: {item.Category}, UnitsInStock: {item.UnitsInStock}");
            }
            //=============================================================================
            
            Console.WriteLine(new string('=', 70));
                var productBelongToCategoryAndUnitOfStock = Services.GetProductBelongToCategoryAndUnitOfStock("Condiments");
                foreach (var item in productBelongToCategoryAndUnitOfStock)
                {
                    Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.UnitPrice}, Category: {item.Category}, UnitsInStock: {item.UnitsInStock}");
                }
            //=============================================================================
            Console.WriteLine(new string('=', 70));
            var productDataanonymous = Services.ProductDataanonymous();
            foreach (var item in productDataanonymous)
            {
                Console.WriteLine(item);
            }

            //=============================================================================
            Console.WriteLine(new string('=', 70));
                var allProductNameWithIndex = Services.GetAllProductNameWithIndex();
                foreach (var item in allProductNameWithIndex)
                {
                    Console.WriteLine($"Product With index {item.ProductNameAndIndex}");
            }
            //=============================================================================
            Console.WriteLine(new string('=', 70));
            var allProductNameWithIndexAndCategory = Services.GetProductsOrderbyCategoryandUnitPrice();
            foreach (var item in allProductNameWithIndexAndCategory)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.UnitPrice}, Category: {item.Category}");
            }
            //=============================================================================
            Console.WriteLine(new string('=', 70));
            var productCategoryStockDtos = Services.GetProductCategoriesWithStockStatus();
             foreach (var item in productCategoryStockDtos)
            {
                Console.WriteLine($"Product Category : {item.ProductName} ,Stock{item.Stock}");
            }
            //=============================================================================
            Console.WriteLine(new string('=', 70));
            var AllCustomer = Services.GetAllCustomer(); 
            foreach(var item in AllCustomer)
            {
                Console.WriteLine($"Customer Id : {item.CustomerID} , Date : {item.OrderDate}");
            }
            //=============================================================================
            Console.WriteLine(new string('=', 70));
            //  Sort first by - word length and then by a
            //case -insensitive sort of the words in an array. 

            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var result = Arr.OrderBy(s => s.Length)
                            .ThenBy(s => s, StringComparer.OrdinalIgnoreCase)
                            .ToArray();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            //=============================================================================
            Console.WriteLine(new string('=', 70));
            string[] items = { "aip", "big", "cat", "dip", "fish", "bin" };
            var result2 = (from item in items
                           where item.Length >= 2 && item[1] == 'i'
                           select item).Reverse();


            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
