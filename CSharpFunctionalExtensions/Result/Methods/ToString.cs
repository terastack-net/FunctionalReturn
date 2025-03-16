﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpFunctionalExtensions
{
    public partial struct Return
    {
        public override string ToString()
        {
            return IsSuccess ? "Success" : $"Failure({Error})";
        }
    }


    public partial struct Return<T>
    {
        public override string ToString()
        {
            return IsSuccess ? $"Success({Value})" : $"Failure({Error})";
        }
    }


    public partial struct Return<T, E>
    {
        public override string ToString()
        {
            return IsSuccess ? $"Success({Value})" : $"Failure({Error})";
        }
    }


    public partial struct UnitResult<E>
    {
        public override string ToString()
        {
            return IsSuccess ? "Success" : $"Failure({Error})";
        }
    }
}
