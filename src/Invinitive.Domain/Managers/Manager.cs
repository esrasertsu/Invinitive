namespace Invinitive.Domain.Managers;

public class Manager
{
    public int Id { get; private set; }
    public string? Name { get; private set; }
    public int? ReportsTo { get; private set; }
    public Manager? ReportsToManager { get; private set; }

    public Manager(string? name, int? reportsTo)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        ReportsTo = reportsTo;
    }

    private Manager() { } // Private constructor for Entity Framework Core
}