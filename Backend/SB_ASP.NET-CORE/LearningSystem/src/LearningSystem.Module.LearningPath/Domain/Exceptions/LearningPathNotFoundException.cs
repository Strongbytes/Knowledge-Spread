
using LearningSystem.Module.Common;

namespace LearningSystem.Module.LearningPath.Domain.Exceptions
{
    public class LearningPathNotFoundException : DomainException
    {
        public LearningPathNotFoundException(string businessMessage) : base(businessMessage)
        {
        }
    }
}
