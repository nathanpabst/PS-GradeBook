using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            //instantiating the grade book
            GradeBook book = new GradeBook();

            book.NameChanged += OnNameChanged;
            
            book.Name = "Nate's Grade Book";
            book.Name = "Grade Book";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            //(int) as type-casting
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);


            Console.ReadLine();
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        //WriteResult is an overloaded method same name with different signatures. see float and int
        static void WriteResult(string description, int result)
        {
            //formatting string using {} as placeholders. :F2 formats floating point number with 2 decimal places
            //Console.WriteLine("{0}: {1:F2}", description, result);
            //using string interpolation
            Console.WriteLine($"{description}: {result:F2}");
        }

    }
}
