using LearningSystem.Module.LearningPath.Application.Queries.GetLearningPath;
using LearningSystem.Module.LearningPath.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Razor.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMediator _mediator;

        public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IList<TutorialDomainModel> LearningPathModels { get; set; }

        public async Task OnGetAsync()
        {
            LearningPathModels = await _mediator.Send(new GetLearningPathQuery(Guid.NewGuid()));
        }
    }
}
