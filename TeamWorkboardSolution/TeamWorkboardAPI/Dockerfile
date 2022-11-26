#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TeamWorkboardAPI/TeamWorkboardAPI.csproj", "TeamWorkboardAPI/"]
COPY ["TeamWorkboardApplication/TeamWorkboardApplication.csproj", "TeamWorkboardApplication/"]
COPY ["TeamWorkboardData/TeamWorkboardData.csproj", "TeamWorkboardData/"]
RUN dotnet restore "TeamWorkboardAPI/TeamWorkboardAPI.csproj"
COPY . .
WORKDIR "/src/TeamWorkboardAPI"
RUN dotnet build "TeamWorkboardAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamWorkboardAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamWorkboardAPI.dll"]