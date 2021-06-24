using LearningSystem.Module.Common.Infrastructure.Pagination;
using LearningSystem.Module.Common.Models;
using LearningSystem.Module.Data.DatabaseContexts;
using LearningSystem.Module.LearningPaths;
using LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Create;
using LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Create.Models;
using LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Delete;
using LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Update;
using LearningSystem.Module.LearningPaths.Application.Commands.Tutorials.Update.Models;
using LearningSystem.Module.LearningPaths.Application.Queries.GetPaginatedTutorials;
using LearningSystem.Module.LearningPaths.Application.Queries.GetTutorialById;
using LearningSystem.Module.LearningPaths.Domain;
using LearningSystem.Module.LearningPaths.Domain.Models;
using LearningSystem.Module.LearningPaths.Domain.Repositories;
using LearningSystem.Module.LearningPaths.Infrastructure;
using LearningSystem.Module.LearningPaths.Infrastructure.Repositories;
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
    public class TutorialsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TutorialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IPaginatedDataResponse<TutorialDomainModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginated(PaginatedDataQuery paginatedDataQuery)
        {
            return Ok(await _mediator.Send(new GetPaginatedTutorialsQuery(paginatedDataQuery)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(TutorialDomainModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetTutorialByIdQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(TutorialDomainModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateTutorialRequestModel model)
        {
            TutorialDomainModel newEntity = await _mediator.Send(new CreateTutorialCommand(model));
            var routeValue = new
            {
            id = newEntity.Id
            }

            ;
            return CreatedAtAction(nameof(GetById), routeValue, newEntity);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(TutorialDomainModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, UpdateTutorialRequestModel model)
        {
            return Ok(await _mediator.Send(new UpdateTutorialCommand(id, model)));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTutorialCommand(id));
            return NoContent();
        }
    }
}