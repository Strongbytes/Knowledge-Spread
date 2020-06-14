using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LearningSystem.Module.LearningPath.Application.Queries.GetLearningPath;
using System.Collections.Generic;

namespace LearningSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LearningPathController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LearningPathController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IList<LearningPathModel>> Get(Guid userId)
        {
            return await _mediator.Send(new GetLearningPathQuery(userId));
        }
    }
}
