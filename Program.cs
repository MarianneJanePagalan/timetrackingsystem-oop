using System;
using System.Collections.Generic;

namespace TimeTrackingSystem
{
    class TimeEntry
    {
        public DateTime StartTime { get; set; }
        public string Description { get; set; }
    }

    class LogOut
    {
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<TimeEntry> entries = new List<TimeEntry>();
            List<LogOut> logouts = new List<LogOut>();

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Record Time Entry");
                Console.WriteLine("2. Access Time Entry Records");
                Console.WriteLine("3. Perform Log Out");
                Console.WriteLine("4. Review Log Out History");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTimeEntry(entries);
                        break;

                    case "2":
                        ViewAllTimeEntries(entries);
                        break;

                    case "3":
                        AddLogOut(logouts);
                        break;

                    case "4":
                        ViewAllLogOuts(logouts);
                        break;

                    case "5":
                        return; // Exit the program

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

            Console.WriteLine("Time entry added.");
        }

        static void ViewAllTimeEntries(List<TimeEntry> entries)
        {
            Console.WriteLine("Time entries:");

            foreach (TimeEntry entry in entries)
            {
                Console.WriteLine("Start time: {0}", entry.StartTime);
                Console.WriteLine("Description: {0}", entry.Description);
                Console.WriteLine("Entry: {0}", GetEntryStatus(entry.StartTime));
                Console.WriteLine();
            }
        }

        static void AddLogOut(List<LogOut> logouts)
        {
            Console.WriteLine("Enter end time (YYYY-MM-DD HH:MM:SS):");
            DateTime endTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();

            LogOut newLogOut = new LogOut
            {
                EndTime = endTime,
                Description = description
            };

            logouts.Add(newLogOut);

            Console.WriteLine("Log out added.");
        }

        static void ViewAllLogOuts(List<LogOut> logouts)
        {
            Console.WriteLine("Log outs:");

            foreach (LogOut entry in logouts)
            {
                Console.WriteLine("End Time: {0}", entry.EndTime);
                Console.WriteLine("Description: {0}", entry.Description);
                Console.WriteLine("Log: {0}", GetLogOutStatus(entry.EndTime));
                Console.WriteLine();
            }
        }

        static string GetEntryStatus(DateTime startTime)
        {
            return startTime.TimeOfDay <= new TimeSpan(8, 0, 0) ? "On time" : "Late";
        }

        static string GetLogOutStatus(DateTime endTime)
        {
            return endTime.TimeOfDay <= new TimeSpan(16, 0, 0) ? "On time" : "Overtime";
        }
    }
}

