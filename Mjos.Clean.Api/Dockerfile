FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Mjos.Clean.Api/Mjos.Clean.Api.csproj", "Mjos.Clean.Api/"]
COPY ["Mjos.Clean.Application/Mjos.Clean.Application.csproj", "Mjos.Clean.Application/"]
COPY ["Mjos.Clean.Domain/Mjos.Clean.Domain.csproj", "Mjos.Clean.Domain/"]
COPY ["Mjos.Clean.Shared/Mjos.Clean.Shared.csproj", "Mjos.Clean.Shared/"]
COPY ["Mjos.Clean.Infrastructure/Mjos.Clean.Infrastructure.csproj", "Mjos.Clean.Infrastructure/"]
COPY ["Mjos.Clean.Persistence/Mjos.Clean.Persistence.csproj", "Mjos.Clean.Persistence/"]
RUN dotnet restore "./Mjos.Clean.Api/Mjos.Clean.Api.csproj"

# Copy all source code
COPY . .

# Copy SeedData files explicitly to a dedicated location in the image
COPY ["Mjos.Clean.Persistence/Contexts/SeedData", "/app/SeedData"]

WORKDIR "/src/Mjos.Clean.Api"
RUN dotnet build "./Mjos.Clean.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Mjos.Clean.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app

# Copy the HTTPS certificate files into the container
COPY Mjos.Clean.Api/certs ./certs

# Copy the published app
COPY --from=publish /app/publish .

# Ensure SeedData is included in the final image
COPY --from=build /app/SeedData ./SeedData

# Set environment variables for the certificate paths
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/certs/https.crt
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/certs/https.key

ENTRYPOINT ["dotnet", "Mjos.Clean.Api.dll"]
