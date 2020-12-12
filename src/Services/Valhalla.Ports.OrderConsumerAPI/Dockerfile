#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8002
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Services/Valhalla.Ports.OrderConsumerAPI/Valhalla.Ports.OrderConsumerAPI.csproj", "src/Services/Valhalla.Ports.OrderConsumerAPI/"]
RUN dotnet restore "src/Services/Valhalla.Ports.OrderConsumerAPI/Valhalla.Ports.OrderConsumerAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/Valhalla.Ports.OrderConsumerAPI"
RUN dotnet build "Valhalla.Ports.OrderConsumerAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Valhalla.Ports.OrderConsumerAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Valhalla.Ports.OrderConsumerAPI.dll"]