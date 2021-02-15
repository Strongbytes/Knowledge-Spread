using AutoMapper;
using LearningSystem.Module.Data.Models;
using LearningSystem.Module.LearningPaths.Domain.Models;

namespace LearningSystem.Module.LearningPaths
{
    public class LearningPathsMapper : Profile
    {
        public LearningPathsMapper()
        {
            CreateMap<LearningPath, LearningPathDomainModel>()
                .IncludeAllDerived();

            CreateMap<Tutorial, TutorialDomainModel>()
                .IncludeAllDerived();
        }
    }
}
