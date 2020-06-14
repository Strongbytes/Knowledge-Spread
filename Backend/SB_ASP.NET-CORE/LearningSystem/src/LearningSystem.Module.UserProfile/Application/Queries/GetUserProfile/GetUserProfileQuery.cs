using System;
using System.Collections.Generic;
using MediatR;
namespace LearningSystem.Module.UserProfile.Application.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<UserProfileModel>
    {
        public Guid AccountId { get; set; }

        public GetUserProfileQuery(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
