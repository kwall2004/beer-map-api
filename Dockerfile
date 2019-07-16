FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY BeerMapApi.Core/*.csproj ./BeerMapApi.Core/
COPY BeerMapApi.Infrastructure/*.csproj ./BeerMapApi.Infrastructure/
COPY BeerMapApi/*.csproj ./BeerMapApi/

RUN dotnet restore
COPY . .

WORKDIR /src/BeerMapApi.Core
RUN dotnet build -c Release -o /app

WORKDIR /src/BeerMapApi.Infrastructure
RUN dotnet build -c Release -o /app

WORKDIR /src/BeerMapApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
# ENTRYPOINT ["dotnet", "BeerMapApi.dll"]
CMD dotnet BeerMapApi.dll --urls "http://*:$PORT"
