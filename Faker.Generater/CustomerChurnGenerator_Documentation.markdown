# CustomerChurnGenerator Documentation

## Description
Generates synthetic data for **Customer Churn Prediction** ML tasks.

## Class: CustomerChurnGenerator

### Methods
- `GenerateData(int count = 100)`: Generates a list of `CustomerChurn` objects.

### Data Fields

| Field            | Type       | Description                                      |
|-----------------|-----------|-------------------------------------------------|
| CustomerID       | Guid      | Unique customer identifier                       |
| Age              | int       | Customer age                                     |
| Gender           | string    | Customer gender (Male/Female)                   |
| Country          | string    | Country of the customer                          |
| SubscriptionPlan | string    | Subscription type (Basic, Standard, Premium)    |
| MonthlySpend     | decimal   | Monthly spend in dollars                         |
| LastLoginDate    | DateTime  | Last login timestamp                             |
| Churned          | bool      | True if customer churned, False otherwise       |

### Usage Example
```csharp
var customers = CustomerChurnGenerator.GenerateData(50);
