using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        //constructor
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();

        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
            //print in descending order
            //for (int i = grades.Count; i < 0; i--)
            //{
            //    destination.WriteLine(grades[i - 1]);
            //}
        }

        //method to add a grade
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        

        //protected access modifier allows the ThrowAwayGradeBook class access to this list of grades
        protected List<float> grades;
    }
}
