
using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

namespace Faker.Generater
{
    /// <summary>
    /// Generates synthetic healthcare patient data for ML classification tasks.
    /// </summary>
    /// HealthcarePredictionGenerator_Documentation.markdown
    public static class HealthcarePredictionGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly string[] Genders = { "Male", "Female" };

        public class PatientData
        {
            public Guid PatientID { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public int BloodPressure { get; set; } // systolic mmHg
            public int Cholesterol { get; set; }   // mg/dL
            public bool HeartDisease { get; set; }
        }

        public static List<PatientData> GenerateData(int count = 100)
        {
            var data = new List<PatientData>();
            for (int i = 0; i < count; i++)
            {
                data.Add(new PatientData
                {
                    PatientID = Guid.NewGuid(),
                    Age = _random.Next(20, 90),
                    Gender = Genders[_random.Next(Genders.Length)],
                    BloodPressure = _random.Next(90, 180),
                    Cholesterol = _random.Next(150, 300),
                    HeartDisease = _random.NextDouble() > 0.8 // ~20% risk
                });
            }
            return data;
        }
    }
}
