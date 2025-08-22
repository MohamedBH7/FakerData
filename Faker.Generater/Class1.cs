using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generater
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Faker.Generater is ready to use!");
            // You can call LoginUserGenerator.GenerateUsers() here to generate users

            //var users = LoginUserGenerator.GenerateUsers();

            // Generate 50 users with specific parameters
            List<LoginUser> users = LoginUserGenerator.GenerateUsers(
                count: 50,                             // Number of users to generate
                minAge: 25,                           // Minimum age of users
                maxAge: 45,                           // Maximum age of users
                passwordComplexity: LoginUserGenerator.PasswordComplexity.Complex, // Complex passwords
                specificCountry: "Bahrain",                // Restrict to USA
                includePhone: true,                    // Include phone numbers
                minDateCreated: new DateTime(2024, 1, 1), // Accounts created after Jan 1, 2024
                maxDateCreated: DateTime.Now,         // Accounts created up to now
                emailDomain: "company.com"            // Custom email domain
            );

            if (users.Count > 0) 
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.ID}");
                Console.WriteLine($"Org_ID: {user.Org_ID}");
                Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"Phone: {user.Phone}");
                Console.WriteLine($"Address: {user.Address}, {user.City}, {user.Country}");
                Console.WriteLine($"Company: {user.Company}");
                Console.WriteLine($"Birthday: {user.birthday:yyyy-MM-dd}");
                Console.WriteLine($"Date Created: {user.DateCreated:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine(new string('-', 50));
            }

            var movies = MovieRecommendationGenerator.GenerateMovies(
            count: 50,
            minYear: 2000,
            maxYear: 2020,
            minRating: 5.0,
            maxRating: 9.0,
            minRuntime: 90,
            maxRuntime: 120,
            specificGenre: "Comedy",
            specificLanguage: "English"
        );
            if(movies.Count > 0)
                foreach (var movie in movies)
            {
                Console.WriteLine($"ID: {movie.MovieId}, Title: {movie.Title}, Genre: {movie.Genre}, " +
                                  $"Year: {movie.ReleaseYear}, Rating: {movie.Rating}, Runtime: {movie.RuntimeMinutes} min, " +
                                  $"Director: {movie.Director}, Language: {movie.Language}");
            }
            Console.WriteLine("Done!");
        }
    }
}
