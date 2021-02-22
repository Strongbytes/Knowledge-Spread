using AutoMapper;
using LearningSystem.Module.Data.Models;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using LearningSystem.Module.LearningPaths.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create
{
    internal class CreateLearningPathCommandHandler : IRequestHandler<CreateLearningPathCommand, LearningPathDomainModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IThirdPartyService _thirdPartyService;

        public CreateLearningPathCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IThirdPartyService thirdPartyService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _thirdPartyService = thirdPartyService;
        }

        public async Task<LearningPathDomainModel> Handle(CreateLearningPathCommand request, CancellationToken cancellationToken)
        {
            LearningPath newLearningPath = _mapper.Map<LearningPath>(request.Model);
            _unitOfWork.LearningPaths.Add(newLearningPath);

            // Call third party service to retrieve authorize token and do something with it
            await _thirdPartyService.RetrieveAuthorizeToken();

            await _unitOfWork.Complete();

            return _mapper.Map<LearningPathDomainModel>(newLearningPath);
        }
    }
}