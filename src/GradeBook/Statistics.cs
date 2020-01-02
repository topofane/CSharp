using System;

namespace GradeBook
{

    public class Statistics
    {
        public Statistics()
        { 
            Count = 0;
            Sum = 0.0;
            Average = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
        
        public double Average { 
            get
            {
            return Sum/Count;
            }
            private set { Average = value; }
        }
        public double High { get; private set; }
        public double Low { get; private set; }
        public double Sum { get; private set; }
        public int Count { get; private set; }

        public char Letter { 
            get{
            switch(Average)
            {
                case var d when d >= 90.0:
                    return 'A';
                    case var d when d >= 80.0:
                    return'B';
                    case var d when d >= 70.0:
                    return'C';
                    case var d when d >= 60.0:
                    return 'D';
                    default:
                    return 'F';
            }
        } }

    }
}