using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== EXERCISE TRACKING SYSTEM ===\n");

        List<Activity> activities = new List<Activity>();

        Running running = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycling = new Cycling("04 Nov 2022", 45, 12.0);
        Swimming swimming = new Swimming("05 Nov 2022", 40, 30);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        Console.WriteLine("Activity Summaries:");
        Console.WriteLine(new string('-', 60));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine(new string('-', 60));
        Console.WriteLine("\nProgram completed successfully!");
        
        Console.WriteLine("\n=== ADDITIONAL ACTIVITIES FOR DEMONSTRATION ===\n");
        
        Running running2 = new Running("06 Nov 2022", 60, 5.5);
        Cycling cycling2 = new Cycling("07 Nov 2022", 30, 15.5);
        Swimming swimming2 = new Swimming("08 Nov 2022", 25, 20);
        
        List<Activity> moreActivities = new List<Activity>();
        moreActivities.Add(running2);
        moreActivities.Add(cycling2);
        moreActivities.Add(swimming2);
        
        foreach (Activity activity in moreActivities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}