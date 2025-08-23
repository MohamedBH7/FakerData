using System;
using System.Collections.Generic;

namespace Faker.Generater
{
    /// <summary>
    /// Generates synthetic healthcare patient data for ML classification tasks.
    /// </summary>
    public static class HealthcarePredictionGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly string[] DefaultGenders = { "Male", "Female" };

        public class PatientData
        {
            public Guid PatientID { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public int BloodPressure { get; set; } // systolic mmHg
            public int Cholesterol { get; set; }   // mg/dL
            public bool HeartDisease { get; set; }
        }

        public static List<PatientData> GenerateData(
            int count = 100,
            int minAge = 20,
            int maxAge = 90,
            string[] genders = null,
            int minBloodPressure = 90,
            int maxBloodPressure = 180,
            int minCholesterol = 150,
            int maxCholesterol = 300,
            double heartDiseaseRisk = 0.2)
        {
            // Use default values if null
            genders = genders?.Length > 0 ? genders : DefaultGenders;

            // Validate inputs
            if (count < 0) throw new ArgumentException("Count must be non-negative.", nameof(count));
            if (minAge < 0 || maxAge < minAge) throw new ArgumentException("Invalid age range.", nameof(minAge));
            if (minBloodPressure < 0 || maxBloodPressure < minBloodPressure) throw new ArgumentException("Invalid blood pressure range.", nameof(minBloodPressure));
            if (minCholesterol < 0 || maxCholesterol < minCholesterol) throw new ArgumentException("Invalid cholesterol range.", nameof(minCholesterol));
            if (heartDiseaseRisk < 0 || heartDiseaseRisk > 1) throw new ArgumentException("Heart disease risk must be between 0 and 1.", nameof(heartDiseaseRisk));

            var data = new List<PatientData>();
            for (int i = 0; i < count; i++)
            {
                data.Add(new PatientData
                {
                    PatientID = Guid.NewGuid(),
                    Age = _random.Next(minAge, maxAge + 1),
                    Gender = genders[_random.Next(genders.Length)],
                    BloodPressure = _random.Next(minBloodPressure, maxBloodPressure + 1),
                    Cholesterol = _random.Next(minCholesterol, maxCholesterol + 1),
                    HeartDisease = _random.NextDouble() < heartDiseaseRisk
                });
            }
            return data;
        }
    }
}