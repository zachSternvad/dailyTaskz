using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class Task
{
    public string Name { get; set; }
    public bool Completed { get; set; }
    public DateTime Date { get; set; }

    public Task(string name, DateTime date)
    {
        Name = name;
        Completed = false;
        Date = date;
    }

    public override string ToString()
    {
        CultureInfo swedishCulture = new CultureInfo("sv-SE");
        return $"[{Date.ToString("yyyy-MM-dd", swedishCulture)}] {Name}: {(Completed ? "Completed" : "Pending")}";
    }
}

public class HabitTracker
{
    static void Main(string[] args)
    {
        List<Task> tasks = new List<Task>();
        string filename = "tasks.txt";
        LoadTasks(tasks, filename);

        while (true)
        {
            Console.WriteLine("\nHabit Tracker");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Task Completed");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Save Tasks");
            Console.WriteLine("5. Load Tasks");
            Console.WriteLine("6. Remove Task"); // Added Remove Task option
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask(tasks);
                    break;
                case "2":
                    MarkTaskCompleted(tasks);
                    break;
                case "3":
                    ViewTasks(tasks);
                    break;
                case "4":
                    SaveTasks(tasks, filename);
                    break;
                case "5":
                    LoadTasks(tasks, filename);
                    break;
                case "6":
                    RemoveTask(tasks); // Call RemoveTask function
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void AddTask(List<Task> tasks)
    {
        Console.Write("Enter task name: ");
        string name = Console.ReadLine();

        Console.Write("Enter date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            tasks.Add(new Task(name, date));
            Console.WriteLine("Task added.");
        }
        else
        {
            Console.WriteLine("Invalid date format.");
        }
    }

    static void MarkTaskCompleted(List<Task> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }

        Console.Write("Enter task number to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].Completed = true;
            Console.WriteLine("Task marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void ViewTasks(List<Task> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine($"{"Date",-12}{"Task Name",-20}{"Status"}");
        Console.WriteLine("--------------------------------------");

        foreach (var task in tasks)
        {
            CultureInfo swedishCulture = new CultureInfo("sv-SE");
            string dateString = task.Date.ToString("yyyy-MM-dd", swedishCulture);
            string status = task.Completed ? "Completed" : "Pending";
            Console.WriteLine($"{dateString,-12}{task.Name,-20}{status}");
        }
    }

    static void SaveTasks(List<Task> tasks, string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Name},{task.Date.ToString("yyyy-MM-dd")},{task.Completed}");
                }
            }
            Console.WriteLine("Tasks saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving tasks: {ex.Message}");
        }
    }

    static void LoadTasks(List<Task> tasks, string filename)
    {
        tasks.Clear();
        try
        {
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3 && DateTime.TryParse(parts[1], out DateTime date))
                        {
                            tasks.Add(new Task(parts[0], date) { Completed = bool.Parse(parts[2]) });
                        }
                    }
                }
                Console.WriteLine("Tasks loaded.");
            }
            else
            {
                Console.WriteLine("No saved tasks found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tasks: {ex.Message}");
        }
    }

    static void RemoveTask(List<Task> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to remove.");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }

        Console.Write("Enter the task number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task removed.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}