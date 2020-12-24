#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
RUN curl -sL https://deb.nodesource.com/setup_12.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN curl -sL https://deb.nodesource.com/setup_12.x |  bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["PatientWebApplication/PatientWebApplication.csproj", "PatientWebApplication/"]
COPY ["HealthClinic.DAL/HealthClinic.CL.csproj", "HealthClinic.DAL/"]
RUN dotnet restore "PatientWebApplication/PatientWebApplication.csproj"
COPY . .
WORKDIR "/src/PatientWebApplication/"
COPY package.json ./
COPY package-lock.json ./

RUN npm install react-toastify \
    react-transition-group \
    regenerator-runtime \
    react-stepper-horizontal \
    react-datepicker \
    react-is \
    prop-types \
    object-assign \
    loose-envify \
    js-tokens \
    follow-redirects \
    dom-helpers \
    csstype \
    clsx \
    axios

RUN dotnet build "PatientWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientWebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientWebApplication.dll"]
