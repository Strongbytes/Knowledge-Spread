
using LearningSystem.Module.Common;

namespace LearningSystem.Module.UserProfile.Domain.Exceptions
{
    public class UserProfileNotFoundException : DomainException
    {
        public UserProfileNotFoundException(string message = "Claim is not binned to a repair diagnosis.") : base(message)
        {
        }
    }
}