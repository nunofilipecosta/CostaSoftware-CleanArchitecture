using FluentValidation;

namespace CostaSoftware_CleanArchitecture.Application.Authentication.Queries.Login;
public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
	public LoginQueryValidator()
	{
		RuleFor(q => q.Email).NotEmpty();
		RuleFor(q => q.Password).NotEmpty();
	}
}
