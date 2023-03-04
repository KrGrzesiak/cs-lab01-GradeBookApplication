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
            
            if (N <= 20) { return 'A'; }
            else if ( (N % numberOfStudents) > 20 && N <= 40) { return 'B'; }
            else if ( (N % numberOfStudents) > 40 && N <= 60) { return 'C'; }
            else if ( (N % numberOfStudents) > 60 && N <= 80) { return 'D'; }
            else { return 'F'; }
        }

    }
}
