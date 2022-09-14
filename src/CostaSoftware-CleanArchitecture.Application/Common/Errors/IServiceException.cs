using System.Net;

namespace CostaSoftware_CleanArchitecture.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}

