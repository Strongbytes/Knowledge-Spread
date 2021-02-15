using LearningSystem.Module.Common.CommonExceptions;
using System;
using System.Runtime.Serialization;

namespace LearningSystem.Module.LearningPaths.Domain.Exceptions
{
    [Serializable]
    public class LearningPathNotFoundException : DomainException
    {
        protected LearningPathNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public LearningPathNotFoundException(string message) : base(message)
        {
        }
    }
}
