FROM microsoft/dotnet:2.1-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-stretch AS build
WORKDIR /src
COPY ["AspCoreDocker/AspCoreDocker.csproj", "AspCoreDocker/"]
RUN dotnet restore "AspCoreDocker/AspCoreDocker.csproj"
COPY . .
WORKDIR "/src/AspCoreDocker"
RUN dotnet build "AspCoreDocker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AspCoreDocker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AspCoreDocker.dll"]