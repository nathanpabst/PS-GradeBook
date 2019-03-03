﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        //constructor
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();

        }

        public GradeStatistics ComputeStatistics()
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

        public void WriteGrades(TextWriter destination)
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
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        //changing field to property with validation logic for the setter to protect the internal state
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                _name = value;

            }
        }

        private string _name;

        public event NameChangedDelegate NameChanged;

        //field to store a list of grades
        protected List<float> grades;
    }
}
