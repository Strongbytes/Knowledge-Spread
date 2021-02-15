using LearningSystem.Module.Common.CommonExceptions;

namespace LearningSystem.Module.LearningPath.Domain.Exceptions
{
    public class LearningPathNotFoundException : DomainException
    {
        public LearningPathNotFoundException(string businessMessage) : base(businessMessage)
        {
        }
    }
}
