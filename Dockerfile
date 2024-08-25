# Base image for the final runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Image for building the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY ["Server/Bard.Server.csproj", "Server/"]
COPY ["Client/Bard.Client.csproj", "Client/"]
COPY ["Shared/Bard.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/Bard.Server.csproj"

# Copy the remaining source files
COPY . .

# Build the app
WORKDIR "/src/Server"
RUN dotnet build "Bard.Server.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "Bard.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image with the published app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bard.Server.dll"]
