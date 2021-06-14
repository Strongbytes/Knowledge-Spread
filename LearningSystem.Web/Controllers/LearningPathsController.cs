using LearningSystem.Module.LearningPaths;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create.Models;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Delete;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Update.Models;
using LearningSystem.Module.LearningPaths.Application.Queries.GetAllLearningPaths;
using LearningSystem.Module.LearningPaths.Application.Queries.GetLearningPathById;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using LearningSystem.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace LearningSystem.Web.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class LearningPathsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LearningPathsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LearningPathDomainModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllLearningPathsQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(LearningPathDomainModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetLearningPathByIdQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(LearningPathDomainModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateLearningPathRequestModel model)
        {
            LearningPathDomainModel newEntity = await _mediator.Send(new CreateLearningPathCommand(model));
            var routeValue = new
            {
            id = newEntity.Id
            }

            ;
            return CreatedAtAction(nameof(GetById), routeValue, newEntity);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(LearningPathDomainModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, UpdateLearningPathRequestModel model)
        {
            return Ok(await _mediator.Send(new UpdateLearningPathCommand(id, model)));
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