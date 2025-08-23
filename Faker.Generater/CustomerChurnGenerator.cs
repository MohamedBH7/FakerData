using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Generater
{
    /// <summary>
    /// Generates synthetic Customer Churn data for ML classification tasks.
    /// </summary>
    public static class CustomerChurnGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly string[] DefaultGenders = { "Male", "Female" };
        private static readonly string[] DefaultCountries = {
            "USA", "UK", "Canada", "Germany", "France", "Bahrain", "UAE", "India", "Australia", "Egypt"
        };
        private static readonly string[] DefaultSubscriptionPlans = { "Basic", "Standard", "Premium" };

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

        public static List<CustomerChurn> GenerateData(
            int count = 100,
            int minAge = 18,
            int maxAge = 70,
            string[] genders = null,
            string[] countries = null,
            string[] subscriptionPlans = null,
            decimal minMonthlySpend = 10m,
            decimal maxMonthlySpend = 110m,
            (DateTime Start, DateTime End) lastLoginRange = default,
            double churnRate = 0.3)
        {
            // Use default values if null
            genders = genders?.Length > 0 ? genders : DefaultGenders;
            countries = countries?.Length > 0 ? countries : DefaultCountries;
            subscriptionPlans = subscriptionPlans?.Length > 0 ? subscriptionPlans : DefaultSubscriptionPlans;

            // Set default login range if not provided
            if (lastLoginRange == default)
            {
                lastLoginRange = (DateTime.Now.AddYears(-1), DateTime.Now);
            }

            // Validate inputs
            if (count < 0) throw new ArgumentException("Count must be non-negative.", nameof(count));
            if (minAge < 0 || maxAge < minAge) throw new ArgumentException("Invalid age range.", nameof(minAge));
            if (minMonthlySpend < 0 || maxMonthlySpend < minMonthlySpend) throw new ArgumentException("Invalid monthly spend range.", nameof(minMonthlySpend));
            if (lastLoginRange.End < lastLoginRange.Start) throw new ArgumentException("Invalid login date range.", nameof(lastLoginRange));
            if (churnRate < 0 || churnRate > 1) throw new ArgumentException("Churn rate must be between 0 and 1.", nameof(churnRate));

            var data = new List<CustomerChurn>();
            for (int i = 0; i < count; i++)
            {
                data.Add(new CustomerChurn
                {
                    CustomerID = Guid.NewGuid(),
                    Age = _random.Next(minAge, maxAge + 1),
                    Gender = genders[_random.Next(genders.Length)],
                    Country = countries[_random.Next(countries.Length)],
                    SubscriptionPlan = subscriptionPlans[_random.Next(subscriptionPlans.Length)],
                    MonthlySpend = Math.Round((decimal)(_random.NextDouble() * (double)(maxMonthlySpend - minMonthlySpend) + (double)minMonthlySpend), 2),
                    LastLoginDate = RandomDate(lastLoginRange.Start, lastLoginRange.End),
                    Churned = _random.NextDouble() < churnRate
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