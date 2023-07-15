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
            Console.WriteLine("2. Add log out");
            Console.WriteLine("3. View all time entries");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTimeEntry(entries);
                    break;

                case "2":
                    AddLogOut(entries);
                    break;

                case "3":
                    ViewAllTimeEntries(entries);
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void AddTimeEntry(List<TimeEntry> entries)
    {
        Console.WriteLine("Enter start time (YYYY-MM-DD HH:MM:SS):");
        DateTime startTime = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter description:");
        string description = Console.ReadLine();

        TimeEntry newEntry = new TimeEntry
        {
            StartTime = startTime,
            Description = description
        };

        entries.Add(newEntry);

        Console.WriteLine("Time of entry added.");
    }

    static void AddLogOut(List<TimeEntry> entries)
    {

        Console.WriteLine("Enter end time (YYYY-MM-DD HH:MM:SS):");
        DateTime endTime = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter description:");
        string description = Console.ReadLine();

        TimeEntry newEntry = new TimeEntry
        {
            EndTime = endTime,
            Description = description
        };

        entries.Add(newEntry);

        Console.WriteLine("Time of log out added.");
    }

    static void ViewAllTimeEntries(List<TimeEntry> entries)
    {
        Console.WriteLine("Time entries:");

        foreach (TimeEntry entry in entries)
        {
            Console.WriteLine("Start time: {0}", entry.StartTime);
            Console.WriteLine("Description: {0}", entry.Description);
            Console.WriteLine("Entry: {0}", GetEntryStatus(entry.StartTime, entry.EndTime));;
            Console.WriteLine();
        }

    }

    static string GetEntryStatus(DateTime startTime, DateTime endTime)
    {
        string entryStatus = "";

        if (startTime.TimeOfDay <= new TimeSpan(8, 0, 0))
        {
            entryStatus += "On time";
        }
        else
        {
            entryStatus += "Late";
        }

        entryStatus += " | ";

        if (endTime.TimeOfDay <= new TimeSpan(16, 0, 0))
        {
            entryStatus += "On time";
        }
        else
        {
            entryStatus += "Overtime";
        }

        return entryStatus;
    }
}
