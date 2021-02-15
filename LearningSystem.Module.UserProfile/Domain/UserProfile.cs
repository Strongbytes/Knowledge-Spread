using LearningSystem.Module.Common;
using System;

namespace LearningSystem.Module.UserProfile.Domain
{
    public class UserProfile: DomainEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public void TrackChangeByUser(string user, DateTime changeDate)
        {
            UpdatedBy = user;
            UpdatedDate = changeDate;
        }
    }
}
