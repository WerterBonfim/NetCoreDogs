FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim as base
WORKDIR /app
RUN mkdir teste-upload
EXPOSE 80


# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

# copy csproj and restore as distinct layers

COPY Werter.Dogs.WebApi/*.csproj ./Werter.Dogs.WebApi/
COPY Werter.Dogs.Servicos/*.csproj ./Werter.Dogs.Servicos/
COPY Werter.Dogs.Infra/*.csproj ./Werter.Dogs.Infra/
COPY Werter.Dogs.Dominio/*.csproj ./Werter.Dogs.Dominio/
COPY Werter.Dogs.Compartilhado/*.csproj ./Werter.Dogs.Compartilhado/


RUN dotnet restore "Werter.Dogs.WebApi/Werter.Dogs.WebApi.csproj"


# copy everything else and build app
COPY . .

WORKDIR /src/Werter.Dogs.WebApi
RUN dotnet build "Werter.Dogs.WebApi.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "Werter.Dogs.WebApi.csproj" -c Release -o /app/publish

# final stage/image
FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ls
ENTRYPOINT ["dotnet", "Werter.Dogs.WebApi.dll"]
##ENTRYPOINT [ "bash" ]
