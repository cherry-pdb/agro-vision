FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5123
EXPOSE 5124

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AgroVision.Server/AgroVision.Server.csproj", "AgroVision.Server/"]
RUN dotnet restore "AgroVision.Server/AgroVision.Server.csproj"
COPY . .
WORKDIR "/src/AgroVision.Server"
RUN dotnet build "AgroVision.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AgroVision.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgroVision.Server.dll"]
