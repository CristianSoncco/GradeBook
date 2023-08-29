using GradebookRegards;
using System;
using System.Collections.Generic;

namespace GradebookRegards
{
    class Program
    {
        static void Main(string[] args)
        {
            Book? book = new InMemoryBook("");
            book.AddGrade(90.5);
            EnterGrades(null);
            var stats= book.GetStatistics();

            // Console.WriteLine($"For the book Category {InMemoryBook.CATEGORY}");
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N0}");
            Console.WriteLine($"The letter grade is {stats.Letter}");







            // IBook book = new DiskBook("Scott's Grade book");
            // book.GradeAdded += OnGradeAdded;
            // EnterGrades(book);
            
            // var stats= book.GetStatistics();

            // // Console.WriteLine($"For the book Category {InMemoryBook.CATEGORY}");
            // Console.WriteLine($"For the book named {book.Name}");
            // Console.WriteLine($"The lowest grade is {stats.Low}");
            // Console.WriteLine($"The highest grade is {stats.High}");
            // Console.WriteLine($"The average grade is {stats.Average:N0}");
            // Console.WriteLine($"The letter grade is {stats.Letter}");
            
            // static void OnGradeAdded(object sender, EventArgs e)
            // {
            //     Console.WriteLine("A grade was added");
            // }
        }

        private static void EnterGrades(IBook? book)
        {
            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if(input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    //book.AddGrade('A');
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }  
        }
    }
}