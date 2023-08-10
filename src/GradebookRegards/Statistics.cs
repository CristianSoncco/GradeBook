using System;
namespace GradebookRegards
{
    public class Statistics
    {
        public  double  Average
        {
            get
            {
                return Sum /   Count; 
            }
        }
        
        public  Statistics()
        {
            High   =   double.MinValue;
            Low   =   double.MaxValue;
            Sum =   0.0;
            Count   =   0;
        }

        public  void    Add(double number){

            Low  =   Math.Min(number,Low);
            High =   Math.Max(number,High);
            Sum +=number;
            Count++;
        }

        public double High { get; set; }
        public double Low { get; set; }
        public char Letter 
        { 
            get
            {
            switch (Average)
            {
                case var d when d >= 90.0:
                    return 'A';
                case var d when d >= 80.0:
                    return 'B';
                case var d when d >= 70.0:
                    return 'C';
                case var d when d >= 60.0:
                    return 'D';
                default:
                    return 'F';
            }
            }
        }
        public double Sum { get; set; }
        public int Count { get; set; }
    }
}