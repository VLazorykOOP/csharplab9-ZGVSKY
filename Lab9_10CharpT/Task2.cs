using System;
using System.Collections;
using System.IO;

namespace Lab9
{
    public class Task2
    {
        public static void Execute()
        {
            Console.WriteLine("--- Employees Filter (Using Queue) ---");
            string filePath = "employees.txt";

            if (!File.Exists(filePath)) return;

            Queue highSalaryQueue = new Queue();

            Console.WriteLine("\n[Salary < 10000]:");

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    if (data.Length >= 6)
                    {
                        if (double.TryParse(data[5], out double salary))
                        {
                            if (salary < 10000)
                            {
                                Console.WriteLine(line);
                            }
                            else
                            {
                                highSalaryQueue.Enqueue(line);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n[Salary >= 10000]:");
            while (highSalaryQueue.Count > 0)
            {
                Console.WriteLine(highSalaryQueue.Dequeue());
            }
        }
    }
}