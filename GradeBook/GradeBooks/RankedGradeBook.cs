using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int numberOfStudents = Students.Count;
            int N = 0;

            for (int i = 0; i < numberOfStudents; i++)
            {
                if ( Students[i].AverageGrade >= averageGrade) { N++; }
            }

            if (N < 5) { throw new InvalidOperationException(); }
            
            double procent = Convert.ToDouble(N) / Convert.ToDouble(numberOfStudents) * 100;

            if (procent <= 20) { return 'A'; }
            else if (procent > 20 && procent <= 40) { return 'B'; }
            else if (procent > 40 && procent <= 60) { return 'C'; }
            else if (procent > 60 && procent <= 80) { return 'D'; }
            else { return 'F'; }
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
    }
}
