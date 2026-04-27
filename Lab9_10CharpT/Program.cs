using System;
using System.IO;

namespace Lab9
{
    class Program
    {
        static void Main()
        {
            GenerateTestFiles();

            while (true)
            {
                Console.WriteLine("\nChoose a task (1-4) or 0 to exit:");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1": Task1.Execute(); break;
                    case "2": Task2.Execute(); break;
                    case "3": Task3.Execute(); break;
                    case "4": Task4.Execute(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        private static void GenerateTestFiles()
        {
            string empFile = "employees.txt";
            if (!File.Exists(empFile))
            {
                File.WriteAllText(empFile, 
                    "Ivanov Ivan Ivanovich M 25 9500\n" +
                    "Petrov Petro Petrovich M 40 15000\n" +
                    "Semenova Anna Ivanivna F 35 12000\n" +
                    "Kovalchuk Oleh Petrovich M 22 8000\n" +
                    "Shevchenko Maria Olehivna F 28 9900\n" +
                    "Boyko Taras Ihorovich M 50 20000\n");
            }
        }
    }
}