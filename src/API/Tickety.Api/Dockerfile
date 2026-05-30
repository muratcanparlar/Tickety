# Use official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore
COPY . .
RUN dotnet restore "src/API/Tickety.Api/Tickety.Api.csproj"

# Publish the API project
WORKDIR /src/src/API/Tickety.Api
RUN dotnet publish -c Release -o /app/publish

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Expose port 80 for HTTP
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Tickety.Api.dll"]
