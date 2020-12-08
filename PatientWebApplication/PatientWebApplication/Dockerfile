FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
COPY . .
EXPOSE 80
VOLUME /app/sql
CMD ASPNETCORE_URLS=http://*:$PORT dotnet PatientWebApplication.dll