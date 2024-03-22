using Invinitive.Domain.Portfolios;

namespace Invinitive.Application.Common.Interfaces;

public interface IPortfolioRepository
{
    Task AddAsync(Portfolio portfolio, CancellationToken cancellationToken);
    Task<Portfolio?> GetByNameAsync(string name, CancellationToken cancellationToken);
}