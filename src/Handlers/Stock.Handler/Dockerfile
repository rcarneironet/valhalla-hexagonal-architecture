#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Handlers/Stock.Handler/Stock.Handler.csproj", "src/Handlers/Stock.Handler/"]
RUN dotnet restore "src/Handlers/Stock.Handler/Stock.Handler.csproj"
COPY . .
WORKDIR "/src/src/Handlers/Stock.Handler"
RUN dotnet build "Stock.Handler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stock.Handler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stock.Handler.dll"]