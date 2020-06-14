using LearningSystem.Module.UserProfile.Application.Commands.CreateUserProfile;
using LearningSystem.Module.UserProfile.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace LearningSystem.Module.UserProfile.Domain
{
    public interface IUserProfileRepository
    {
        Task<UserProfileData> GetUserProfile(Guid userAccountId);
        void CreateUserProfile(CreateUserProfileModel model);
    }
}
