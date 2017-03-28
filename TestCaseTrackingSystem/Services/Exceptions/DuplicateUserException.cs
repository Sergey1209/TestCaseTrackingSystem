using System;

namespace Services.Exceptions
{
    public class DuplicateUserException : Exception
    {
        public DuplicateUserException():base("Duplicate user") { }
    }
}