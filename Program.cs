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

            // string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter start time (YYYY-MM-DD HH:MM:SS):");
                DateTime startTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter end time (YYYY-MM-DD HH:MM:SS):");
                DateTime endTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter description:");
                string description = Console.ReadLine();

                TimeEntry entry = new TimeEntry
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    Description = description
                };

                entries.Add(entry);

                Console.WriteLine("Time entry added.");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Time entries:");

                foreach (TimeEntry entry in entries)
                {
                    Console.WriteLine("Start time: {0}", entry.StartTime);
                    Console.WriteLine("End time: {0}", entry.EndTime);
                    Console.WriteLine("Description: {0}", entry.Description);
                    Console.WriteLine();
                }
            }
            else if (choice == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
