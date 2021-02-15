using FluentValidation;
using LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create.Models;

namespace LearningSystem.Module.LearningPaths.Application.Commands.LearningPaths.Create.Validators
{
    public class CreateLearningModelValidator : AbstractValidator<CreateLearningPathRequestModel>
    {
        public CreateLearningModelValidator()
        {
            RuleFor(x => x.Platform).MinimumLength(5).MaximumLength(99);
        }
    }
}