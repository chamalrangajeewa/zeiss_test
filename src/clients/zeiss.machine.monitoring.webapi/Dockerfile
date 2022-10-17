#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/clients/zeiss.machine.monitoring.webapi/zeiss.machine.monitoring.webapi.csproj", "src/clients/zeiss.machine.monitoring.webapi/"]
RUN dotnet restore "src/clients/zeiss.machine.monitoring.webapi/zeiss.machine.monitoring.webapi.csproj"
COPY . .
WORKDIR "/src/src/clients/zeiss.machine.monitoring.webapi"
RUN dotnet build "zeiss.machine.monitoring.webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "zeiss.machine.monitoring.webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "zeiss.machine.monitoring.webapi.dll"]