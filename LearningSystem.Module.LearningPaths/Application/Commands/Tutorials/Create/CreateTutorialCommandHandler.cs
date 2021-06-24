using AutoMapper;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Create
{
    internal class CreateTutorialCommandHandler : IRequestHandler<CreateTutorialCommand, TutorialDomainModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateTutorialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TutorialDomainModel> Handle(CreateTutorialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}