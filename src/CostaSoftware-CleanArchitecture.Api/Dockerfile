#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CostaSoftware-CleanArchitecture.Api/CostaSoftware-CleanArchitecture.Api.csproj", "src/CostaSoftware-CleanArchitecture.Api/"]
RUN dotnet restore "src/CostaSoftware-CleanArchitecture.Api/CostaSoftware-CleanArchitecture.Api.csproj"
COPY . .
WORKDIR "/src/src/CostaSoftware-CleanArchitecture.Api"
RUN dotnet build "CostaSoftware-CleanArchitecture.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CostaSoftware-CleanArchitecture.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CostaSoftware-CleanArchitecture.Api.dll"]