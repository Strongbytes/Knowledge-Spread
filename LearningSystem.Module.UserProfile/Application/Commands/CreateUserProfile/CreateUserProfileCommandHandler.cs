using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LearningSystem.Module.UserProfile.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Module.UserProfile.Application.Commands.CreateUserProfile
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreateUserProfileResponse>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserProfileCommandHandler(IUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateUserProfileResponse> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateUserProfileResponse();
            _repository.CreateUserProfile(request.Model);
            return response;
        }
    }
}