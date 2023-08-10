using GradebookRegards;
using System.IO;

namespace GradebookRegards
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NameOfObject
    {
        public NameOfObject(string name)
        {
            Name=name;
        }
        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{get;} 
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NameOfObject, IBook
    {
        public Book(string name) : base(name)
        {

        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

    }
    public class DiskBook : Book
    {
        public DiskBook(string name): base(name)
        {

        }

        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {   
            using (var writer   =   File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded  != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            // var writer  =   File.AppendText($"{Name}.txt");
            // writer.WriteLine(grade);
            // writer.Dispose();
        } 


        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var  reader  =   File.OpenText($"{Name}.txt"))
            {
                var line    =   reader.ReadLine();
                while (line!=null)
                {
                    var number=double.Parse(line);
                    result.Add(number);
                    line=reader.ReadLine();
                }
            }
            return  result;
        }
    }
    public class InMemoryBook : Book 
    {

        public InMemoryBook(string name) : base(name)
        {
            grades= new List<double>();
            Name   =   name;
        }


        public override void AddGrade(double grade)
        {
            if(grade<=100 && grade>=0)
            {
                grades.Add(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics  GetStatistics()
        {
            var result  =   new Statistics();

            for (int index = 0; index < grades.Count; index +=1)
            {
                result.Add(grades[index]);
                // if (grades[index]   ==  0)
                // {
                //     goto done;
                // }

            }

            done:
            return result;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        private List<double> grades;

        public const string CATEGORY = "Science";
    }
}