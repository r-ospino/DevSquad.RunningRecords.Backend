FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

EXPOSE 80
EXPOSE 443

COPY /api .

ENTRYPOINT ["dotnet", "DevSquad.RunningRecords.Backend.Api.dll"]
