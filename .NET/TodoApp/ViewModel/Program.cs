using Models;
using Repositories;

namespace ViewModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taskRepo = new TaskRepository("task.json");

            while (true)
            {
                Console.WriteLine("\n======ToDo App======");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Mark task as done");
                Console.WriteLine("4. Remove a Task");
                Console.WriteLine("0. Exit");
                Console.Write("Select choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter task name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter task description: ");
                        string desc = Console.ReadLine();

                        TaskItem task1 = new TaskItem
                        {
                            Name = name,
                            Description = desc
                        };
                        taskRepo.Add(task1);

                        break;
                    case "2":
                        foreach (var t in taskRepo.GetAll())
                        {
                            Console.WriteLine($"{t.TaskId} | {t.Name} | {t.Description} | {t.IsCompleted}");
                        }
                        break;
                    case "3":
                        Console.Write("Enter Task ID: ");
                        var taskId1 = Guid.Parse(Console.ReadLine());
                        var task2 = taskRepo.GetById(taskId1);

                        if (task2 != null)
                        {
                            task2.IsCompleted = true;
                            taskRepo.Update(task2);
                            Console.WriteLine("Task marked as done!!!");
                        }
                        else
                        {
                            Console.WriteLine("Task not found");
                        }

                        break;
                    case "4":
                        Console.Write("Enter Task ID: ");
                        var delId = Guid.Parse(Console.ReadLine());
                        var task3 = taskRepo.GetById(delId);

                        if (task3 != null)
                        {
                            taskRepo.Delete(delId);
                            Console.WriteLine("Task delted!!!");
                        }

                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!!!");
                        break;
                }
            }
        }
    }
}
