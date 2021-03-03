# Build image
#FROM microsoft/dotnet:2.0.3-sdk AS builder
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

#Copy the csproj file and restore any dependencies via nuget
COPY *.csproj  ./
RUN dotnet restore

#Copy the project files and build release

COPY . ./
RUN dotnet publish -c Release -o out

#Generrate runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:5.0
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet","DockerAPI.dll" ]

