using System;

namespace LearningSystem.Module.Common
{
    public class DomainException : Exception
    {
        public DomainException(string message): base(message)
        {

        }
    }
}
