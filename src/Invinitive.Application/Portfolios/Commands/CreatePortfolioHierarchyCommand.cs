using ErrorOr;

using Invinitive.Application.Common.Security.Policies;
using Invinitive.Application.Common.Security.Request;
using Invinitive.Application.Portfolios.Responses;

namespace Invinitive.Application.Portfolios.Commands;

// [Authorize(Permissions = Common.Security.Permissions.Permission.Portfolios.Create, Policies = Policy.SelfOrAdmin)]
public record CreatePortfolioHierarchyCommand(Guid UserId, Dictionary<string, string> Hierarchy) : IAuthorizeableRequest<ErrorOr<CreatePortfolioHierarchyResponse>>;