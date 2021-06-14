using AutoMapper;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create.Models;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models;
using LearningSystem.Module.LearningPaths.Domain.Models;
using LearningSystem.Module.Data.Models;

namespace LearningSystem.Module.LearningPaths
{
    public class LearningPathsMapper : Profile
    {
        public LearningPathsMapper()
        {
            CreateMap<Tutorial, TutorialDomainModel>();
            CreateMap<LearningPath, LearningPathDomainModel>();
            CreateMap<CreateLearningPathRequestModel, LearningPath>();
            CreateMap<UpdateLearningPathRequestModel, LearningPath>();
        }
    }
}