using System.Collections.Generic;

namespace LearningSystem.Module.UserProfile.Application.Commands.CreateUserProfile
{
    public class CreateUserProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }
    }
}