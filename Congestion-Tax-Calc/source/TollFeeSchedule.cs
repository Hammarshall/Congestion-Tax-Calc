using System;
using System.Collections.Generic;

namespace TollFeeCalculator
{
    public class TollFeeSchedule
    {
        private readonly Dictionary<string, Dictionary<TimeSpan, int>> _cityTollFees = new Dictionary<string, Dictionary<TimeSpan, int>>
        {
            // Initialize with city-specific toll fees
            {
                "Gothenburg", new Dictionary<TimeSpan, int>
                {
                    { new TimeSpan(6, 0, 0), 8 },
                    { new TimeSpan(6, 30, 0), 13 },
                    { new TimeSpan(7, 0, 0), 18 },
                    { new TimeSpan(8, 0, 0), 13 },
                    { new TimeSpan(8, 30, 0), 8 },
                    { new TimeSpan(15, 0, 0), 13 },
                    { new TimeSpan(15, 30, 0), 18 },
                    { new TimeSpan(17, 0, 0), 13 },
                    { new TimeSpan(18, 0, 0), 8 },
                    { TimeSpan.FromDays(1), 0 } // For unspecified times
                }
            },
            {
                "Stockholm", new Dictionary<TimeSpan, int>
                {
                    { new TimeSpan(6, 0, 0), 10 },
                    { new TimeSpan(6, 30, 0), 15 },
                    { new TimeSpan(7, 0, 0), 20 },
                    { new TimeSpan(8, 0, 0), 15 },
                    { new TimeSpan(15, 0, 0), 15 },
                    { new TimeSpan(15, 30, 0), 20 },
                    { new TimeSpan(17, 0, 0), 15 },
                    { new TimeSpan(18, 0, 0), 10 },
                    { TimeSpan.FromDays(1), 0 } // For unspecified times
                }
            },
            // Add more cities and their toll fees here...
        };

        // Checks if the provided city has a specific toll fee configuration
        public bool IsValidCity(string city) => _cityTollFees.ContainsKey(city);

        // Retrieves the toll fee schedule for a given city
        public Dictionary<TimeSpan, int> GetTollFeesForCity(string city) => _cityTollFees[city];

        // Checks and Determines if a given time is within the toll-free hours
        public bool IsTollFreeTime(TimeSpan time) => time >= new TimeSpan(18, 30, 0) || time < new TimeSpan(6, 0, 0);

        // Gets the toll fee for a specific time of day based on the city's toll fee schedule
        public int GetTollFee(TimeSpan timeOfDay, Dictionary<TimeSpan, int> tollFees)
        {
            // Iterate through the fee schedule to find the matching time interval and return the corresponding fee
            foreach (var fee in tollFees)
            {
                if (timeOfDay < fee.Key)
                    return fee.Value;
            }
            return 0;
            // Return 0 if no matching interval is found, indicating a toll-free time
        }
    }
}