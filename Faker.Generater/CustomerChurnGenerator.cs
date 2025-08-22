using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Generater
{
    /// <summary>
    /// Generates synthetic Customer Churn data for ML classification tasks.
    /// </summary>
    /// CustomerChurnGenerator_Documentation.markdown
    public static class CustomerChurnGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly string[] Genders = { "Male", "Female" };
        private static readonly string[] Countries = {
            "USA", "UK", "Canada", "Germany", "France", "Bahrain", "UAE", "India", "Australia", "Egypt"
        };
        private static readonly string[] SubscriptionPlans = { "Basic", "Standard", "Premium" };

        public class CustomerChurn
        {
            public Guid CustomerID { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string Country { get; set; }
            public string SubscriptionPlan { get; set; }
            public decimal MonthlySpend { get; set; }
            public DateTime LastLoginDate { get; set; }
            public bool Churned { get; set; }
        }

        public static List<CustomerChurn> GenerateData(int count = 100)
        {
            var data = new List<CustomerChurn>();
            for (int i = 0; i < count; i++)
            {
                data.Add(new CustomerChurn
                {
                    CustomerID = Guid.NewGuid(),
                    Age = _random.Next(18, 70),
                    Gender = Genders[_random.Next(Genders.Length)],
                    Country = Countries[_random.Next(Countries.Length)],
                    SubscriptionPlan = SubscriptionPlans[_random.Next(SubscriptionPlans.Length)],
                    MonthlySpend = Math.Round((decimal)(_random.NextDouble() * 100 + 10), 2),
                    LastLoginDate = RandomDate(DateTime.Now.AddYears(-1), DateTime.Now),
                    Churned = _random.NextDouble() > 0.7 // ~30% churn rate
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
