using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static Faker.Generater.MovieRecommendationGenerator;
using static Faker.Generater.CustomerChurnGenerator;
using static Faker.Generater.SalesForecastingGenerator;
using static Faker.Generater.HealthcarePredictionGenerator;

namespace Faker.Generater
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Faker.Generater is ready to use!\n");

            // Generate Users
            List<LoginUser> users = LoginUserGenerator.GenerateUsers(
                count: 0,
                minAge: 25,
                maxAge: 45,
                passwordComplexity: LoginUserGenerator.PasswordComplexity.Complex,
                specificCountry: "Bahrain",
                includePhone: true,
                minDateCreated: new DateTime(2024, 1, 1),
                maxDateCreated: DateTime.Now,
                emailDomain: "company.com"
            );

            // Print Users Table
            PrintUsersTable(users);

            // Generate Movies
            var movies = MovieRecommendationGenerator.GenerateMovies(
                count: 0,
                minYear: 2000,
                maxYear: 2020,
                minRating: 5.0,
                maxRating: 9.0,
                minRuntime: 90,
                maxRuntime: 120,
                specificGenre: "Comedy",
                specificLanguage: "English"
            );

            // Print Movies Table
            PrintMoviesTable(movies);

            // Generate Customer Churn Data
            var customerChurns = CustomerChurnGenerator.GenerateData(
                count: 5, // Generate 5 records for a small, manageable dataset to demonstrate
                minAge: 20, // Minimum age of 20 to focus on younger adults
                maxAge: 60, // Maximum age of 60 to cover a broad working-age range
                genders: new[] { "Male", "Female", "Non-Binary" }, // Include Non-Binary for diversity
                countries: new[] { "USA", "UK", "India" }, // Focus on key markets for customer base
                subscriptionPlans: new[] { "Basic", "Premium" }, // Only Basic and Premium plans to simplify analysis
                minMonthlySpend: 15m, // Minimum spend of $15 to reflect realistic subscription costs
                maxMonthlySpend: 150m, // Maximum spend of $150 to include premium users
                lastLoginRange: (new DateTime(2024, 6, 1), DateTime.Now), // Last login from June 2024 to now for recent activity
                churnRate: 0.4 // 40% churn rate to simulate a challenging retention scenario
            );

            // Print Customer Churn Table
            PrintCustomerChurnTable(customerChurns);

            // Generate Sales Data
            var salesData = SalesForecastingGenerator.GenerateData(
                count: 5, // Generate 5 records for a small, manageable dataset to demonstrate
                dateRange: (new DateTime(2024, 1, 1), DateTime.Now), // Sales from Jan 2024 to now for recent trends
                stores: new[] { "StoreX", "StoreY" }, // Two stores to focus on specific retail locations
                products: new[] { "ItemA", "ItemB", "ItemC" }, // Three products to simulate a small product catalog
                minPrice: 10m, // Minimum price of $10 to reflect affordable items
                maxPrice: 200m, // Maximum price of $200 to include premium items
                minQuantity: 1, // Minimum quantity of 1 to ensure at least one sale
                maxQuantity: 100 // Maximum quantity of 100 to allow for bulk sales
            );

            // Print Sales Data Table
            PrintSalesDataTable(salesData);

            // Generate Healthcare Data
            var healthData = HealthcarePredictionGenerator.GenerateData(
                count: 5, // Generate 5 records for a small, manageable dataset to demonstrate
                minAge: 30, // Minimum age of 30 to focus on adults at risk
                maxAge: 80, // Maximum age of 80 to cover older populations
                genders: new[] { "Male", "Female" }, // Standard genders for medical data
                minBloodPressure: 80, // Minimum blood pressure of 80 mmHg for realistic low values
                maxBloodPressure: 200, // Maximum blood pressure of 200 mmHg for high-risk cases
                minCholesterol: 120, // Minimum cholesterol of 120 mg/dL for realistic low values
                maxCholesterol: 350, // Maximum cholesterol of 350 mg/dL for high-risk cases
                heartDiseaseRisk: 0.25 // 25% heart disease risk to simulate a moderate-risk population
            );

            // Print Healthcare Data Table
            PrintPatientDataTable(healthData);

            Console.WriteLine("\nDone!\n");

            // Ask user if they want to export
            if (users.Count == 0 && movies.Count == 0 && customerChurns.Count == 0 && salesData.Count == 0 && healthData.Count == 0)
                return;
            Console.Write("Do you want to export the data? (y/n): ");
            var exportChoice = Console.ReadLine()?.Trim().ToLower();

            if (exportChoice == "y")
            {
                Console.Write("Enter export folder path (press Enter for default 'Exports' folder): ");
                string folderPath = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(folderPath))
                {
                    folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exports");
                }

                // Create folder if not exists
                Directory.CreateDirectory(folderPath);

                Console.Write("Choose format: (1) JSON (2) XML (3) CSV: ");
                var formatChoice = Console.ReadLine()?.Trim();

                if (formatChoice == "1")
                {
                    ExportToJson(users, Path.Combine(folderPath, "Users.json"));
                    ExportToJson(movies, Path.Combine(folderPath, "Movies.json"));
                    ExportToJson(customerChurns, Path.Combine(folderPath, "CustomerChurn.json"));
                    ExportToJson(salesData, Path.Combine(folderPath, "SalesData.json"));
                    ExportToJson(healthData, Path.Combine(folderPath, "HealthData.json"));
                    Console.WriteLine($"✅ Data exported to JSON files in: {folderPath}");
                }
                else if (formatChoice == "2")
                {
                    ExportToXml(users, Path.Combine(folderPath, "Users.xml"));
                    ExportToXml(movies, Path.Combine(folderPath, "Movies.xml"));
                    ExportToXml(customerChurns, Path.Combine(folderPath, "CustomerChurn.xml"));
                    ExportToXml(salesData, Path.Combine(folderPath, "SalesData.xml"));
                    ExportToXml(healthData, Path.Combine(folderPath, "HealthData.xml"));
                    Console.WriteLine($"✅ Data exported to XML files in: {folderPath}");
                }
                else if (formatChoice == "3")
                {
                    ExportToCsv(users, Path.Combine(folderPath, "Users.csv"));
                    ExportToCsv(movies, Path.Combine(folderPath, "Movies.csv"));
                    ExportToCsv(customerChurns, Path.Combine(folderPath, "CustomerChurn.csv"));
                    ExportToCsv(salesData, Path.Combine(folderPath, "SalesData.csv"));
                    ExportToCsv(healthData, Path.Combine(folderPath, "HealthData.csv"));
                    Console.WriteLine($"✅ Data exported to CSV files in: {folderPath}");
                }
                else
                {
                    Console.WriteLine("❌ Invalid choice. No export performed.");
                }
            }
        }

        static void PrintUsersTable(List<LoginUser> users)
        {
            if (users.Count > 0)
            {
                Console.WriteLine("USERS TABLE");
                Console.WriteLine(new string('-', 150));
                Console.WriteLine($"| {"ID",-5} | {"Org_ID",-7} | {"Name",-20} | {"Email",-30} | {"Username",-15} | {"Password",-15} | {"Phone",-15} | {"Country",-10} | {"Date Created",-20} |");
                Console.WriteLine(new string('-', 150));

                foreach (var user in users)
                {
                    Console.WriteLine(
                        $"| {user.ID,-5} | {user.Org_ID,-7} | {user.FirstName + " " + user.LastName,-20} | {user.Email,-30} | " +
                        $"{user.Username,-15} | {user.Password,-15} | {user.Phone,-15} | {user.Country,-10} | {user.DateCreated:yyyy-MM-dd HH:mm,-20} |");
                }

                Console.WriteLine(new string('-', 150));
                Console.WriteLine();
            }
        }

        static void PrintMoviesTable(List<Movie> movies)
        {
            if (movies.Count > 0)
            {
                Console.WriteLine("MOVIES TABLE");
                Console.WriteLine(new string('-', 140));
                Console.WriteLine($"| {"ID",-5} | {"Title",-30} | {"Genre",-10} | {"Year",-6} | {"Rating",-6} | {"Runtime",-8} | {"Director",-20} | {"Language",-10} |");
                Console.WriteLine(new string('-', 140));

                foreach (var movie in movies)
                {
                    Console.WriteLine(
                        $"| {movie.MovieId,-5} | {movie.Title,-30} | {movie.Genre,-10} | {movie.ReleaseYear,-6} | {movie.Rating,-6:F1} | " +
                        $"{movie.RuntimeMinutes + " min",-8} | {movie.Director,-20} | {movie.Language,-10} |");
                }

                Console.WriteLine(new string('-', 140));
            }
        }

        static void PrintCustomerChurnTable(List<CustomerChurn> customerChurns)
        {
            if (customerChurns.Count > 0)
            {
                Console.WriteLine("CUSTOMER CHURN TABLE");
                Console.WriteLine(new string('-', 160));
                Console.WriteLine($"| {"CustomerID",-36} | {"Age",-5} | {"Gender",-10} | {"Country",-10} | {"SubscriptionPlan",-15} | {"MonthlySpend",-12} | {"LastLoginDate",-20} | {"Churned",-8} |");
                Console.WriteLine(new string('-', 160));

                foreach (var churn in customerChurns)
                {
                    Console.WriteLine(
                        $"| {churn.CustomerID,-36} | {churn.Age,-5} | {churn.Gender,-10} | {churn.Country,-10} | " +
                        $"{churn.SubscriptionPlan,-15} | {churn.MonthlySpend,-12:F2} | {churn.LastLoginDate:yyyy-MM-dd HH:mm,-20} | {churn.Churned,-8} |");
                }

                Console.WriteLine(new string('-', 160));
                Console.WriteLine();
            }
        }

        static void PrintSalesDataTable(List<SalesData> salesData)
        {
            if (salesData.Count > 0)
            {
                Console.WriteLine("SALES DATA TABLE");
                Console.WriteLine(new string('-', 120));
                Console.WriteLine($"| {"Date",-20} | {"StoreID",-10} | {"ProductID",-10} | {"Price",-10} | {"QuantitySold",-12} | {"TotalRevenue",-12} |");
                Console.WriteLine(new string('-', 120));

                foreach (var sale in salesData)
                {
                    Console.WriteLine(
                        $"| {sale.Date:yyyy-MM-dd HH:mm,-20} | {sale.StoreID,-10} | {sale.ProductID,-10} | {sale.Price,-10:F2} | {sale.QuantitySold,-12} | {sale.TotalRevenue,-12:F2} |");
                }

                Console.WriteLine(new string('-', 120));
                Console.WriteLine();
            }
        }

        static void PrintPatientDataTable(List<PatientData> healthData)
        {
            if (healthData.Count > 0)
            {
                Console.WriteLine("PATIENT DATA TABLE");
                Console.WriteLine(new string('-', 130));
                Console.WriteLine($"| {"PatientID",-36} | {"Age",-5} | {"Gender",-10} | {"BloodPressure",-12} | {"Cholesterol",-12} | {"HeartDisease",-12} |");
                Console.WriteLine(new string('-', 130));

                foreach (var patient in healthData)
                {
                    Console.WriteLine(
                        $"| {patient.PatientID,-36} | {patient.Age,-5} | {patient.Gender,-10} | {patient.BloodPressure,-12} | {patient.Cholesterol,-12} | {patient.HeartDisease,-12} |");
                }

                Console.WriteLine(new string('-', 130));
                Console.WriteLine();
            }
        }

        static void ExportToJson<T>(List<T> data, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filePath, JsonSerializer.Serialize(data, options));
        }

        static void ExportToXml<T>(List<T> data, string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }
        }

        static void ExportToCsv<T>(List<T> data, string filePath)
        {
            var sb =  new StringBuilder();
            var props = typeof(T).GetProperties();

            // Header
            foreach (var prop in props)
            {
                sb.Append(prop.Name + ",");
            }
            sb.AppendLine();

            // Rows
            foreach (var item in data)
            {
                foreach (var prop in props)
                {
                    var value = prop.GetValue(item, null) ?? "";
                    sb.Append(value.ToString().Replace(",", " ") + ",");
                }
                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}