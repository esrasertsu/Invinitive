FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Invinitive.Api/Invinitive.Api.csproj", "Invinitive.Api/"]
COPY ["src/Invinitive.Application/Invinitive.Application.csproj", "Invinitive.Application/"]
COPY ["src/Invinitive.Domain/Invinitive.Domain.csproj", "Invinitive.Domain/"]
COPY ["src/Invinitive.Contracts/Invinitive.Contracts.csproj", "Invinitive.Contracts/"]
COPY ["src/Invinitive.Infrastructure/Invinitive.Infrastructure.csproj", "Invinitive.Infrastructure/"]
COPY ["Directory.Packages.props", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "Invinitive.Api/Invinitive.Api.csproj"
COPY . ../
WORKDIR /src/Invinitive.Api
RUN dotnet build "Invinitive.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Invinitive.Api.dll"]