using FluentValidation;

namespace LearningSystem.Module.LearningPath.Application.Commands.CreateLearningPath
{
    public class CreateLearningModelValidator : AbstractValidator<CreateLearningPathModel>
    {
        public CreateLearningModelValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}