using LearningSystem.Module.LearningPaths.Application.Commands.CreateLearningPath;
using LearningSystem.Module.LearningPaths.Application.Queries.GetLearningPath;
using LearningSystem.Module.LearningPaths.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace LearningSystem.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class LearningPathsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LearningPathsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateLearningPathResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateLearningPathRequestModel model)
        {
            CreateLearningPathResponseModel newEntity = await _mediator.Send(new CreateLearningPathCommand(model));
            return CreatedAtAction(nameof(Get), new { id = newEntity.Id }, newEntity);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LearningPathDomainModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            LearningPathDomainModel learningPath = await _mediator.Send(new GetLearningPathByIdQuery(id));

            if (learningPath == null)
            {
                return NotFound();
            }

            return Ok(learningPath);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<LearningPathDomainModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllLearningPathsQuery()));
        }
    }
}
