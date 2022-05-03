#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BackgroundAPIRest/BackgroundAPIRest.csproj", "BackgroundAPIRest/"]
COPY ["Domain.Main/Domain.Main.csproj", "Domain.Main/"]
COPY ["CoreAccesLayer/CoreAccesLayer.csproj", "CoreAccesLayer/"]
COPY ["PlumbingProps/PlumbingProps.csproj", "PlumbingProps/"]
COPY ["Business.Main/Business.Main.csproj", "Business.Main/"]
RUN dotnet restore "BackgroundAPIRest/BackgroundAPIRest.csproj"
COPY . .
WORKDIR "/src/BackgroundAPIRest"
RUN dotnet build "BackgroundAPIRest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackgroundAPIRest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackgroundAPIRest.dll"]