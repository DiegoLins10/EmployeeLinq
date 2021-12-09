using System;
using System.IO;
using EmployeeLinq.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Reflection;

namespace EmployeeLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emp = new List<Employee>();
            Console.Write("Enter full file path: ");
            Console.WriteLine();
            //string path = Console.ReadLine();
            string path = @"C:\temp\en.csv";
            Console.WriteLine(path);
            using(StreamReader sr = File.OpenText(path)) 
            {
                while (!sr.EndOfStream)
                {
                    string[] employees = sr.ReadLine().Split(",");
                    string name = employees[0];
                    string email = employees[1];
                    double salary = double.Parse(employees[2], CultureInfo.InvariantCulture);
                    Employee e = new Employee(name, email, salary);
                    emp.Add(e);
                }
            }
            Console.Write("Digite um valor para ser mostrado os salarios superiores: ");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            var emailOrdemAlfabetica = emp.Where(e => e.Salary > valor).OrderBy(e => e.Email);
            double somaNomeM = emp.Where(e => e.Name[0] == 'M' || e.Name[0] == 'm').Sum(e => e.Salary);
            
            Console.WriteLine("Email of people whose salary is more than " + valor.ToString("f2", CultureInfo.InvariantCulture));
            foreach (var i in emailOrdemAlfabetica)
            {
                Console.WriteLine(i.Email);
            }
            Console.WriteLine();
            
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + somaNomeM.ToString("f2", CultureInfo.InvariantCulture));
        }
    }
}
