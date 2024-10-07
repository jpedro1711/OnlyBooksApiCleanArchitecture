FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y telnet

WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OnlyBooksApi.Application/OnlyBooksApi.Application.csproj", "OnlyBooksApi.Application/"]
COPY ["OnlyBooksApi.Core/OnlyBooksApi.Core.csproj", "OnlyBooksApi.Core/"]
COPY ["OnlyBooksApi.Infrastructure/OnlyBooksApi.Infrastructure.csproj", "OnlyBooksApi.Infrastructure/"]
COPY ["OnlyBooksApi.Web/OnlyBooksApi.Web.csproj", "OnlyBooksApi.Web/"]
RUN dotnet restore "OnlyBooksApi.Web/OnlyBooksApi.Web.csproj"
COPY . .
RUN dotnet build "OnlyBooksApi.Web/OnlyBooksApi.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlyBooksApi.Web/OnlyBooksApi.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlyBooksApi.Web.dll"]