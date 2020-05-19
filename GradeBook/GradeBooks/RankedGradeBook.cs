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
            if(averageGrade >= grades[(int)Math.Ceiling(grades.Count * .2) - 1])
            {
                return 'A';
            }
            else if (averageGrade >= grades[(int)Math.Ceiling(grades.Count * .4) - 1])
            {
                return 'B';
            }
            else if (averageGrade >= grades[(int)Math.Ceiling(grades.Count * .6) - 1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[(int)Math.Ceiling(grades.Count * .8) - 1])
            {
                return 'D';
            }
            return 'F';
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
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
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
