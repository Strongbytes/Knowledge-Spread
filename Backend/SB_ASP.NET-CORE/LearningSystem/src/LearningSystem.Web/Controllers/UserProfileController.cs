using LearningSystem.Module.UserProfile.Application.Queries.GetUserProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LearningSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly ILogger<UserProfileController> _logger;
        private readonly IMediator _mediator;

        public UserProfileController(ILogger<UserProfileController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<UserProfileModel> Get(Guid accountId)
        {
            return await _mediator.Send(new GetUserProfileQuery(accountId));
        }
    }
}
