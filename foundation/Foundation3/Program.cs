using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of activities
        var running = new Running("03 Nov 2022", 30, 4.8);  // 4.8 km
        var cycling = new Cycling("04 Nov 2022", 45, 20.0); // 20 kph
        var swimming = new Swimming("05 Nov 2022", 25, 20); // 20 laps

        // Add activities to a list
        var activities = new List<Activity> { running, cycling, swimming };

        // Display summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
