# Use ASP.NET runtime base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["SalesWebMvc/SalesWebMvc.csproj", "SalesWebMvc/"]
RUN dotnet restore "SalesWebMvc/SalesWebMvc.csproj"

# Copy the rest of the application code
COPY . .

# Set the working directory to the project directory
WORKDIR "/src/SalesWebMvc"

# List files for debugging (optional)
RUN ls -al

# Build the application
RUN dotnet build "SalesWebMvc.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "SalesWebMvc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalesWebMvc.dll"] 