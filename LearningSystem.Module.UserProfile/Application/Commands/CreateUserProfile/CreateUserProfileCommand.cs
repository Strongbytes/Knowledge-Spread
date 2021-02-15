using System;
using MediatR;

namespace LearningSystem.Module.UserProfile.Application.Commands.CreateUserProfile
{
    public class CreateUserProfileCommand : IRequest<CreateUserProfileResponse>
    {
        public CreateUserProfileModel Model { get; }

        public CreateUserProfileCommand(CreateUserProfileModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}
