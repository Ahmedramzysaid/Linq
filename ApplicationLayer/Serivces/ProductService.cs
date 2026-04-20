using ApplicationLayer.DTOs;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Serivces
{
    public class ProductService
    {
        private readonly List<Product> _products;
        private readonly List<Customer> _customer;
        private readonly List<Order> _order;
        public ProductService(List<Product> products, List<Customer> customer)
        {
            _products = products;
            this._customer = customer;


        }
        public List<ProductDto> GetProductByCategory(string category)
        {
            var result = _products
                                     .Where(p => p.Category == category)
                                     .Select(p => new ProductDto
                                     {
                                         ProductName = p.ProductName,
                                         ProductPrice = p.UnitPrice
                                     }).ToList();
            return result;

        }
        public List<ProductNameDto> GetNamesAllProducts()
        {
            var result = _products
                                  .Select(p => new ProductNameDto { ProductName = p.ProductName })
                                  .ToList();
            return result;
        }

        public List<ProductDto> GetAllProductAscByUnitPrice()
        {

            var result = _products
                                  .Select(p => new ProductDto
                                  {
                                      ProductName = p.ProductName,
                                      ProductPrice = p.UnitPrice
                                  })
                                  .OrderBy(p => p.ProductPrice)
                                  .ToList();
            return result;
        }
        public List<ProductAllDateDto> GetAllDataProductBetweenRange10and30()
        {
            var result = _products
                                    .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30)
                                    .Select(p => new ProductAllDateDto
                                    {
                                        ProductID = p.ProductID,
                                        ProductName = p.ProductName,
                                        Category = p.Category,
                                        UnitPrice = p.UnitPrice,
                                        UnitsInStock = p.UnitsInStock
                                    }).ToList();
            return result;

        }
        public List<ProductAllDateDto> GetProductBelongToCategoryAndUnitOfStock(string category)
        {
            var result = _products
                                     .Where(p => p.Category == category && p.UnitsInStock > 0)
                                     .Select(p => new ProductAllDateDto
                                     {
                                         ProductID = p.ProductID,
                                         ProductName = p.ProductName,
                                         Category = p.Category,
                                         UnitPrice = p.UnitPrice,
                                         UnitsInStock = p.UnitsInStock
                                     }).ToList();
            return result;

        }

        public List<Object> ProductDataanonymous()
        {

            var result = _products
                                    .Where(p => p.UnitPrice > 20)
                                    .Select(p => new
                                    {
                                        Name = p.ProductName,
                                        Price = p.UnitPrice,
                                        StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
                                    }).ToList<Object>();
            return result;
        }
        public List<ProductIndex> GetAllProductNameWithIndex()
        {
            var result = _products
                                   .Select((p, i) => new ProductIndex
                                   {

                                       ProductNameAndIndex = $"{i + 1}.{p.ProductName}"
                                   }).ToList();
            return result;
        }

        public List<ProductAllDateDto> GetProductsOrderbyCategoryandUnitPrice()
        {
            var result = _products
                                     .OrderBy(p => p.Category)
                                     .ThenByDescending(p => p.UnitPrice)
                                     .Select(p => new ProductAllDateDto
                                     {
                                         ProductID = p.ProductID,
                                         ProductName = p.ProductName,
                                         UnitPrice = p.UnitPrice,
                                         UnitsInStock = p.UnitsInStock,
                                         Category = p.Category


                                     }).ToList();
            return result;



        }

        public List<ProductCategoryStockDto> GetProductCategoriesWithStockStatus()
        {
            var result = _products
                                    .Where(p => p.Category == "Beverages")
                                    .OrderByDescending(p => p.UnitsInStock)
                                    .Select(g => new ProductCategoryStockDto
                                    {
                                        ProductName = g.ProductName,
                                        Stock = g.UnitsInStock
                                    }).ToList();
            return result;
        }
        public List<CustomerDto> GetAllCustomer()
        {
            var result = (
                     from c in _customer
                     from o in _customer.SelectMany(c => c.Orders)
                     where o.OrderDate.Year >= 1997
                     select new CustomerDto
                     {
                         CustomerID = c.CustomerID,
                         OrderDate = o.OrderDate
                     }
               ).ToList();
            return result;

        }
        public List<ProductIndex> GetAllProductNameWithPostion()
        {
            var result = _products
                                   .Select((p, i) => new ProductIndex
                                   {

                                       ProductNameAndIndex = $"{i}.{p.ProductName}"
                                   }).ToList();
            return result;
        }
        // this is Tasks Session 2
        // ====================================================================================================
        public List<Product> GetMost3ProductsExpensive()
        {
            var result = _products
                                    .OrderByDescending(p => p.UnitPrice)
                                    .Take(3)
                                    .ToList();
            return result;
        }
        public List<Product> GetPaginations(int NumberPage, int Size)
        {

            var result = _products
                                  .Skip((NumberPage - 1) * Size)
                                  .Take(Size)
                                  .ToList();
            return result;
        }
        public List<Product> GetProductsLessThan25()
        {
            var answer = _products
                                    .OrderBy(p => p.UnitPrice)
                                    .TakeWhile(p => p.UnitPrice < 25)
                                    .ToList();
            return answer;
        }
        public bool CheckAllProductsInstockandcategorySeafood()
        {

            var result = _products
                          .Where(p => p.Category == "Seafood")
                          .All(p => p.UnitsInStock > 0);
            return result;
        }
        public List<ProductsByCategory> GetProductsGroupByCategory()
        {

            var result = _products
                                     .GroupBy(p => p.Category)
                                     .Select(p =>
                                         new ProductsByCategory
                                         {
                                             CategoryName = p.Key,
                                             ProductList = p.ToList(),
                                             CountProduct = p.Count()

                                         }).ToList();



            return result;
        }

        public int GetTotalProductsUnitinStock()
        {
            var result = _products
                                    .Sum(p => p.UnitsInStock);
            return result;


        }
        public List<CategoryName> GetDistinctProductCategories()
        {
            var result = _products
                                   .Select(p => new CategoryName { Name = p.Category })
                                   .Distinct()
                                   .ToList();



            return result;

        }

        public ProductExpensiveandCheapest GetCheapestAndMostExpensiveProduct()
        {
            var result = new ProductExpensiveandCheapest
            {
                CheapestProduct = _products.OrderBy(p => p.UnitPrice).FirstOrDefault(),
                MostExpensiveProduct = _products.OrderByDescending(p => p.UnitPrice).FirstOrDefault()
            };
            return result;
        }


        public Dictionary<int, Product> GetAllProductByID()
        {
            return _products.ToDictionary(p => p.ProductID);

        }

        public Product GetFirstProductgrtherThan50()
        {
            var result = _products
                                 .FirstOrDefault(p => p.UnitPrice > 50);

            return result;


        }
        public Product GetFirstProductgrtherThan500()
        {
            var result = _products
                                 .FirstOrDefault(p => p.UnitPrice > 500);

            if (result is null)
            {
                throw new InvalidOperationException("No product found with a unit price greater than 500.");
            }
            return result;
        }

        public List<string> ConcateCustomerWithProducts()
        {
            var firstThreeProducts = _products
                                      .Take(3)
                                      .Select(p => p.ProductName)
                                      .ToList();
            var firstThreeCustomers = _customer
                                    .Take(3)
                                    .Select(c => c.CustomerID)
                                    .ToList();

            var combinedList = firstThreeProducts.Concat(firstThreeCustomers).ToList();


            return combinedList;

        }

        public List<string> UnionCustomerWithProducts()
        {
            var results = _products
                          .Zip(_customer, (p, c) => $"{p.ProductName} sold to {c.CompanyName}")
                          .ToList();
            return results;

        }
        public List<CustomerDetails> CustomersDetails()
        {
            var result = (from c in _customer
                          group c by c.Country into g
                          select new CustomerDetails
                          (
                              g.Key,                                    
                              g.Count(),                                
                              g.Sum(c => c.Orders.Sum(o => o.Total))   
                          )).ToList();

            return result;
        }
    }



    }
