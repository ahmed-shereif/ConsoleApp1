using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var products = ListGenerator.ProductList;
            var customers = ListGenerator.CustomerList;

            //1 - LINQ - Restriction Operators
            //var outOfStockProducts = products.Where(product => product.UnitsInStock == 0);
            //foreach (var product in outOfStockProducts)
            //    Console.WriteLine(product);
            //var prodcustCostMoreThanThree = products.Where(product => product.UnitPrice > 3.00);
            //foreach ( var product in prodcustCostMoreThanThree) 
            //    Console.WriteLine(product);\

            //3.Returns digits whose name is shorter than their value.
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var x = Arr.Where((n, i) => n.Length > i);

            ////  2 - LINQ - Ordering Operators
            ////1.Sort a list of products by name
            //var x2 = products.OrderBy(x => x.ProductName);

            ////2.Uses a custom comparer to do a case -insensitive sort of the words in an array.
            //string[] Arr2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var x3 = Arr2.OrderBy(x => x.ToLower());
            ////  3.Sort a list of products by units in stock from highest to lowest.


            //var x4 = products.OrderByDescending(x => x.UnitsInStock);


            ////4.Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            //string[] Arr4 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var x5 = Arr4.OrderBy(x => x.Length).ThenBy(x => x);







            ////3 - LINQ – Transformation Operators
            //1.Return a sequence of just the names of a list of products.
            //var x6 = products.Select(x => x.ProductName);

            //2.Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).
            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            //var x7 = words.Select(x => new { lower = x.ToLower(), uppder = x.ToUpper() });


            //3.Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            //var x8 = products.Select(x => new { price = x.UnitPrice, x });



            //LINQ - Element Operators
            //1.Get first Product out of Stock
            //var first = products.First();

            //2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            //var first1 = products.Where(x => x.UnitPrice > 1000).First();
            //3.Retrieve the second number greater than 5
            //int[] Arr7 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var second = Arr7.OrderBy(x => x).Where(x => x > 5).ElementAt(1);


            //LINQ - Aggregate Operators
            //1.Uses Count to get the number of odd numbers in the array
            //int[] Arr9 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var c1 = Arr9.Count(x => x % 2 != 0);

            //2.Return a list of customers and how many orders each has.
            //var customers = ListGenerator.CustomerList;

            //var howmanyOrder = customers.Select(x => new { x, count = x.Orders.Count() });
            //foreach (var item in howmanyOrder)
            //{
            //    Console.WriteLine(item);
            //}
            //3.Return a list of categories and how many products each has
            //var p = products.GroupBy(x => x.Category).Select(x => new { cat = x.Key, count = x.Count() });



            //4.Get the total of the numbers in an array.
            //int[] Arr11 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var sum = Arr11.Sum();
            //5.Get the total number of characters of all words in
            //  dictionary_english.txt(Read dictionary_english.txt into Array of String First).

            string[] words = File.ReadAllLines("dictionary_english.txt");

            //int totalCharacters = words.Sum(word => word.Length);
            //Console.WriteLine(totalCharacters);
            ////6.Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //int shortesWork = words.Min(x => x.Length);
            //Console.WriteLine($"shortesWork: {shortesWork}");
            ////7.Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //int LongestWork = words.Max(x => x.Length);
            //Console.WriteLine($"LongestWork: {LongestWork}");
            ////8.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //double AverageWork = words.Average(x => x.Length);
            //Console.WriteLine($"AverageWork: {AverageWork}")
            //9.Get the total units in stock for each product category.
            var g = products.GroupBy(x => x.Category).Select(x => new { total = x.Sum(x => x.UnitsInStock) }).ToArray();

            //            LINQ - Set Operators
            //Find the unique Category names from Product List
            var c = products.Select(x => x.Category).Distinct();
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }
            //2.Produce a Sequence containing the unique first letter from both product and customer names.
            var f1 = products.Select(x => x.ProductName.ElementAt(0));
            var f2 = customers.Select(x => x.CustomerName.ElementAt(0));
            var u = f1.Union(f2);

            //3.Create one sequence that contains the common first letter from both product and customer names.
            var i = f1.Intersect(f2);
            foreach (var item in i)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("+++++++++++++");
            //4.Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var e = f1.Except(f2);

            //5.Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates

            //.Select(c => c.Name.Length >= 3 ? c.Name.Substring(c.Name.Length - 3) : c.Name)
            //.Concat(products.Select(p => p.Name.Length >= 3 ? p.Name.Substring(p.Name.Length - 3) : p.Name))
            //.ToList();


            //LINQ - Quantifiers
            //Determine if any of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            var bo = words.Any(x => x.Contains("ei"));
            //Console.WriteLine(bo);
            //Return a grouped list of products only for categories that have at least one product that is out of stock.
            var o = products.GroupBy(x => x.Category).Where(x => x.Any(g => g.UnitsInStock == 0));

            //3.Return a grouped a list of products only for categories that have all of their products in stock.
            var a = products.GroupBy(x => x.Category).Where(x => x.All(g => g.UnitsInStock == 0));
            //foreach (var item in a)
            //{
            //    foreach (var d in item)
            //    {
            //        Console.WriteLine(d);

            //    }
            //}
            //            Use group by to partition a list of numbers by their remainder when divided by 5
            List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var v = numbers.GroupBy(x => x % 5);
            foreach (var item in v)
            {
                foreach (var jj in item)
                {

                    Console.WriteLine(jj);
                }
            }


        }
    }
}