FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ./PL.Web .
RUN dotnet restore "PL.Web.csproj"
RUN dotnet build "PL.Web.csproj" -c Release
RUN dotnet publish "PL.Web.csproj" -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS publish
WORKDIR /app
COPY --from=build /app .

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "PL.Web.dll"]
