using Invinitive.Domain.Managers;

namespace Invinitive.Domain.Portfolios;

public class Portfolio
{
    public int Id { get; private set; }
    public string? Name { get; private set; }
    public int? ManagerId { get; private set; }
    public Manager? Manager { get; private set; }

    public Portfolio(string? name, int managerId)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        ManagerId = managerId;
    }

    private Portfolio() { } // Private constructor for Entity Framework Core
}