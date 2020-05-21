using System;
using System.Collections.Generic;

namespace dataAPI_back
{
    public class Helpers
    {
        private static Random _rand = new Random();
        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }
        internal static string MakeUniqueClientName(List<string> names)
        {
            var maxNames = bizPrefix.Count * bizSuffix.Count;
            if (names.Count >= maxNames)
            {
                throw new System.InvalidOperationException("Maximum number of unique names exceeded");
            }

            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            var bizName = prefix + suffix;
            
            // recursion
            if(names.Contains(bizName))
            {
                MakeUniqueClientName(names);
            }
            return bizName;
        }

        internal static string MakeClientEmail(string sClientName)
        {
            return $"contact@{sClientName.ToLower()}.com";
        }

        internal static string GetRandomState()
        {
            return GetRandom(usStates);
        }

        internal static decimal GetRandomOrderTotal()
        {
            // return a random number 
            return _rand.Next(100, 5000);
        }

        internal static DateTime GetRandomOrderPlaced()
        {
            // random time for the orders
            var end = DateTime.Now;
            // max in the pass = 90 days = max history (temp)
            var start = end.AddDays(-90);
            TimeSpan possibleSpan = end - start;
            // hours, minutes, seconds -> TimeSpan
            // random DateTime with random number of minutes
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes), 0);

            // plus the start with a space of 90 days from the curretn datetime
            return start + newSpan;
        }

        internal static DateTime? GetRandomOrderCompleted(DateTime orderPlaced)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            // time passed for status complete
            var timePassed = now - orderPlaced;

            // not completed ?
            if(timePassed < minLeadTime)
            {
                return null;
            }
            // else return a random number between 7 and 14 days
            return orderPlaced.AddDays(_rand.Next(7, 14));
        }

        private static readonly List<string> usStates = new List<string>()
        {
            "AK", "AL","AZ",  "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
        };

        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ABC",
            "XYZ",
            "Acme",
            "MainSt",
            "Ready",
            "Magic",
            "Fluent",
            "Peak",
            "Forward",
            "Enterprise",
            "Sales"
        };

        private static readonly List<string> bizSuffix = new List<string>()
        {
            "Co",
            "Corp",
            "Holdings",
            "Corporation",
            "Movers",
            "Cleaners",
            "Bakery",
            "Apparel",
            "Rentals",
            "Storage",
            "Transit",
            "Logistics"   
        };
    }
}