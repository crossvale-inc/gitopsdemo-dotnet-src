FROM mcr.microsoft.com/dotnet/sdk:latest AS build-env
WORKDIR /app

COPY *.csproj ./

RUN dotnet restore
# copy everything else and build

COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/sdk:latest

WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "run"]
