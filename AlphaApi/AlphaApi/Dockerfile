# Используем официальный образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Копируем файлы проекта и восстанавливаем зависимости
COPY AlphaApi.csproj .
RUN dotnet restore

# Копируем остальные файлы и собираем приложение
COPY . .
RUN dotnet publish -c Release -o out

# Используем официальный образ .NET Runtime для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Устанавливаем порт и команду запуска
EXPOSE 8080 
ENTRYPOINT ["dotnet", "AlphaApi.dll"]
