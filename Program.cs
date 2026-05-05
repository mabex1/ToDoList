using System;

namespace ToDoList;

class Programm
{
    static bool IsRunning = true;
    static TaskManager manager = new TaskManager();

    static void Main(string[] args)
    {
        while (IsRunning)
        {
            Console.WriteLine("Спискок задач");
            Console.WriteLine("1.Добавить задачу");
            Console.WriteLine("2.Отметить выполненной задачу");
            Console.WriteLine("3.Удалить задачу");
            Console.WriteLine("4.Показать список задач");
            Console.WriteLine("5.Выйти");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Введите название задачи:");
                    string TaskName = Console.ReadLine();
                    manager.AddTask(TaskName);
                    break;
                case "2":
                    manager.TaskDone();
                    break;
                case "3":
                    manager.RemoveTask();
                    break;
                case "4":
                    manager.ShowTasks();
                    break;
                case "5":
                    manager.SaveToFile();
                    return;
                default:
                    Console.WriteLine("Введите число от 1 до 4");
                    break;
            }   
        }
    }
}