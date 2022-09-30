#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CursoAspCore/CursoAspCore.csproj", "CursoAspCore/"]
RUN dotnet restore "CursoAspCore/CursoAspCore.csproj"
COPY . .
WORKDIR "/src/CursoAspCore"
RUN dotnet build "CursoAspCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CursoAspCore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CursoAspCore.dll"]