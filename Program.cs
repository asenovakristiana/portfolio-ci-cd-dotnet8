using NUnitLite;
using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Running Selenium tests...");
        new AutoRun(Assembly.GetExecutingAssembly()).Execute(args);
    }
}