# LoginUserGenerator Documentation

## Overview
The `LoginUserGenerator` class in the `Faker.Generater` namespace is a utility for generating mock `LoginUser` objects for testing or simulation purposes. The primary method, `GenerateUsers`, allows flexible generation of user data with customizable attributes such as age range, password complexity, country, phone numbers, creation dates, and email domains.

## Method Signature
```csharp
public static List<LoginUser> GenerateUsers(
    long count = 100,
    int minAge = 18,
    int maxAge = 60,
    PasswordComplexity passwordComplexity = PasswordComplexity.Medium,
    string specificCountry = null,
    bool includePhone = true,
    DateTime? minDateCreated = null,
    DateTime? maxDateCreated = null,
    string emailDomain = null
)
```

## Parameters
- **count** (long, default: 100)
  - Number of users to generate.
  - Example: `50` to generate 50 users.
- **minAge** (int, default: 18)
  - Minimum age for users.
  - Must be less than or equal to `maxAge`.
  - Example: `25` for users at least 25 years old.
- **maxAge** (int, default: 60)
  - Maximum age for users.
  - Must be greater than or equal to `minAge`.
  - Example: `45` for users no older than 45.
- **passwordComplexity** (PasswordComplexity enum, default: Medium)
  - Controls password complexity:
    - `Simple`: 8 characters (lowercase, numbers).
    - `Medium`: 10 characters (uppercase, lowercase, numbers).
    - `Complex`: 12 characters (uppercase, lowercase, numbers, special characters).
  - Example: `PasswordComplexity.Complex` for stronger passwords.
- **specificCountry** (string, default: null)
  - Specific country for all users. Must match a country in the internal `Countries` array (e.g., "USA", "Canada").
  - If null, a random country is selected.
  - Example: `"USA"` to restrict users to the USA.
- **includePhone** (bool, default: true)
  - Whether to include phone numbers with country-specific codes.
  - If false, phone numbers are set to null.
  - Example: `false` to exclude phone numbers.
- **minDateCreated** (DateTime?, default: null)
  - Earliest account creation date. If null, defaults to one year before the current date.
  - Example: `new DateTime(2024, 1, 1)` for accounts created after January 1, 2024.
- **maxDateCreated** (DateTime?, default: null)
  - Latest account creation date. If null, defaults to the current date.
  - Example: `DateTime.Now` for accounts created up to now.
- **emailDomain** (string, default: null)
  - Custom email domain for user emails. If null, a random domain from a predefined list is used.
  - Example: `"company.com"` for emails like `username@company.com`.

## Return Value
- A `List<LoginUser>` containing user objects with properties:
  - `ID` (Guid): Unique identifier.
  - `Org_ID` (Guid): Organization identifier.
  - `FirstName` (string): Random first name.
  - `LastName` (string): Random last name.
  - `Email` (string): Generated email address.
  - `Username` (string): Generated username (e.g., `firstname.lastname1234`).
  - `Password` (string): Random password based on complexity.
  - `Phone` (string): Phone number with country code, or null if `includePhone` is false.
  - `Address` (string): Random address (e.g., "42 Main St").
  - `City` (string): Random city from a predefined list.
  - `Country` (string): Country, either specific or random.
  - `Company` (string): Random company name.
  - `birthday` (DateTime): Random birth date within the specified age range.
  - `DateCreated` (DateTime): Random creation date within the specified range.

## Usage Examples

### 1. Default Usage
Generate 100 users with default settings (ages 18–60, medium passwords, random countries, phone numbers included, accounts created in the last year, random email domains):
```csharp
var users = LoginUserGenerator.GenerateUsers();
```

### 2. Fully Controlled Usage
Generate 50 users with specific parameters:
```csharp
var users = LoginUserGenerator.GenerateUsers(
    count: 50,
    minAge: 25,
    maxAge: 45,
    passwordComplexity: LoginUserGenerator.PasswordComplexity.Complex,
    specificCountry: "USA",
    includePhone: true,
    minDateCreated: new DateTime(2024, 1, 1),
    maxDateCreated: DateTime.Now,
    emailDomain: "company.com"
);
```
This creates 50 users aged 25–45, with complex 12-character passwords, from the USA, with phone numbers (e.g., "+1-12345678"), created between January 1, 2024, and now, with emails like `john.smith1234@company.com`.

### 3. Partial Control
Generate 20 users with complex passwords from the UK:
```csharp
var users = LoginUserGenerator.GenerateUsers(
    count: 20,
    passwordComplexity: LoginUserGenerator.PasswordComplexity.Complex,
    specificCountry: "UK"
);
```
This uses defaults for other parameters (ages 18–60, phone numbers included, random email domains, creation dates in the last year).

### 4. No Phone Numbers
Generate 10 users without phone numbers:
```csharp
var users = LoginUserGenerator.GenerateUsers(
    count: 10,
    includePhone: false
);
```

## Sample Code to Display Users
```csharp
foreach (var user in users)
{
    Console.WriteLine($"ID: {user.ID}, Name: {user.FirstName} {user.LastName}, Email: {user.Email}, " +
                      $"Username: {user.Username}, Password: {user.Password}, Phone: {user.Phone}, " +
                      $"Address: {user.Address}, City: {user.City}, Country: {user.Country}, " +
                      $"Company: {user.Company}, Birthday: {user.birthday:yyyy-MM-dd}, " +
                      $"Date Created: {user.DateCreated:yyyy-MM-dd}");
}
```

## Notes
- The `specificCountry` parameter must match a country in the internal `Countries` array exactly (e.g., "USA", not "United States").
- Ensure `minAge` is less than or equal to `maxAge` to avoid runtime errors.
- The `LoginUser` class must have the expected properties (`ID`, `Org_ID`, `FirstName`, etc.).
- Phone numbers use country codes from an internal dictionary, ensuring consistency with the selected country.
- City selection is random and not strictly tied to the country due to the lack of a city-country mapping. For stricter mapping, extend the class with a `Dictionary<string, string[]>`.

## Requirements
- Namespace: `Faker.Generater`
- Dependencies: `System`, `System.Collections.Generic`, `System.Linq`
- `LoginUser` class with appropriate properties.