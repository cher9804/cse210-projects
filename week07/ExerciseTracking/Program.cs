using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {


        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 11, 10), 38, 5),
            new Cycling(new DateTime(2024, 11, 10), 42, 20),
            new Swimming(new DateTime(2024, 11, 10), 23, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}