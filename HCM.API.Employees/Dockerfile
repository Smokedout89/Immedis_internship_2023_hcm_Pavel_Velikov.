#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HCM.API.Employees/HCM.API.Employees.csproj", "HCM.API.Employees/"]
COPY ["HCM.Infrastructure/HCM.Infrastructure.csproj", "HCM.Infrastructure/"]
COPY ["HCM.Domain/HCM.Domain.csproj", "HCM.Domain/"]
COPY ["HCM.Domain.Abstractions/HCM.Domain.Abstractions.csproj", "HCM.Domain.Abstractions/"]
RUN dotnet restore "HCM.API.Employees/HCM.API.Employees.csproj"
COPY . .
WORKDIR "/src/HCM.API.Employees"
RUN dotnet build "HCM.API.Employees.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HCM.API.Employees.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HCM.API.Employees.dll"]