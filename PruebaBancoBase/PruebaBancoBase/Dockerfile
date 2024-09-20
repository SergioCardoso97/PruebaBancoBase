#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PruebaBancoBase/PruebaBancoBase.csproj", "PruebaBancoBase/"]
COPY ["Negocio/Negocio.csproj", "Negocio/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Execute/Execute.csproj", "Execute/"]
COPY ["DAO-DTO/DAO-DTO.csproj", "DAO-DTO/"]
RUN dotnet restore "PruebaBancoBase/PruebaBancoBase.csproj"
COPY . .
WORKDIR "/src/PruebaBancoBase"
RUN dotnet build "PruebaBancoBase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaBancoBase.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaBancoBase.dll"]