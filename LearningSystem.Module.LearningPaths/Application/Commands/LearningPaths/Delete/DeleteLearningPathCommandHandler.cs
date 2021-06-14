using AutoMapper;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Delete
{
    internal class DeleteLearningPathCommandHandler : IRequestHandler<DeleteLearningPathCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteLearningPathCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLearningPathCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}