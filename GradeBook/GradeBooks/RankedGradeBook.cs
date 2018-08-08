﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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

    }
}