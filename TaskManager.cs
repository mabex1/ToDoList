using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace ToDoList
{
    internal class TaskManager
    {
        public TaskManager()
        {
            if (File.Exists("tasks.json"))
            {
                string json = File.ReadAllText("tasks.json");
                tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
            }
        }

        public int InputRemoveIndex;

        private List<Task> tasks = new List<Task>();
        private bool IsDone = false;

        public void AddTask(string name)
        {
            tasks.Add(new Task
            {
                TaskName = name,
                IsTaskFinished = false,
            });
        }

        public void RemoveTask()
        {
            Console.WriteLine("Введите номер задачи");
            string WhichTask = Console.ReadLine();
            if (int.TryParse(WhichTask, out int index))
            {
                if (index > 0 && index <= tasks.Count)
                {
                    Console.WriteLine($"Задача {tasks[index - 1].TaskName} была удалена!");
                    tasks.RemoveAt(index - 1);
                }
                else
                {
                    Console.WriteLine("Введите действующий номер задачи");
                }
            }
            else
            {
                Console.WriteLine("Введите действующий номер задачи");
            }

        }

        public void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            
            for (int i = 0; i< tasks.Count; i++)
            {
                string status = tasks[i].IsTaskFinished ? "V" : "X";
                Console.WriteLine($"{i + 1}. {tasks[i].TaskName} [{status}]");
            }
        }

        public void TaskDone()
        {
            Console.WriteLine("Введите номер задачи");
            string WhichTask = Console.ReadLine();
            if (int.TryParse(WhichTask, out int index))
            {
                if (index > 0 && index <= tasks.Count)
                {
                    tasks[index-1].IsTaskFinished = true;
                    Console.WriteLine("Задача выполнена V");
                }
                else
                {
                    Console.WriteLine("Введите действующий номер задачи");
                }
            }
        }

        public void SaveToFile()
        {
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText("tasks.json", json);
        }
    }
}
