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
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            //(int) as type-casting
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);


            Console.ReadLine();
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        //overloaded method ex. same name with different signatures
        static void WriteResult(string description, int result)
        {
            //formatting string using {} as placeholders. :F2 formats floating point number with 2 decimal places
            //Console.WriteLine("{0}: {1:F2}", description, result);
            //using string interpolation
            Console.WriteLine($"{description}: {result:F2}");
        }

    }
}
