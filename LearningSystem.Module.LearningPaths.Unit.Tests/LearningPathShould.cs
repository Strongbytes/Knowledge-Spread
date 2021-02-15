using LearningSystem.Module.LearningPaths;
using Shouldly;
using Xunit;

namespace LearningSystem.Module.LearningPath.Unit.Tests
{
    public class LearningPathShould
    {
        [Fact]
        public void Have_Something_When_Someting()
        {
            var learnignPath = new LearningPathsMapper();
            learnignPath.ShouldNotBeNull();
        }
    }
}
