FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["BetaApi/BetaApi.csproj", "BetaApi/"]
RUN dotnet restore "BetaApi/BetaApi.csproj"
COPY . .

WORKDIR "/src/BetaApi"
RUN dotnet build "BetaApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BetaApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BetaApi.dll"]
