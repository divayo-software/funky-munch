using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyMunch.Business.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string loginName)
            : base($"Invalid login for user {loginName}")
        {

        }
    }
}
