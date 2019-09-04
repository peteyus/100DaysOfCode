namespace CodeWars.Day3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Kata
    {
        public static string WhatIsTheTime(string timeInMirror)
        {
            //return "05:25" --> "06:35";
            // Happy Coding

            DateTime.TryParse(timeInMirror, out DateTime dateTime);

            if (dateTime == null)
            {
                throw new InvalidOperationException("What's wrong with you boy?");
            }

            int minute = dateTime.Minute;
            int minuteDirection = minute > 30 || minute == 0 ? -1 : 1;
            int correctedMinute = 30 + Math.Abs(30 - minute) * minuteDirection;

            int hour = dateTime.Hour;
            int correctedHour = hour;
            if (correctedMinute > 0 || (correctedHour != 12 && correctedHour != 6))
            {
                int hourDirection = hour > 6  && hour < 12 ? -1 : 1;
                int onTheHour = correctedMinute == 0 ? 0 : 1;
                correctedHour = hour + (hourDirection * (onTheHour + (2 * (hour - 6))));

                correctedHour = correctedHour == 0 ? 12 : correctedHour;
            }

            return $"{correctedHour:00}:{correctedMinute:00}";
        }
    }
}