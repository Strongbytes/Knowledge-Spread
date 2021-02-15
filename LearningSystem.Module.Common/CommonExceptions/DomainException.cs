using System;
using System.Runtime.Serialization;

namespace LearningSystem.Module.Common.CommonExceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DomainException(string message) : base(message)
        {
        }
    }
}
