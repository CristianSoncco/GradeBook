namespace GradebookRegards
{
    public class Book
    {
        public Book(string name)
        {
            grades= new List<double>();
            this.Name   =   name;
        }
        public void AddGrade(double grade)
        {
            if(grade<=100 && grade>=0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }

        public Statistics  GetStatistics()
        {
            var result  =   new Statistics();
            result.Average  =   0.0;
            result.High   =   double.MinValue;
            result.Low   =   double.MaxValue;

            for (int index = 0; index < grades.Count; index +=1)
            {
                if (grades[index]   ==  0)
                {
                    goto done;
                }
                result.Low  =   Math.Min(grades[index],result.Low);
                result.High =   Math.Max(grades[index],result.High);
                result.Average  =  result.Average + grades[index];
            }


            result.Average = result.Average/grades.Count;
            done:
            return result;
        }
        private List<double> grades;
        public string Name;
    }
}