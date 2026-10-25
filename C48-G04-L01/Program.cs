namespace C48_G04_L01
{
    using LINQ.DataSources;
    using LINQ.Models;
    using System.Diagnostics.Metrics;
    using System.Drawing;
    using System.Numerics;
    using System.Xml.Linq;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    internal class Program
    {
        static void Main(string[] args)
        {

            #region Question 01: Get all products from the "Seafood" category. Print each product's name and price.
            Console.WriteLine("--- Question 01 ---");
            var result = Source.ProductList
                        .Where(p => p.Category == "Seafood")
                        .Select(p => new { p.ProductName, p.UnitPrice });

            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.ProductName}, Price: {item.UnitPrice:C2}");
            }

            #endregion



            #region  Question 02:Get a list of only the product names from ProductList. Print each name.

            Console.WriteLine("--- Question 02 ---");

            var ProductNames = Source.ProductList.Select(p => p.ProductName);

            foreach (var name in ProductNames)
            {
                Console.WriteLine(name);
            }

            #endregion


            #region Question 03:Sort all products by UnitPrice (ascending). Print each product's name and price.

            Console.WriteLine("--- Question 03 ---");
            var sortedProductsByPrice = Source.ProductList
                  .OrderBy(p => p.UnitPrice)
                  .Select(p => new { p.ProductName, p.UnitPrice });

            foreach (var item in sortedProductsByPrice)
            {
                Console.WriteLine($"Name: {item.ProductName}, Price: {item.UnitPrice:C2}");
            }

            #endregion

            #region Question 04:Get all products where UnitPrice is between 10 and 30

            Console.WriteLine("--- Question 04 ---");
            var affordableProducts = Source.ProductList
                 .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

            foreach (var product in affordableProducts)
            {
                Console.WriteLine($"Name: {product.ProductName}, Price: {product.UnitPrice:C2}");
            }
            #endregion

            #region Question 05: Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category.
            Console.WriteLine("--- Question 05 ---");
            var inStockCondiments = Source.ProductList
                   .Where(p => p.UnitsInStock > 0 && p.Category.Contains("Condiments"));

            foreach (var product in inStockCondiments)
            {
                Console.WriteLine($"Name: {product.ProductName}, Stock: {product.UnitsInStock}, Category: {product.Category}");
            }
            #endregion


            #region Question 06: Create a new anonymous type with three properties:● Name → the product name ● Price → the unit price● StockStatus → a string: "Available" if UnitsInStock > 0,otherwise "Out of Stock"● Print the result.

            Console.WriteLine("--- Question 06 ---");
            var productStockDetails = Source.ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });

            foreach (var item in productStockDetails)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price:C2}, Status: {item.StockStatus}");
            }

            #endregion

            #region Question 07:Print each product's name along with its position (1-based) in the list. Expected format: 1.Chai, 2.Chang, etc.

            Console.WriteLine("--- Question 07 ---");
            var indexedProducts = Source.ProductList.Select((p, index) => $"{index + 1}. {p.ProductName}");

            foreach (var product in indexedProducts)
            {
                Console.WriteLine(product);
            }

            #endregion

            #region Question 08:Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending.

            Console.WriteLine("--- Question 08 ---");
            var sortedProductsByCategoryAndPrice = Source.ProductList
                   .OrderBy(p => p.Category)
                   .ThenByDescending(p => p.UnitPrice);

            foreach (var product in sortedProductsByCategoryAndPrice)
            {
                Console.WriteLine($"Category: {product.Category}, Price: {product.UnitPrice:C2}, Name: {product.ProductName}");
            }

            #endregion

            #region Question 09:Get all products from the "Beverages" category, sorted by UnitsInStock descending. Print name and stock.

            Console.WriteLine("--- Question 09 ---");
            var sortedBeveragesByStock = Source.ProductList
                            .Where(p => p.Category == "Beverages")
                            .OrderByDescending(p => p.UnitsInStock)
                            .Select(p => new { p.ProductName, p.UnitsInStock });

            foreach (var item in sortedBeveragesByStock)
            {
                Console.WriteLine($"Name: {item.ProductName}, Stock: {item.UnitsInStock}");
            }

            #endregion

            #region Question 10:Using QUERY SYNTAX with a compound from clause, list all orders placed in 1997 or later showing CustomerID and OrderDate.

            Console.WriteLine("--- Question 10 ---");

            var ordersFrom1997OrLater = from c in Source.CustomerList
                                        from o in c.Orders
                                        where o.OrderDate.Year >= 1997
                                        select new { c.CustomerID, o.OrderDate };

                             foreach (var item in ordersFrom1997OrLater)
                             {
                                 Console.WriteLine($"CustomerID: {item.CustomerID}, OrderDate: {item.OrderDate:d}");
                             }
            #endregion

            #region Question 11:Show position number alongside ProductName
           
            Console.WriteLine("--- Question 11 ---");
            var indexedProductNames = Source.ProductList.Select((p, index) => new
            {
                Position = index + 1,
                p.ProductName
            });

            foreach (var item in indexedProductNames)
            {
                Console.WriteLine($"Position: {item.Position}, Product: {item.ProductName}");
            }

            #endregion

            #region Question 12: Sort first by-word length and then by a case -insensitive sort of the words in an array.
            //String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};

            Console.WriteLine("--- Question 12 ---");

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = Arr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var word in sortedWords)
            {
                Console.WriteLine(word);
            }

            #endregion

            #region Question 13:Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            Console.WriteLine("--- Question 13 ---");

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var reversedDigitsWithSecondLetterI = digits
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse();

            foreach (var digit in reversedDigitsWithSecondLetterI)
            {
                Console.WriteLine(digit);
            }
            #endregion


        }
    }
}
