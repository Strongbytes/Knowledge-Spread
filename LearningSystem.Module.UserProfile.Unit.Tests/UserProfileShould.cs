using Shouldly;
using System;
using Xunit;

namespace LearningSystem.Module.UserProfile.Unit.Tests
{
    public class UserProfileShould
    {
        [Fact]
        public void Have_Something_When_Someting()
        {
            var learnignPath = new UserProfileMapper();
            learnignPath.ShouldNotBeNull();
        }
    }
}
