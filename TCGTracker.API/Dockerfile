#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TCGTracker.API/TCGTracker.API.csproj", "TCGTracker.API/"]
COPY ["TCGTracker.API.DAL/TCGTracker.API.DAL.csproj", "TCGTracker.API.DAL/"]
COPY ["TCGTracker.API.Entities/TCGTracker.API.Entities.csproj", "TCGTracker.API.Entities/"]
RUN dotnet restore "TCGTracker.API/TCGTracker.API.csproj"
COPY . .
WORKDIR "/src/TCGTracker.API"
RUN dotnet build "TCGTracker.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCGTracker.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCGTracker.API.dll"]