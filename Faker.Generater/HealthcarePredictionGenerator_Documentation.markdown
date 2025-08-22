# HealthcarePredictionGenerator Documentation

## Description
Generates synthetic patient data for **ML classification** tasks such as predicting heart disease.

## Class: HealthcarePredictionGenerator

### Methods
- `GenerateData(int count = 100)`: Returns a list of `PatientData` objects.

### Data Fields

| Field          | Type      | Description                           |
|----------------|-----------|---------------------------------------|
| PatientID      | Guid      | Unique patient identifier              |
| Age            | int       | Patient age                            |
| Gender         | string    | Gender (Male/Female)                  |
| BloodPressure  | int       | Systolic blood pressure in mmHg        |
| Cholesterol    | int       | Cholesterol level in mg/dL             |
| HeartDisease   | bool      | True if patient has heart disease      |

### Usage Example
```csharp
var patients = HealthcarePredictionGenerator.GenerateData(50);
