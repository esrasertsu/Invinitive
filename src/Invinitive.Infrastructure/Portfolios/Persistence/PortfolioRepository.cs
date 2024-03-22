using Invinitive.Application.Common.Interfaces;
using Invinitive.Domain.Portfolios;
using Invinitive.Infrastructure.Common;

namespace Invinitive.Infrastructure.Portfolios.Persistence;

public class PortfolioRepository(AppDbContext _dbContext) : IPortfolioRepository
{
    public async Task AddAsync(Portfolio portfolio, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(portfolio, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Portfolio?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.Portfolios.FindAsync(name, cancellationToken);
    }
}