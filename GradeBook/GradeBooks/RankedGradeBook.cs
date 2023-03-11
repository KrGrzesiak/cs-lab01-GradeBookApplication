using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            double N = (Students.Count % 10) * 2;

            if (Students.Count < 5) { throw new InvalidOperationException(); }
            else
            {
                double higherThanAverageGrade = 0;

                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].AverageGrade > averageGrade) { higherThanAverageGrade++; }
                }

                if (higherThanAverageGrade <= N) { return 'A'; }
                else if (higherThanAverageGrade > N && higherThanAverageGrade <= N * 2) { return 'B'; }
                else if (higherThanAverageGrade > N * 2 && higherThanAverageGrade <= N * 3) { return 'C'; }
                else if (higherThanAverageGrade > N && higherThanAverageGrade <= N * 4) { return 'D'; }
                else { return 'F'; }
            }
            
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
