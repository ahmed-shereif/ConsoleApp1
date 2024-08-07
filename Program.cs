using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Threading;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var customers = ListGenerator.CustomerList;
            var products = ListGenerator.ProductList;
            #region task
            // -Write a LINQ query to select only the ProductName and UnitPrice of products from ProductList.
            var p1 = products.Select(x => new { pName = x.ProductName, unitPrice = x.UnitPrice });

            //-Write a LINQ query to order the products in ProductList by UnitPrice in descending order.
            var porder = products.OrderByDescending(x => x.UnitPrice);
            //-Write a LINQ query to group products from ProductList by Category and count the number of products in each category.

            var p2 = products.GroupBy(x => x.Category).Select(x => new { cat = x.Key, count = x.Count() });


            //-Write a LINQ query to find all products in ProductList that have more than 10 units in stock.
            var p3 = products.Where(x => x.UnitsInStock > 10);
            //- Write a LINQ query to find all customers from CustomerList who are from the country "Germany".
            var c2 = customers.Where(x => x.Country == "German");
            //- Write a LINQ query to select the CustomerName and City of all customers from CustomerList.
            var c3 = customers.Select(x => new { cName = x.CustomerName, city = x.City });
            //-Write a LINQ query to order the customers in CustomerList by City in ascending order.
            var c4 = customers.OrderBy(x => x.City);
            //-Write a LINQ query to find all customers from CustomerList who have at least one order in their Orders array.
            var c5 = customers.Where(x => x.Orders.Count() > 1);
            //- Write a LINQ query to count the number of orders for each customer and return the CustomerName along with the order count.
            var c6 = customers.Select(x => new { numberOfOrder = x.Orders.Count(), cName = x.CustomerName });
            //-Write a LINQ query to find all orders in the Orders array where the Total is greater than $500.
            var highValueOrders = customers
                .SelectMany(customer => customer.Orders)
                .Where(order => order.Total > 5000)
                .ToList();
            //foreach (var order in highValueOrders) { Console.WriteLine(order); }
            //- Write a LINQ query to find the most expensive product in ProductList.
            var exp = products.Where(x => x.UnitPrice == products.Max(x => x.UnitPrice));
            //foreach
            //    (var i in exp)
            //{

            //Console.WriteLine(i);
            //}
            //- Write a LINQ query to find all customers who have at least one order with a Total amount greater than $300.
            var c7 = customers.Where(x => x.Orders.Where(y => y.Total > 300).ToList().Count > 0);
            var c8 = customers.Where(x => x.Orders.Any(y => y.Total > 300)).ToList();
            //- Write a LINQ query to find all products in ProductList that have 5 or fewer units in stock.
            var p9 = products.Where(x => x.UnitsInStock > 5);
            #endregion
        }
    }
}