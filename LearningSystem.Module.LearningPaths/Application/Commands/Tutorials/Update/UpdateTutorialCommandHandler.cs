using AutoMapper;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Update
{
    internal class UpdateTutorialCommandHandler : IRequestHandler<UpdateTutorialCommand, TutorialDomainModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateTutorialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TutorialDomainModel> Handle(UpdateTutorialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}