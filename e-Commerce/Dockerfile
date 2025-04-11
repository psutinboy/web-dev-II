# Use official ASP.NET Core runtime image as base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8085

# Use SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files
COPY ["eCommerce.Api/eCommerce.Api.csproj", "eCommerce.Api/"]
COPY ["eCommerce.Application/eCommerce.Application.csproj", "eCommerce.Application/"]
COPY ["eCommerce.Infrastructure/eCommerce.Infrastructure.csproj", "eCommerce.Infrastructure/"]
COPY ["eCommerce.Domain/eCommerce.Domain.csproj", "eCommerce.Domain/"]

# Restore dependencies
RUN dotnet restore "eCommerce.Api/eCommerce.Api.csproj"

# Copy the rest of the app files and build
COPY . .
WORKDIR "/src/eCommerce.Api"
RUN dotnet publish -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.Api.dll"]
