using ErrorOr;
using Invinitive.Application.Common.Interfaces;
using Invinitive.Application.Portfolios.Commands;
using Invinitive.Application.Portfolios.Responses;
using Invinitive.Domain.Managers;
using Invinitive.Domain.Portfolios;
using MediatR;

public class CreatePortfolioHierarcyHandler : IRequestHandler<CreatePortfolioHierarchyCommand, ErrorOr<CreatePortfolioHierarchyResponse>>
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly IManagerRepository _managerRepository;

    public CreatePortfolioHierarcyHandler(IPortfolioRepository portfolioRepository, IManagerRepository managerRepository)
    {
        _portfolioRepository = portfolioRepository;
        _managerRepository = managerRepository;
    }

    public async Task<ErrorOr<CreatePortfolioHierarchyResponse>> Handle(CreatePortfolioHierarchyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Extract hierarchy from the request
            Dictionary<string, string> hierarchy = request.Hierarchy;

            // Validate hierarchy for loops and unrelated hierarchies
            ValidateHierarchy(hierarchy);

            // Save the hierarchy to the database
            await SaveHierarchyToDatabase(hierarchy, cancellationToken);

            // Construct hierarchy tree
            var hierarchyTree = ConstructHierarchyTree(hierarchy);

            return new CreatePortfolioHierarchyResponse(hierarchyTree);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to process portfolio hierarchy.", ex);
        }
    }

    private async Task SaveHierarchyToDatabase(Dictionary<string, string> hierarchy, CancellationToken cancellationToken)
    {
        foreach (var item in hierarchy)
        {
            var portfolioName = item.Key;
            var managerName = item.Value;

            // Find or create manager entity
            var manager = await _managerRepository.GetByNameAsync(managerName, cancellationToken);
            if (manager == null)
            {
                manager = new Manager(managerName);
                await _managerRepository.AddAsync(manager, cancellationToken);
            }

            // Find or create portfolio entity
            var portfolio = await _portfolioRepository.GetByNameAsync(portfolioName, cancellationToken);
            if (portfolio == null)
            {
                portfolio = new Portfolio(portfolioName, manager.Id);
                await _portfolioRepository.AddAsync(portfolio, cancellationToken);
            }
        }
    }

    private void ValidateHierarchy(Dictionary<string, string> hierarchy)
    {
        // Check for loops
        var visited = new HashSet<string>();
        foreach (var manager in hierarchy.Keys)
        {
            if (HasLoop(manager, hierarchy, visited, new HashSet<string>()))
            {
                throw new Exception($"Loop detected in hierarchy involving manager '{manager}'.");
            }
        }

        // Check for unrelated hierarchies
        var allManagers = hierarchy.Values.Distinct().ToHashSet();
        foreach (var manager in hierarchy.Keys)
        {
            var reportsToManager = hierarchy[manager];
            if (!allManagers.Contains(reportsToManager))
            {
                throw new Exception($"Unrelated hierarchy detected involving manager '{manager}'.");
            }
        }
    }

    private bool HasLoop(string currentManager, Dictionary<string, string> hierarchy, HashSet<string> visited, HashSet<string> path)
    {
        if (visited.Contains(currentManager))
        {
            return path.Contains(currentManager);
        }

        visited.Add(currentManager);
        path.Add(currentManager);

        if (hierarchy.TryGetValue(currentManager, out var reportsToManager))
        {
            if (HasLoop(reportsToManager, hierarchy, visited, path))
            {
                return true;
            }
        }

        path.Remove(currentManager);
        return false;
    }

    private Dictionary<string, object> ConstructHierarchyTree(Dictionary<string, string> hierarchy)
    {
        // Build hierarchy tree
        var hierarchyTree = new Dictionary<string, object>();

        // Group managers by their reports to
        var groupedManagers = hierarchy.GroupBy(kvp => kvp.Value, kvp => kvp.Key);

        // Find top-level managers (managers that don't report to anyone)
        var topLevelManagers = groupedManagers.Where(g => !hierarchy.ContainsKey(g.Key));

        // Construct hierarchy tree for each top-level manager
        foreach (var topLevelManager in topLevelManagers)
        {
            hierarchyTree[topLevelManager.Key] = BuildSubordinates(hierarchy, topLevelManager.Key);
        }

        return hierarchyTree;
    }

    private Dictionary<string, object> BuildSubordinates(Dictionary<string, string> hierarchy, string manager)
    {
        var subordinates = new Dictionary<string, object>();

        // Find subordinates for the given manager
        var managerSubordinates = hierarchy.Where(kvp => kvp.Value == manager);

        // Construct hierarchy tree for each subordinate
        foreach (var subordinate in managerSubordinates)
        {
            subordinates[subordinate.Key] = BuildSubordinates(hierarchy, subordinate.Key);
        }

        return subordinates;
    }
}
