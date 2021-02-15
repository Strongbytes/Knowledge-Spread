using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Module.UserProfile.Domain;
using MediatR;

namespace LearningSystem.Module.UserProfile.Application.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileModel>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetUserProfileQueryHandler(IUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserProfileModel> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var profile = await _repository.GetUserProfile(request.AccountId);
            return _mapper.Map<UserProfileModel>(profile);
        }
    }
}