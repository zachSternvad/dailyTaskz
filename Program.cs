using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dailyTaskz
{
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
            return $"[{Date.ToShortDateString()}] {Name}: {(Completed ? "Completed" : "Pending")}";
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
                Console.WriteLine("6. Exit");

                Console.WriteLine("Enter your choice: ");
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
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddTask(List<Task> tasks)
        {
            Console.WriteLine("Enter task name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter date (dd-MM-yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                tasks.Add(new Task(name, date));
                Console.WriteLine("Task added.");
            }
            else
            {
                Console.WriteLine("Invalid date format.")
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
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 <= tasks.Count)
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

    }
}
