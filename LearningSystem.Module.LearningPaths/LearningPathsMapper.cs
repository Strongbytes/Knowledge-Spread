using AutoMapper;
using LearningSystem.Module.Data.Models;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create.Models;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models;
using LearningSystem.Module.LearningPaths.Domain.Models;

namespace LearningSystem.Module.LearningPaths
{
    public class LearningPathsMapper : Profile
    {
        public LearningPathsMapper()
        {
            CreateMap<LearningPath, LearningPathDomainModel>();

            CreateMap<Tutorial, TutorialDomainModel>();

            CreateMap<CreateLearningPathRequestModel, LearningPath>();

            CreateMap<UpdateLearningPathRequestModel, LearningPath>();
        }
    }
}
