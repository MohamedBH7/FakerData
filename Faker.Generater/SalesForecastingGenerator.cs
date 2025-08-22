
using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

namespace Faker.Generater
{
    /// <summary>
    /// Generates synthetic sales data for ML regression tasks.
    /// </summary>
    /// SalesForecastingGenerator_Documentation.markdown
    public static class SalesForecastingGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly string[] Stores = { "StoreA", "StoreB", "StoreC", "StoreD" };
        private static readonly string[] Products = { "Product1", "Product2", "Product3", "Product4" };

        public class SalesData
        {
            public DateTime Date { get; set; }
            public string StoreID { get; set; }
            public string ProductID { get; set; }
            public decimal Price { get; set; }
            public int QuantitySold { get; set; }
            public decimal TotalRevenue { get; set; }
        }

        public static List<SalesData> GenerateData(int count = 100)
        {
            var data = new List<SalesData>();
            for (int i = 0; i < count; i++)
            {
                var quantity = _random.Next(1, 50);
                var price = Math.Round((decimal)(_random.NextDouble() * 100 + 5), 2);
                data.Add(new SalesData
                {
                    Date = RandomDate(DateTime.Now.AddYears(-2), DateTime.Now),
                    StoreID = Stores[_random.Next(Stores.Length)],
                    ProductID = Products[_random.Next(Products.Length)],
                    Price = price,
                    QuantitySold = quantity,
                    TotalRevenue = Math.Round(price * quantity, 2)
                });
            }
            return data;
        }

        private static DateTime RandomDate(DateTime start, DateTime end)
        {
            int range = (end - start).Days;
            return start.AddDays(_random.Next(range));
        }
    }
}
