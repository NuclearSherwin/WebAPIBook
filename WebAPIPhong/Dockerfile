FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebAPIPhong/WebAPIPhong.csproj", "WebAPIPhong/"]
RUN dotnet restore "WebAPIPhong/WebAPIPhong.csproj"
COPY . .
WORKDIR "/src/WebAPIPhong"
RUN dotnet build "WebAPIPhong.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPIPhong.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPIPhong.dll"]
