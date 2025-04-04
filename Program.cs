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

    public class  HabitTracker
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
        }
    }
}
