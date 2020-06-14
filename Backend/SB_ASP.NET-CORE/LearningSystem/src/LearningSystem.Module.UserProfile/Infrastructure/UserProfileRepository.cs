using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningSystem.Module.UserProfile.Application.Commands.CreateUserProfile;
using LearningSystem.Module.UserProfile.Domain;
using LearningSystem.Module.UserProfile.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Module.UserProfile.Infrastructure
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly UserProfileDbContext _dbContext;

        public UserProfileRepository(UserProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUserProfile(CreateUserProfileModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfileData> GetUserProfile(Guid userAccountId)
        {
            return await _dbContext.UserProfileData.FirstAsync(x => x.Id == userAccountId);
        }
    }
}
