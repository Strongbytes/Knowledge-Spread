using AutoMapper;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create
{
    internal class CreateLearningPathCommandHandler : IRequestHandler<CreateLearningPathCommand, LearningPathDomainModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateLearningPathCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LearningPathDomainModel> Handle(CreateLearningPathCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}