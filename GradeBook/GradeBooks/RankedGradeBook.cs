using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
        public override char GetLetterGrade(double averageGrade)
        {
            List<double> oceny = new List<double>();
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            foreach (Student stu in Students)
            {
                oceny.Add(stu.AverageGrade);
            }
            oceny.Sort();
            oceny.Reverse();
            foreach (Student stu in Students)
            {
                int procent = Convert.ToInt32((20.0 / 100.0) * Students.Count);
                for (int i = 0; i <= procent; i++)
                {
                    if (averageGrade == oceny[i])
                    {
                        return 'A';
                    }
                    else if (averageGrade == oceny[(i + procent)])
                    {
                        return 'B';
                    }
                    else if (averageGrade == oceny[(i + procent + procent)])
                    {
                        return 'C';
                    }
                    else if (averageGrade == oceny[(i + procent + procent + procent)])
                    {
                        return 'D';
                    }
                    else
                    {
                        return 'F';
                    }
                }
            }

            return 'F';
        }
    }
}
