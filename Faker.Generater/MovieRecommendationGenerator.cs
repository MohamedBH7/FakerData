using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Generater
{
    /// <summary>
    /// A utility class for generating mock movie recommendation data for machine learning purposes.
    /// </summary>
    public static class MovieRecommendationGenerator
    {
        private static readonly Random _random = new Random();

        private static readonly string[] Genres = {
            "Action", "Comedy", "Drama", "Sci-Fi", "Horror", "Romance", "Thriller", "Adventure",
            "Fantasy", "Documentary", "Animation", "Crime", "Mystery", "Family", "Biography"
        };

        private static readonly string[] Directors = {
            "Steven Spielberg", "Christopher Nolan", "Quentin Tarantino", "Greta Gerwig",
            "Martin Scorsese", "Sofia Coppola", "James Cameron", "Ava DuVernay",
            "David Fincher", "Wes Anderson", "Ridley Scott", "Denis Villeneuve",
            "Taika Waititi", "Bong Joon-ho", "Alfonso Cuarón"
        };

        private static readonly string[] Languages = {
            "English", "Spanish", "French", "German", "Mandarin", "Hindi", "Japanese",
            "Korean", "Italian", "Arabic", "Portuguese", "Russian"
        };

        private static readonly string[] TitlePrefixes = {
            "The", "A", "Last", "First", "Dark", "Bright", "Hidden", "Lost", "Great", "Final"
        };

        private static readonly string[] TitleNouns = {
            "Journey", "Quest", "Adventure", "Secret", "World", "Star", "Dream", "Night",
            "City", "Legend", "Empire", "Shadow", "Light", "Hero", "Tale"
        };

        /// <summary>
        /// Represents a movie record for recommendation purposes.
        /// </summary>
        public class Movie
        {
            public Guid MovieId { get; set; }
            public string Title { get; set; }
            public string Genre { get; set; }
            public int ReleaseYear { get; set; }
            public double Rating { get; set; }
            public int RuntimeMinutes { get; set; }
            public string Director { get; set; }
            public string Language { get; set; }
        }

        /// <summary>
        /// Generates a list of mock movie recommendation data with customizable attributes.
        /// </summary>
        /// <param name="count">Number of movies to generate (default: 100).</param>
        /// <param name="minYear">Minimum release year (default: 1980).</param>
        /// <param name="maxYear">Maximum release year (default: current year).</param>
        /// <param name="minRating">Minimum movie rating (0.0 to 10.0, default: 0.0).</param>
        /// <param name="maxRating">Maximum movie rating (0.0 to 10.0, default: 10.0).</param>
        /// <param name="minRuntime">Minimum runtime in minutes (default: 60).</param>
        /// <param name="maxRuntime">Maximum runtime in minutes (default: 180).</param>
        /// <param name="specificGenre">Specific genre, or null for random (default: null).</param>
        /// <param name="specificLanguage">Specific language, or null for random (default: null).</param>
        /// <returns>A list of generated Movie objects.</returns>
        public static List<Movie> GenerateMovies(
            long count = 100,
            int minYear = 1980,
            int maxYear = 2025,
            double minRating = 0.0,
            double maxRating = 10.0,
            int minRuntime = 60,
            int maxRuntime = 180,
            string specificGenre = null,
            string specificLanguage = null)
        {
            var movies = new List<Movie>();
            maxYear = maxYear > DateTime.Now.Year ? DateTime.Now.Year : maxYear;

            for (long i = 0; i < count; i++)
            {
                var title = $"{TitlePrefixes[_random.Next(TitlePrefixes.Length)]} {TitleNouns[_random.Next(TitleNouns.Length)]} {_random.Next(1, 10)}";
                var genre = specificGenre ?? Genres[_random.Next(Genres.Length)];
                var language = specificLanguage ?? Languages[_random.Next(Languages.Length)];

                movies.Add(new Movie
                {
                    MovieId = Guid.NewGuid(),
                    Title = title,
                    Genre = genre,
                    ReleaseYear = _random.Next(minYear, maxYear + 1),
                    Rating = Math.Round(_random.NextDouble() * (maxRating - minRating) + minRating, 1),
                    RuntimeMinutes = _random.Next(minRuntime, maxRuntime + 1),
                    Director = Directors[_random.Next(Directors.Length)],
                    Language = language
                });
            }

            return movies;
        }
    }
}