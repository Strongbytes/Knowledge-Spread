using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create.Models;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Delete;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models;
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

        [HttpGet]
        [ProducesResponseType(typeof(List<LearningPathDomainModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllLearningPathsQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LearningPathDomainModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetLearningPathByIdQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(LearningPathDomainModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateLearningPathRequestModel model)
        {
            LearningPathDomainModel newEntity = await _mediator.Send(new CreateLearningPathCommand(model));
            return CreatedAtAction(nameof(Get), new { id = newEntity.Id }, newEntity);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LearningPathDomainModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateLearningPathRequestModel model)
        {
            LearningPathDomainModel newEntity = await _mediator.Send(new UpdateLearningPathCommand(id, model));
            return CreatedAtAction(nameof(Get), new { id = newEntity.Id }, newEntity);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLearningPathCommand(id));
            return NoContent();
        }
    }
}
