using Invinitive.Application.Common.Interfaces;
using Invinitive.Domain.Managers;
using Invinitive.Infrastructure.Common;

using Microsoft.EntityFrameworkCore;

namespace Invinitive.Infrastructure.Users.Persistence;

public class ManagerRepositoy(AppDbContext _dbContext) : IManagerRepository
{
    public async Task AddAsync(Manager manager, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(manager, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Manager?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.Managers.FirstOrDefaultAsync(m => m.Name == name, cancellationToken);
    }
}
