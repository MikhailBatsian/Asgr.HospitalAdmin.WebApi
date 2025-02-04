FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Asgr.HospitalAdmin.WebApi/Asgr.HospitalAdmin.WebApi.csproj", "Asgr.HospitalAdmin.WebApi/"]
RUN dotnet restore "Asgr.HospitalAdmin.WebApi/Asgr.HospitalAdmin.WebApi.csproj"
COPY . .
WORKDIR "/src/Asgr.HospitalAdmin.WebApi"
RUN dotnet build "Asgr.HospitalAdmin.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asgr.HospitalAdmin.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Asgr.HospitalAdmin.WebApi.dll"]
