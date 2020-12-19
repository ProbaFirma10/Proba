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

RUN npm install react-toastify
RUN npm install react-transition-group
RUN npm install  regenerator-runtime
RUN npm install  react-stepper-horizontal
RUN npm install  react-datepicker
RUN npm install  react-is
RUN npm install  prop-types
RUN npm install  object-assign
RUN npm install  loose-envify
RUN npm install  js-tokens
RUN npm install  follow-redirects
RUN npm install  dom-helpers
RUN npm install  csstype
RUN npm install  clsx
RUN npm install  axios

RUN dotnet build "PatientWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientWebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientWebApplication.dll"]
