using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyMunch.Business.Exceptions
{
    public class DuplicateDisplayNameException : Exception
    {
        public DuplicateDisplayNameException(string displayName)
            : base($"The name {displayName} is already registered.")
        {

        }
    }
}
