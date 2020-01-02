using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new Book("Fane's book");

            book.GradeAdded += OneGradeAdded;

            EnterGrades(book);
            
            var stats = book.GetStatistics();

            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"Your lowest grade is {stats.Low}");
            Console.WriteLine($"Your highest grade is {stats.High}");
            Console.WriteLine($"Your letter grade is {stats.Letter}");
        }

        static void OneGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }

        public static void EnterGrades(IBook book)
        {
            while(true)
            {
                Console.WriteLine($"Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if(input == "q")
                {
                    break;
                }

                try {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
    }
}
