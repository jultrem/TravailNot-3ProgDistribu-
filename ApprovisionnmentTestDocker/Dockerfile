# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ApprovisionnmentTestDocker/*.csproj ./ApprovisionnmentTestDocker/
RUN dotnet restore

# copy everything else and build app
COPY . ./ApprovisionnmentTestDocker/
WORKDIR /source/ApprovisionnmentTestDocker
RUN dotnet publish -c release -o /app --no-cache

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ApprovisionnmentTestDocker.dll", "--urls", "http://+:8502"]