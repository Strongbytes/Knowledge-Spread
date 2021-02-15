using LearningSystem.Module.LearningPaths.Application.Commands.CreateLearningPath;
using LearningSystem.Module.LearningPaths.Application.Queries.GetLearningPath;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LearningPathsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LearningPathsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<LearningPathDomainModel> Get(CreateLearningPathRequestModel model)
        {
            return await _mediator.Send(new CreateLearningPathCommand(model));
        }

        [HttpGet("{id}")]
        public async Task<LearningPathDomainModel> Get(int id)
        {
            return await _mediator.Send(new GetLearningPathByIdQuery(id));
        }

        [HttpGet]
        public async Task<IList<LearningPathDomainModel>> GetAll()
        {
            return await _mediator.Send(new GetAllLearningPathsQuery());
        }
    }
}
