using Invinitive.Infrastructure.Common.Middleware;

using Microsoft.AspNetCore.Builder;

namespace Invinitive.Infrastructure;

public static class RequestPipeline
{
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseMiddleware<EventualConsistencyMiddleware>();
        return app;
    }
}