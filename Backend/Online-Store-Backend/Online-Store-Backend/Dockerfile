FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Online-Store-Backend/Online-Store-Backend.csproj", "Online-Store-Backend/"]
COPY ["Online-Store-Backend.Database/Online-Store-Backend.Database.csproj", "Online-Store-Backend.Database/"]
COPY ["Online-Store-Backend.Core/Online-Store-Backend.Core.csproj", "Online-Store-Backend.Core/"]
COPY ["Online-Store-Backend.Enums/Online-Store-Backend.Enums.csproj", "Online-Store-Backend.Enums/"]
COPY ["Online-Store-Backend.Domain/Online-Store-Backend.Domain.csproj", "Online-Store-Backend.Domain/"]
COPY ["Online-Store-Backend.Migrations/Online-Store-Backend.Migrations.csproj", "Online-Store-Backend.Migrations/"]
RUN dotnet restore "./Online-Store-Backend/Online-Store-Backend.csproj"
COPY . .
WORKDIR "/src/Online-Store-Backend.Migrations"
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR "/src/Online-Store-Backend"
RUN dotnet build "./Online-Store-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Online-Store-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Online-Store-Backend.dll"]