using System.Threading.Tasks;
using LearningSystem.Module.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LearningSystem.Web.Filters
{
    public class BusinessExceptionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Do something before the action executes.

            // next() calls the action method.
            var resultContext = await next();

            HandleExceptions(resultContext);
            // Do something after the action executes.
        }

        private static void HandleExceptions(ActionExecutedContext resultContext)
        {
            switch (resultContext.Exception)
            {
                case ConcurrencyException _:
                {
                    var problemDetails = new ProblemDetails
                    {
                        Status = 409,
                        Title = "Conflict",
                        Detail = resultContext.Exception.Message,
                    };

                    resultContext.Result = new ConflictObjectResult(problemDetails);
                    resultContext.Exception = null;
                    resultContext.ExceptionHandled = true;
                    break;
                }
                case DomainException _:
                {
                    var problemDetails = new ProblemDetails
                    {
                        Status = 404,
                        Title = "Not Found",
                        Detail = resultContext.Exception.Message,
                    };

                    resultContext.Result = new NotFoundObjectResult(problemDetails);
                    resultContext.Exception = null;
                    resultContext.ExceptionHandled = true;

                    break;
                }
            }
        }
    }
}
