FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore "Asgr.HospitalAdmin.DataSeedService/Asgr.HospitalAdmin.DataSeedService.csproj"
RUN dotnet publish "Asgr.HospitalAdmin.DataSeedService/Asgr.HospitalAdmin.DataSeedService.csproj" -c Release -o /out
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime
WORKDIR /app

COPY --from=build /out .

ENTRYPOINT ["dotnet", "Asgr.HospitalAdmin.DataSeedService.dll"]
