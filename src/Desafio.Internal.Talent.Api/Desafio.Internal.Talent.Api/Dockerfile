#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Desafio.Internal.Talent.Api/Desafio.Internal.Talent.Api.csproj", "Desafio.Internal.Talent.Api/"]
RUN dotnet restore "Desafio.Internal.Talent.Api/Desafio.Internal.Talent.Api.csproj"
COPY . .
WORKDIR "/src/Desafio.Internal.Talent.Api"
RUN dotnet build "Desafio.Internal.Talent.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Desafio.Internal.Talent.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio.Internal.Talent.Api.dll"]