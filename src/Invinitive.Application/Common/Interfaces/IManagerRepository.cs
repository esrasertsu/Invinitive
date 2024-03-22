using Invinitive.Domain.Managers;

namespace Invinitive.Application.Common.Interfaces;

public interface IManagerRepository
{
    Task AddAsync(Manager manager, CancellationToken cancellationToken);
    Task<Manager?> GetByNameAsync(string name, CancellationToken cancellationToken);
}