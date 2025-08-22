# MovieRecommendationGenerator Documentation

## Overview
The `MovieRecommendationGenerator` class in the `Faker.Generater` namespace is a utility for generating mock movie data for machine learning tasks, such as building recommendation systems. The `GenerateMovies` method produces a list of `Movie` objects with at least 7 attributes, suitable for use in datasets for training or testing ML models. It offers customizable parameters with sensible defaults for easy use.

## Method Signature
```csharp
public static List<Movie> GenerateMovies(
    long count = 100,
    int minYear = 1980,
    int maxYear = 2025,
    double minRating = 0.0,
    double maxRating = 10.0,
    int minRuntime = 60,
    int maxRuntime = 180,
    string specificGenre = null,
    string specificLanguage = null
)
```

## Parameters
- **count** (long, default: 100)
  - Number of movies to generate.
  - Example: `50` to generate 50 movies.
- **minYear** (int, default: 1980)
  - Minimum release year for movies.
  - Must be less than or equal to `maxYear`.
  - Example: `1990` for movies released on or after 1990.
- **maxYear** (int, default: 2025)
  - Maximum release year for movies. Cannot exceed the current year.
  - Example: `2020` for movies released on or before 2020.
- **minRating** (double, default: 0.0)
  - Minimum movie rating (0.0 to 10.0).
  - Must be less than or equal to `maxRating`.
  - Example: `4.0` for movies with at least a 4.0 rating.
- **maxRating** (double, default: 10.0)
  - Maximum movie rating (0.0 to 10.0).
  - Example: `8.0` for movies with ratings up to 8.0.
- **minRuntime** (int, default: 60)
  - Minimum runtime in minutes.
  - Must be less than or equal to `maxRuntime`.
  - Example: `90` for movies at least 90 minutes long.
- **maxRuntime** (int, default: 180)
  - Maximum runtime in minutes.
  - Example: `150` for movies up to 150 minutes long.
- **specificGenre** (string, default: null)
  - Specific genre for all movies. Must match a genre in the internal `Genres` array (e.g., "Action", "Comedy").
  - If null, a random genre is selected.
  - Example: `"Drama"` to restrict movies to the Drama genre.
- **specificLanguage** (string, default: null)
  - Specific language for all movies. Must match a language in the internal `Languages` array (e.g., "English", "Spanish").
  - If null, a random language is selected.
  - Example: `"English"` to restrict movies to English.

## Return Value
- A `List<Movie>` containing movie objects with the following properties:
  - `MovieId` (Guid): Unique identifier for the movie.
  - `Title` (string): Generated movie title (e.g., "The Quest 7").
  - `Genre` (string): Movie genre (e.g., "Action", "Drama").
  - `ReleaseYear` (int): Year of release (within the specified range).
  - `Rating` (double): Movie rating (0.0 to 10.0, rounded to 1 decimal place).
  - `RuntimeMinutes` (int): Runtime in minutes.
  - `Director` (string): Random director name (e.g., "Christopher Nolan").
  - `Language` (string): Movie language (e.g., "English", "Spanish").

## Usage Examples

### 1. Default Usage
Generate 100 movies with default settings (1980–current year, ratings 0.0–10.0, runtime 60–180 minutes, random genres and languages):
```csharp
var movies = MovieRecommendationGenerator.GenerateMovies();
```

### 2. Fully Controlled Usage
Generate 50 movies with specific parameters:
```csharp
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
```
This creates 50 English-language Comedy movies released between 2000 and 2020, with ratings between 5.0 and 9.0, and runtimes between 90 and 120 minutes.

### 3. Partial Control
Generate 20 Sci-Fi movies with custom ratings:
```csharp
var movies = MovieRecommendationGenerator.GenerateMovies(
    count: 20,
    specificGenre: "Sci-Fi",
    minRating: 6.0,
    maxRating: 10.0
);
```
This uses defaults for other parameters (1980–current year, 60–180 minutes, random languages).

### 4. Short Movies Only
Generate 10 movies with short runtimes:
```csharp
var movies = MovieRecommendationGenerator.GenerateMovies(
    count: 10,
    minRuntime: 60,
    maxRuntime: 90
);
```

## Sample Code to Display Movies
```csharp
foreach (var movie in movies)
{
    Console.WriteLine($"ID: {movie.MovieId}, Title: {movie.Title}, Genre: {movie.Genre}, " +
                      $"Year: {movie.ReleaseYear}, Rating: {movie.Rating}, Runtime: {movie.RuntimeMinutes} min, " +
                      $"Director: {movie.Director}, Language: {movie.Language}");
}
```

## Notes
- The `specificGenre` and `specificLanguage` parameters must match values in the internal `Genres` and `Languages` arrays exactly (e.g., "Sci-Fi", not "Science Fiction").
- Ensure `minYear` ≤ `maxYear`, `minRating` ≤ `maxRating`, and `minRuntime` ≤ `maxRuntime` to avoid runtime errors.
- The `Movie` class is defined within the `MovieRecommendationGenerator` class and includes 8 attributes for ML use.
- The generated data is suitable for ML tasks like recommendation systems, clustering, or classification, with attributes like `Rating` and `Genre` being particularly useful.
- For more realistic data, consider adding a mapping of genres to directors or languages to improve coherence (e.g., restricting certain directors to specific genres).

## Requirements
- Namespace: `Faker.Generater`
- Dependencies: `System`, `System.Collections.Generic`, `System.Linq`
- The `Movie` class is included in the generator and does not need to be defined separately.