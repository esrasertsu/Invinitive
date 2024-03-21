using ErrorOr;
using Invinitive.Application.Common.Security.Request;
using Invinitive.Infrastructure.Security.CurrentUserProvider;

namespace Invinitive.Infrastructure.Security.PolicyEnforcer;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IAuthorizeableRequest<T> request,
        CurrentUser currentUser,
        string policy);
}