FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["scip-dotnet/scip-dotnet.csproj", "scip-dotnet/"]
RUN dotnet restore "scip-dotnet/scip-dotnet.csproj"
COPY . .
WORKDIR "/src/scip-dotnet"
RUN dotnet build "scip-dotnet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "scip-dotnet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "scip-dotnet.dll"]
