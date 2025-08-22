using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static Faker.Generater.MovieRecommendationGenerator;

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

            var customerturns = CustomerChurnGenerator.GenerateData(0);

            var salesdata = SalesForecastingGenerator.GenerateData(1);

            var healthdata = HealthcarePredictionGenerator.GenerateData(1);




            Console.WriteLine("\nDone!\n");

            // Ask user if they want to export
            if(users.Count == 0 && movies.Count == 0)
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
                    Console.WriteLine($"✅ Data exported to JSON files in: {folderPath}");
                }
                else if (formatChoice == "2")
                {
                    ExportToXml(users, Path.Combine(folderPath, "Users.xml"));
                    ExportToXml(movies, Path.Combine(folderPath, "Movies.xml"));
                    Console.WriteLine($"✅ Data exported to XML files in: {folderPath}");
                }
                else if (formatChoice == "3")
                {
                    ExportToCsv(users, Path.Combine(folderPath, "Users.csv"));
                    ExportToCsv(movies, Path.Combine(folderPath, "Movies.csv"));
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
            var sb = new StringBuilder();
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
