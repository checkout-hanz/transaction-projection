# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Transaction.Projection/*.csproj ./Transaction.Projection/
RUN dotnet restore

# copy everything else and build app
COPY Transaction.Projection/. ./Transaction.Projection/
WORKDIR /source/Transaction.Projection
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Transaction.Projection.dll"]