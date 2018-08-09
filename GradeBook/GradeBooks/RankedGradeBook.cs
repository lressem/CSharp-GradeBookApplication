using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            //how many students to drop to next 20%
            var dropIndexOfGrade = (int)Math.Ceiling(Students.Count * 0.2);

            
            //creates a sorted list of grades in descending order using linq
            var sortedListOfGrades = Students.OrderByDescending(st => st.AverageGrade).Select(st => st.AverageGrade).ToList();

            char grade;

            if (sortedListOfGrades[dropIndexOfGrade - 1] <= averageGrade)
            {
                grade = 'A';
                return grade;
            }

            else if (sortedListOfGrades[dropIndexOfGrade * 2 - 1] <= averageGrade)
            {
                grade = 'B';
                return grade;
            }

            else if (sortedListOfGrades[dropIndexOfGrade * 3 - 1] <= averageGrade)
            {
                grade = 'C';
                return grade;
            }

            else if (sortedListOfGrades[dropIndexOfGrade * 4 - 1] <= averageGrade)
            {
                grade = 'D';
                return grade;
            }

            else return 'F';

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }

            else
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }

            else 
            base.CalculateStudentStatistics(name);
        }

    }
}
