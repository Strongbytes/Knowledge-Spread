using FluentValidation;

namespace LearningSystem.Module.UserProfile.Application.Commands.CreateUserProfile
{
    public class CreateUserProfileModelValidator : AbstractValidator<CreateUserProfileModel>
    {
        public CreateUserProfileModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
        }
    }
}