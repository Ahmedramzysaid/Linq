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
        public ProductService(List<Product> products , List<Customer> customer )
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

                                       ProductNameAndIndex = $"{i+1}.{p.ProductName}"
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


    }
        
            


        
}
