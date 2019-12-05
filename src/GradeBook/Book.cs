using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        
        private List<double> grades;
        private string name;

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach (var number in grades)
            {
                lowGrade = Math.Min(number, lowGrade);
                highGrade = Math.Max(number, highGrade);
                result += number;
            }
            
            result /= grades.Count;

            Console.WriteLine($"The average grade is {result:N1}");
            Console.WriteLine($"Your lowest grade is {lowGrade}");
            Console.WriteLine($"Your highest grade is {highGrade}");
        }
    }
}