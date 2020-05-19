using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if(averageGrade >= grades[(int)Math.Ceiling(grades.Count * .2)])
            {
                return 'A';
            }
            else if (averageGrade >= grades[(int)Math.Ceiling(grades.Count * .4)])
            {
                return 'B';
            }
            else if (averageGrade >= grades[(int)Math.Ceiling(grades.Count * .6)])
            {
                return 'C';
            }
            else if (averageGrade >= grades[(int)Math.Ceiling(grades.Count * .8)])
            {
                return 'D';
            }
            return 'F';
        }
    }
}
