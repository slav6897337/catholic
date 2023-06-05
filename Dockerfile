FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build

WORKDIR /app
COPY . ./
RUN dotnet publish Catholic.Api -c Release -o out -r linux-x64 -p:PublishReadyToRun=true

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

RUN apt-get update && apt-get install -y libgdiplus

ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "Catholic.Api.dll"]
EXPOSE 5000
EXPOSE 80