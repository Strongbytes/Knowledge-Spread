#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LearningSystem/LearningSystem.csproj", "LearningSystem/"]
RUN dotnet restore "LearningSystem/LearningSystem.csproj"
COPY . .
WORKDIR "/src/LearningSystem"
RUN dotnet build "LearningSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningSystem.dll"]