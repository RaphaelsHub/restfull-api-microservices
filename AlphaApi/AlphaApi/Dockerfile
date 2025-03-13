# Используем .NET 9.0 ASP.NET как базовый образ для контейнера
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
#Внутренний порт приложения
EXPOSE 8080

# Используем .NET 9.0 SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# Устанавливаем рабочую директорию для сборки
WORKDIR /src
# Копируем файл проекта в контейнер
COPY ["AlphaApi/AlphaApi.csproj", "AlphaApi/"]
# Восстанавливаем зависимости проекта
RUN dotnet restore "AlphaApi/AlphaApi.csproj"
# Копируем все остальные файлы в контейнер
COPY . .
# Собираем проект
WORKDIR "/src/AlphaApi"
RUN dotnet build "AlphaApi.csproj" -c Release -o /app/build

# Публикуем приложение
FROM build AS publish
RUN dotnet publish "AlphaApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Финальный образ, используемый для запуска приложения
FROM base AS final
# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app
# Копируем опубликованные файлы в финальный контейнер
COPY --from=publish /app/publish .
# Запускаем приложение при старте контейнера
ENTRYPOINT ["dotnet", "AlphaApi.dll"]
