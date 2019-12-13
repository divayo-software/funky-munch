using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyMunch.Business.Exceptions
{
    public class DuplicateEmailAddressException : Exception
    {
        public DuplicateEmailAddressException(string emailAddress)
            : base($"The email address {emailAddress} is already registered.")
        {

        }
    }
}
