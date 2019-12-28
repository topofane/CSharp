using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Fane's book");
            book.AddGrade(89.1);
            book.AddGrade(90.1);
            book.AddGrade(77.5);
            
            var stats = book.GetStatistics();

            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"Your lowest grade is {stats.Low}");
            Console.WriteLine($"Your highest grade is {stats.High}");
        }
    }
}
