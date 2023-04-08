using System;

namespace Utility.Exceptions
{
    public class ApplicationValidationExpection : Exception
    {
        public ApplicationValidationExpection(string message) : base (message)
        {
                
        }
    }
}