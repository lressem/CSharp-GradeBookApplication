﻿using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(String name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Standart;
        }

    }
}
