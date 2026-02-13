FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PortfolioWebsite.csproj", "./"]
RUN dotnet restore "PortfolioWebsite.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "PortfolioWebsite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PortfolioWebsite.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PortfolioWebsite.dll"]
