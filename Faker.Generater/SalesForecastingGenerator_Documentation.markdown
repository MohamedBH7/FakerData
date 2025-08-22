# SalesForecastingGenerator Documentation

## Description
Generates synthetic sales data for **ML regression** tasks like sales forecasting.

## Class: SalesForecastingGenerator

### Methods
- `GenerateData(int count = 100)`: Returns a list of `SalesData` objects.

### Data Fields

| Field         | Type      | Description                          |
|---------------|-----------|--------------------------------------|
| Date          | DateTime  | Transaction date                      |
| StoreID       | string    | Store identifier                      |
| ProductID     | string    | Product identifier                    |
| Price         | decimal   | Price per unit                        |
| QuantitySold  | int       | Number of units sold                  |
| TotalRevenue  | decimal   | Calculated as Price × QuantitySold    |

### Usage Example
```csharp
var sales = SalesForecastingGenerator.GenerateData(100);
