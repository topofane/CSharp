using System.Collections.Generic;
using System;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class Book : BookBase, IBook
    {
        public override event GradeAddedDelegate GradeAdded;

        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        
        private List<double> grades;

        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this,new EventArgs());
                }
            }
            else
            {
                Console.WriteLine("Invalid value!");
            }
            
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (var grade in grades)
            {
                result.Add(grade);    
            }
            
            return result;
        }
    }
}