using System;
using System.Collections.Generic;

namespace Faker.Generater
{
    /// <summary>
    /// Generates synthetic sales data for ML regression tasks.
    /// </summary>
    public static class SalesForecastingGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly string[] DefaultStores = { "StoreA", "StoreB", "StoreC", "StoreD" };
        private static readonly string[] DefaultProducts = { "Product1", "Product2", "Product3", "Product4" };

        public class SalesData
        {
            public DateTime Date { get; set; }
            public string StoreID { get; set; }
            public string ProductID { get; set; }
            public decimal Price { get; set; }
            public int QuantitySold { get; set; }
            public decimal TotalRevenue { get; set; }
        }

        public static List<SalesData> GenerateData(
            int count = 100,
            (DateTime Start, DateTime End) dateRange = default,
            string[] stores = null,
            string[] products = null,
            decimal minPrice = 5m,
            decimal maxPrice = 105m,
            int minQuantity = 1,
            int maxQuantity = 50)
        {
            // Use default values if null
            stores = stores?.Length > 0 ? stores : DefaultStores;
            products = products?.Length > 0 ? products : DefaultProducts;

            // Set default date range if not provided
            if (dateRange == default)
            {
                dateRange = (DateTime.Now.AddYears(-2), DateTime.Now);
            }

            // Validate inputs
            if (count < 0) throw new ArgumentException("Count must be non-negative.", nameof(count));
            if (dateRange.End < dateRange.Start) throw new ArgumentException("Invalid date range.", nameof(dateRange));
            if (stores.Length == 0) throw new ArgumentException("Stores array cannot be empty.", nameof(stores));
            if (products.Length == 0) throw new ArgumentException("Products array cannot be empty.", nameof(products));
            if (minPrice < 0 || maxPrice < minPrice) throw new ArgumentException("Invalid price range.", nameof(minPrice));
            if (minQuantity < 0 || maxQuantity < minQuantity) throw new ArgumentException("Invalid quantity range.", nameof(minQuantity));

            var data = new List<SalesData>();
            for (int i = 0; i < count; i++)
            {
                var quantity = _random.Next(minQuantity, maxQuantity + 1);
                var price = Math.Round((decimal)(_random.NextDouble() * (double)(maxPrice - minPrice) + (double)minPrice), 2);
                data.Add(new SalesData
                {
                    Date = RandomDate(dateRange.Start, dateRange.End),
                    StoreID = stores[_random.Next(stores.Length)],
                    ProductID = products[_random.Next(products.Length)],
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
            return start.AddDays(_random.Next(range)).AddHours(_random.Next(0, 24)).AddMinutes(_random.Next(0, 60));
        }
    }
}