using ApplicationLayer.DataSeeder;
using ApplicationLayer.DTOs;
using ApplicationLayer.Serivces;
using DomainLayer.Models;
using System.Collections;
namespace PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var products = Source.ProductList;
            var customers = Source.CustomerList;

            var Services = new ProductService(products, customers);
            ////=============================================================================
            //var productByCategory = Services.GetProductByCategory("Seafood");
            //foreach (var item in productByCategory)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.ProductPrice}");
            //}
            //Console.WriteLine(new string('=', 70));
            ////=============================================================================
            //var namesAllProducts = Services.GetNamesAllProducts();
            //foreach (var item in namesAllProducts)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}");
            //}
            //Console.WriteLine(new string('=', 70));
            ////=============================================================================
            //var allProductAscByUnitPrice = Services.GetAllProductAscByUnitPrice();
            //foreach (var item in allProductAscByUnitPrice)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.ProductPrice}");
            //}
            ////=============================================================================
            //Console.WriteLine(new string('=', 70));
            //var allDataProductBetweenRange10and30 = Services.GetAllDataProductBetweenRange10and30();
            //foreach (var item in allDataProductBetweenRange10and30)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.ProductID}, Category: {item.Category}, UnitsInStock: {item.UnitsInStock}");
            //}
            ////=============================================================================

            //Console.WriteLine(new string('=', 70));
            //var productBelongToCategoryAndUnitOfStock = Services.GetProductBelongToCategoryAndUnitOfStock("Condiments");
            //foreach (var item in productBelongToCategoryAndUnitOfStock)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.UnitPrice}, Category: {item.Category}, UnitsInStock: {item.UnitsInStock}");
            //}
            ////=============================================================================
            //Console.WriteLine(new string('=', 70));
            //var productDataanonymous = Services.ProductDataanonymous();
            //foreach (var item in productDataanonymous)
            //{
            //    Console.WriteLine(item);
            //}

            ////=============================================================================
            //Console.WriteLine(new string('=', 70));
            //var allProductNameWithIndex = Services.GetAllProductNameWithIndex();
            //foreach (var item in allProductNameWithIndex)
            //{
            //    Console.WriteLine($"Product With index {item.ProductNameAndIndex}");
            //}
            ////=============================================================================
            //Console.WriteLine(new string('=', 70));
            //var allProductNameWithIndexAndCategory = Services.GetProductsOrderbyCategoryandUnitPrice();
            //foreach (var item in allProductNameWithIndexAndCategory)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.UnitPrice}, Category: {item.Category}");
            //}
            ////=============================================================================
            //Console.WriteLine(new string('=', 70));
            //var productCategoryStockDtos = Services.GetProductCategoriesWithStockStatus();
            //foreach (var item in productCategoryStockDtos)
            //{
            //    Console.WriteLine($"Product Category : {item.ProductName} ,Stock{item.Stock}");
            //}
            ////=============================================================================
            //Console.WriteLine(new string('=', 70));
            //var AllCustomer = Services.GetAllCustomer();
            //foreach (var item in AllCustomer)
            //{
            //    Console.WriteLine($"Customer Id : {item.CustomerID} , Date : {item.OrderDate}");
            //}
            ////=============================================================================
            //Console.WriteLine(new string('=', 70));
            ////  Sort first by - word length and then by a
            ////case -insensitive sort of the words in an array. 

            //String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var result = Arr.OrderBy(s => s.Length)
            //                .ThenBy(s => s, StringComparer.OrdinalIgnoreCase)
            //                .ToArray();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            ////=============================================================================
            //Console.WriteLine(new string('=', 70));
            //string[] items = { "aip", "big", "cat", "dip", "fish", "bin" };
            //var result2 = (from item in items
            //               where item.Length >= 2 && item[1] == 'i'
            //               select item).Reverse();


            //foreach (var item in result2)
            //{
            //    Console.WriteLine(item);
            //}

            //  Solution  Task 2 

            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var top3ExpensiveProducts = Services.GetMost3ProductsExpensive();
            foreach (var item in top3ExpensiveProducts)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.UnitPrice}");
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var page2Products = Services.GetPaginations(2, 5);
            foreach (var item in page2Products)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.UnitPrice}, Category: {item.Category}, UnitsInStock: {item.UnitsInStock}");
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var Prodcutlessthen25 = Services.GetProductsLessThan25();
            foreach (var item in Prodcutlessthen25)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.UnitPrice}, Category: {item.Category}, UnitsInStock: {item.UnitsInStock}");
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
           var CheckAllProductsInstockandcategorySeafood = Services.CheckAllProductsInstockandcategorySeafood();
            Console.WriteLine($"Check if all products in category 'Seafood' are in stock: {CheckAllProductsInstockandcategorySeafood}");
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var ProductsGroupByCategory = Services.GetProductsGroupByCategory();
            foreach (var item in ProductsGroupByCategory)
            {
                Console.WriteLine($"Category: {item.CategoryName}");
                foreach (var product in item.ProductList)
                {
                    Console.WriteLine($"  Product Name: {product.ProductName}, Price: {product.UnitPrice}, UnitsInStock: {product.UnitsInStock}");
                }
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var TotalProductsUnitinStock = Services.GetTotalProductsUnitinStock();
            Console.WriteLine($"Total Units in Stock for all products: {TotalProductsUnitinStock}");
            
            // =============================================================================
            Console.WriteLine(new string('=', 70));

            var CheckNumber9inlist  =  NumberService.CheckNumber9inList();
            Console.WriteLine($"Check if number 9 is in the list: {CheckNumber9inlist}");
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var GroupProductsByCategory = Services.GetProductsGroupByCategory();
            foreach (var group in GroupProductsByCategory)
            {
                Console.WriteLine($"Category: {group.CategoryName} , Total: {group.CountProduct}");
                foreach (var product in group.ProductList)
                {
                    Console.WriteLine($"  Product Name: {product.ProductName}, Price: {product.UnitPrice}, UnitsInStock: {product.UnitsInStock}");
                }
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
          
            foreach (var group in GroupProductsByCategory)
            {
                Console.WriteLine($"Category: {group.CategoryName}");
                foreach (var product in group.ProductList)
                {
                    Console.WriteLine($"  Product Name: {product.ProductName}");
                }
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            foreach (var group in GroupProductsByCategory)
            {
                if(group.CountProduct > 3)
                    Console.WriteLine($"Category: {group.CategoryName} , Total: {group.CountProduct}");
                foreach (var product in group.ProductList)
                {
                    Console.WriteLine($"  Product Name: {product.ProductName}, Price: {product.UnitPrice}, UnitsInStock: {product.UnitsInStock}");
                }
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var CustomersDetails = Services.CustomersDetails();
            foreach (var customer in CustomersDetails)
            {
               Console.WriteLine($"Country : {customer.Country}, Count {customer.Count} , TotalOrderValue {customer.TotalOrderValue}");
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var  TotalNumberUnitsInStock = Services.GetTotalProductsUnitinStock();
            Console.WriteLine($"Total Units in Stock for all products: {TotalNumberUnitsInStock}");
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var CheapestAndMostExpensiveProduct = Services.GetCheapestAndMostExpensiveProduct();
            Console.WriteLine($"Cheapest Product: {CheapestAndMostExpensiveProduct.CheapestProduct.ProductName}, Price: {CheapestAndMostExpensiveProduct.CheapestProduct.UnitPrice}");
            Console.WriteLine($"Most Expensive Product: {CheapestAndMostExpensiveProduct.MostExpensiveProduct.ProductName}, Price: {CheapestAndMostExpensiveProduct.MostExpensiveProduct.UnitPrice}");
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var DistinctProductCategories = Services.GetDistinctProductCategories();
            Console.WriteLine("Distinct Product Categories:");
            foreach (var category in DistinctProductCategories)
            {
                Console.WriteLine(category.Name);
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var  ExceptLists = NumberService.ExpcetLists();
            Console.WriteLine("Numbers in the first list but not in the second:");
            foreach (var number in ExceptLists)
            {
                Console.WriteLine(number);
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var ExceptListsContries = NumberService.ExceptContries();
            Console.WriteLine("Numbers in the first list but not in the second:");
            foreach (var number in ExceptListsContries)
            {
                Console.WriteLine(number);
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));

            var ProductID18 = Services.GetAllProductByID();
            foreach (var dic in ProductID18)
            {
                  if(dic.Key == 18)
                    Console.WriteLine($"Product ID: {dic.Key}, Product Name: {dic.Value.ProductName}, Price: {dic.Value.UnitPrice}, Category: {dic.Value.Category}, UnitsInStock: {dic.Value.UnitsInStock}");

                
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var  ProductFirstgrtherThan50 = Services.GetFirstProductgrtherThan50();
            Console.WriteLine($"  Product Name: {ProductFirstgrtherThan50.ProductName}, Price: {ProductFirstgrtherThan50.UnitPrice}, UnitsInStock: {ProductFirstgrtherThan50.UnitsInStock}");
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            try
            {
                var productsWithUnitPriceGreaterThan500 = Services.GetFirstProductgrtherThan500();
                Console.WriteLine("Products with Unit Price Greater Than 500:");
                Console.WriteLine($"  Product Name: {productsWithUnitPriceGreaterThan500.ProductName}, Price: {productsWithUnitPriceGreaterThan500.UnitPrice}, UnitsInStock: {productsWithUnitPriceGreaterThan500.UnitsInStock}");

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var  MultiplicationTableRowFor7 = NumberService.MultiplicationTableRowFor7();
            Console.WriteLine("Multiplication Table Row for 7:");
            foreach (var item in MultiplicationTableRowFor7)
            {
                Console.WriteLine(item);
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var EvenNumbers = NumberService.GenerateEvenNumbers();
            foreach (var number in EvenNumbers)
            {
                Console.WriteLine(number);
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var  ConcateCustomerWithProducts = Services.ConcateCustomerWithProducts();
            foreach (var item in ConcateCustomerWithProducts)
            {
                Console.WriteLine(item);
            }
            // =============================================================================
            Console.WriteLine(new string('=', 70));
            var ProductUnionCustomerWithProducts = Services.UnionCustomerWithProducts();
            foreach (var item in ProductUnionCustomerWithProducts)
            {
                Console.WriteLine(item);
            }









            }
    }
}
