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
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var threshold = Students.Count / 5;
            var gradesHigherThanCurrent = 0;

            foreach(var grade in Students)
            {
                if(averageGrade < grade.AverageGrade)
                {
                    gradesHigherThanCurrent++;
                }
            }

            if(gradesHigherThanCurrent/threshold < 1)
            {
                return 'A';
            }

            else if (gradesHigherThanCurrent / threshold < 2)
            {
                return 'B';
            }

            else if (gradesHigherThanCurrent / threshold < 3)
            {
                return 'C';
            }

            else if (gradesHigherThanCurrent / threshold < 4)
            {
                return 'D';
            }

            else
            return 'F';
        }
    }
}
