using System;
using System.Collections.Generic;

class TimeEntry
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<TimeEntry> entries = new List<TimeEntry>();

        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add time entry");
            Console.WriteLine("2. View all time entries");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter start time (YYYY-MM-DD HH:MM:SS):");
                    DateTime startTime = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter end time (YYYY-MM-DD HH:MM:SS):");
                    DateTime endTime = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter description:");
                    string description = Console.ReadLine();

                    TimeEntry newEntry = new TimeEntry
                    {
                        StartTime = startTime,
                        EndTime = endTime,
                        Description = description
                    };

                    entries.Add(newEntry);

                    Console.WriteLine("Time entry added.");
                    break;

                case "2":
                    Console.WriteLine("Time entries:");

                    foreach (TimeEntry entry in entries)
                    {
                        Console.WriteLine("Start time: {0}", entry.StartTime);
                        Console.WriteLine("End time: {0}", entry.EndTime);
                        Console.WriteLine("Description: {0}", entry.Description);
                        Console.WriteLine();
                    }
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
