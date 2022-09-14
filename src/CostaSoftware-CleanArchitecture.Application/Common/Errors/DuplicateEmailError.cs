using FluentResults;

namespace CostaSoftware_CleanArchitecture.Application.Common.Errors;

[Obsolete]
public class DuplicateEmailError : IError
{
    public List<FluentResults.IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
