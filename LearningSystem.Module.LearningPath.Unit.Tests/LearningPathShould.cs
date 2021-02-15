using Shouldly;
using System;
using Xunit;

namespace LearningSystem.Module.LearningPath.Unit.Tests
{
    public class LearningPathShould
    {
        [Fact]
        public void Have_Something_When_Someting()
        {
            var learnignPath = new LearningPathMapper();
            learnignPath.ShouldNotBeNull();
        }
    }
}
