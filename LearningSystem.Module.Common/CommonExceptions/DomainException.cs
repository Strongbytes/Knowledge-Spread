using System;

namespace LearningSystem.Module.Common.CommonExceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
