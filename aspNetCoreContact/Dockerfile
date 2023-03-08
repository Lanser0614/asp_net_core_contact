FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["aspNetCoreContact/aspNetCoreContact.csproj", "aspNetCoreContact/"]
RUN dotnet restore "aspNetCoreContact/aspNetCoreContact.csproj"
COPY . .
WORKDIR "/src/aspNetCoreContact"
RUN dotnet build "aspNetCoreContact.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspNetCoreContact.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aspNetCoreContact.dll"]
