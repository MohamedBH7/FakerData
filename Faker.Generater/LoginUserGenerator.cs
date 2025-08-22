using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generater
{
    public static class LoginUserGenerator
    {
        /// <summary>
        /// A utility class for generating mock LoginUser objects with customizable attributes.
        /// </summary>
        /// LoginUserGenerator_Documentation.markdown
        private static readonly Random _random = new Random();

        private static readonly string[] FirstNames = {
            "Ali", "Ahmed", "Mohamed", "Laila", "John", "Emma", "Fatima", "Omar", "Noor", "David",
            "Sophia", "Zain", "Hassan", "Emily", "Yousef", "Layla", "Aisha", "Adam", "Mia", "Tariq",
            "Isla", "Khalid", "Nora", "Samir", "Olivia", "Amir", "Huda", "Ryan", "Zara", "Bilal",
            "Hana", "Jamal", "Leila", "Ethan", "Salma", "Nabil", "Farah", "Zayd", "Reem", "Malik",
            "Dana", "Karim", "Lina", "Rami", "Yara"
        };

        private static readonly string[] LastNames = {
            "Rabia", "Smith", "Khan", "Lee", "Brown", "Garcia", "Johnson", "Al-Farsi", "Taylor", "Nguyen",
            "Hussein", "Martinez", "Ali", "Walker", "Chowdhury", "Patel", "Anderson", "Rahman", "Clark", "Mohammed",
            "Turner", "Abdullah", "Lewis", "Baker", "Saeed", "Campbell", "Hadi", "Murphy", "Jackson", "Yousef",
            "White", "Ahmed", "Scott", "Hassan", "Ward", "Zaman", "Hill", "Salem", "Green", "Tariq",
            "Adams", "Farooq", "Nelson", "Malik", "Reed"
        };

        private static readonly string[] Cities = {
            "Manama", "Dubai", "Cairo", "London", "New York", "Riyadh", "Doha", "Toronto", "Paris", "Berlin",
            "Jeddah", "Abu Dhabi", "Kuwait City", "Muscat", "Istanbul", "Amman", "Beirut", "Los Angeles", "Chicago", "Madrid",
            "Rome", "Stockholm", "Vienna", "Jakarta", "Bangkok", "Delhi", "Mumbai", "Lagos", "Cape Town", "Sydney",
            "Melbourne", "Brisbane", "Auckland", "Oslo", "Helsinki", "Copenhagen", "Zurich", "Geneva", "Lisbon", "Warsaw",
            "Budapest", "Prague", "Brussels", "Athens", "Dublin"
        };

        private static readonly string[] Countries = {
            "Bahrain", "UAE", "Egypt", "UK", "USA", "Saudi Arabia", "Qatar", "Canada", "France", "Germany",
            "Jordan", "Lebanon", "Kuwait", "Oman", "Turkey", "Spain", "Italy", "Sweden", "Norway", "Finland",
            "Denmark", "Switzerland", "Portugal", "Poland", "Hungary", "Czech Republic", "Greece", "Ireland", "Australia", "New Zealand",
            "India", "Pakistan", "Bangladesh", "South Africa", "Nigeria", "Kenya", "Indonesia", "Thailand", "Malaysia", "Singapore",
            "China", "Japan", "South Korea", "Brazil", "Mexico"
        };

        private static readonly string[] Companies = {
            "TechCorp", "SoftSolutions", "GlobalNet", "DataWorks", "NextGen Systems", "CloudBridge", "InnoTech", "CyberNova", "BrightApps", "CodeFusion",
            "SmartEdge", "QuantumSoft", "SkyLogic", "PixelWave", "CoreMatrix", "NetSphere", "AlphaWare", "BlueOrbit", "SecureLink", "DevStream",
            "LogicGate", "AppVision", "NeoTech", "FusionGrid", "BrightMind", "CodeNest", "CloudNova", "DataNest", "TechHive", "InfoPulse",
            "WebWorks", "SoftBridge", "CodeCraft", "NextLogic", "AppCore", "SkyNetics", "ByteLabs", "NovaApps", "CyberEdge", "SmartLogic",
            "BrightSoft", "CoreTech", "NetFusion", "AlphaApps", "CloudMatrix"
        };

        private static readonly string[] EmailDomains = {
            "example.com", "mail.com", "inbox.com", "company.org", "tech.net", "global.io", "cloud.co", "webmail.com"
        };

        private static readonly Dictionary<string, string> CountryPhoneCodes = new Dictionary<string, string>
        {
            {"Bahrain", "+973"}, {"UAE", "+971"}, {"Egypt", "+20"}, {"UK", "+44"}, {"USA", "+1"},
            {"Saudi Arabia", "+966"}, {"Qatar", "+974"}, {"Canada", "+1"}, {"France", "+33"}, {"Germany", "+49"},
            {"Jordan", "+962"}, {"Lebanon", "+961"}, {"Kuwait", "+965"}, {"Oman", "+968"}, {"Turkey", "+90"},
            {"Spain", "+34"}, {"Italy", "+39"}, {"Sweden", "+46"}, {"Norway", "+47"}, {"Finland", "+358"},
            {"Denmark", "+45"}, {"Switzerland", "+41"}, {"Portugal", "+351"}, {"Poland", "+48"}, {"Hungary", "+36"},
            {"Czech Republic", "+420"}, {"Greece", "+30"}, {"Ireland", "+353"}, {"Australia", "+61"}, {"New Zealand", "+64"},
            {"India", "+91"}, {"Pakistan", "+92"}, {"Bangladesh", "+880"}, {"South Africa", "+27"}, {"Nigeria", "+234"},
            {"Kenya", "+254"}, {"Indonesia", "+62"}, {"Thailand", "+66"}, {"Malaysia", "+60"}, {"Singapore", "+65"},
            {"China", "+86"}, {"Japan", "+81"}, {"South Korea", "+82"}, {"Brazil", "+55"}, {"Mexico", "+52"}
        };

        public enum PasswordComplexity
        {
            Simple,
            Medium,
            Complex
        }

        public static List<LoginUser> GenerateUsers(
            long count = 100,
            int minAge = 18,
            int maxAge = 60,
            PasswordComplexity passwordComplexity = PasswordComplexity.Medium,
            string specificCountry = null,
            bool includePhone = true,
            DateTime? minDateCreated = null,
            DateTime? maxDateCreated = null,
            string emailDomain = null)
        {
            var users = new List<LoginUser>();
            minDateCreated = minDateCreated ?? DateTime.Now.AddYears(-1);
            maxDateCreated = maxDateCreated ?? DateTime.Now;
            emailDomain = emailDomain ?? EmailDomains[_random.Next(EmailDomains.Length)];

            for (long i = 0; i < count; i++)
            {
                var firstName = FirstNames[_random.Next(FirstNames.Length)];
                var lastName = LastNames[_random.Next(LastNames.Length)];
                var username = $"{firstName.ToLower()}.{lastName.ToLower()}{_random.Next(1000, 9999)}";
                var email = $"{username}@{emailDomain}";

                var country = specificCountry ?? Countries[_random.Next(Countries.Length)];
                // Simplified city selection: just pick a random city from Cities array
                var selectedCity = Cities[_random.Next(Cities.Length)];

                var phone = includePhone ? $"{CountryPhoneCodes[country]}-{_random.Next(10000000, 99999999)}" : null;

                users.Add(new LoginUser
                {
                    ID = Guid.NewGuid(),
                    Org_ID = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Username = username,
                    Password = GeneratePassword(passwordComplexity),
                    Phone = phone,
                    Address = $"{_random.Next(1, 100)} Main St",
                    City = selectedCity,
                    Country = country,
                    Company = Companies[_random.Next(Companies.Length)],
                    birthday = DateTime.Today.AddYears(-_random.Next(minAge, maxAge + 1)).AddDays(-_random.Next(0, 365)),
                    DateCreated = RandomDate(minDateCreated.Value, maxDateCreated.Value)
                });
            }

            return users;
        }

        private static string GeneratePassword(PasswordComplexity complexity)
        {
            string chars;
            int length;

            switch (complexity)
            {
                case PasswordComplexity.Simple:
                    chars = "abcdefghijklmnopqrstuvwxyz0123456789";
                    length = 8;
                    break;
                case PasswordComplexity.Medium:
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    length = 10;
                    break;
                case PasswordComplexity.Complex:
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
                    length = 12;
                    break;
                default:
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    length = 10;
                    break;
            }

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private static DateTime RandomDate(DateTime start, DateTime end)
        {
            int range = (end - start).Days;
            return start.AddDays(_random.Next(range));
        }
    }
}