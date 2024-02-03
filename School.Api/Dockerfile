#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["School.Api/School.Api.csproj", "School.Api/"]
COPY ["School.Infastructure/School.Infastructure.csproj", "School.Infastructure/"]
COPY ["School.Application/School.Application.csproj", "School.Application/"]
COPY ["School.Domain/School.Domain.csproj", "School.Domain/"]
RUN dotnet restore "./School.Api/./School.Api.csproj"
COPY . .
WORKDIR "/src/School.Api"
RUN dotnet build "./School.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./School.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "School.Api.dll"]