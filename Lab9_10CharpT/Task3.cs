using System;
using System.Collections;
using System.IO;

namespace Lab9
{
    public class Task3
    {
        public static void Execute()
        {
            Console.WriteLine("--- Employees ArrayList (IComparable, IComparer, ICloneable) ---");
            string filePath = "employees.txt";
            if (!File.Exists(filePath)) return;

            ArrayList employees = new ArrayList();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    if (data.Length >= 6)
                    {
                        employees.Add(new Employee(data[0], data[1], data[2], data[3], int.Parse(data[4]), double.Parse(data[5])));
                    }
                }
            }

            Console.WriteLine("\nOriginal List:");
            PrintEmployees(employees);

            employees.Sort(new SalaryComparer());

            Console.WriteLine("\nSorted by Salary (Using IComparer):");
            PrintEmployees(employees);

            Console.WriteLine("\nCloned and Modified Employee:");
            Employee firstClone = (Employee)((Employee)employees[0]!).Clone();
            firstClone.Salary += 5000;
            Console.WriteLine($"Original: {employees[0]}");
            Console.WriteLine($"Clone: {firstClone}");
        }

        private static void PrintEmployees(IEnumerable collection)
        {
            foreach (Employee emp in collection)
            {
                Console.WriteLine(emp);
            }
        }
    }

    public class Employee : ICloneable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public Employee(string lastName, string firstName, string patronymic, string gender, int age, double salary)
        {
            LastName = lastName; FirstName = firstName; Patronymic = patronymic;
            Gender = gender; Age = age; Salary = salary;
        }

        public object Clone()
        {
            return new Employee(LastName, FirstName, Patronymic, Gender, Age, Salary);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {Patronymic} | {Gender} | Age: {Age} | Salary: {Salary}";
        }
    }

    public class SalaryComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x is Employee e1 && y is Employee e2)
            {
                return e1.Salary.CompareTo(e2.Salary);
            }
            return 0;
        }
    }
}