FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build
WORKDIR /src
COPY ["Catalog/Catalog.csproj", "Catalog/"]
RUN dotnet restore "Catalog/Catalog.csproj"
COPY . .
WORKDIR "/src/Catalog"
RUN dotnet publish "Catalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Catalog.dll"]