﻿FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RockPaperScissors.csproj", "./"]
RUN dotnet restore "RockPaperScissors.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RockPaperScissors.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RockPaperScissors.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RockPaperScissors.dll"]
