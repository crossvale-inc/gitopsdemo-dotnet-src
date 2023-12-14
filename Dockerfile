FROM registry.redhat.io/rhel8/dotnet-70:latest AS build-env

USER 0

WORKDIR /opt/app-root

COPY DemoWeb1/*.csproj ./

RUN dotnet restore

RUN chown -R 1001:0 /opt/app-root && fix-permissions /opt/app-root

# build runtime image
FROM mcr.microsoft.com/dotnet/sdk:latest

WORKDIR /opt/app-root

COPY --from=build-env /opt/app-root /opt/app-root

RUN chown -R 1001:0 /opt/app-root && /usr/bin/fix-permissions /opt/app-root

# Run container by default as user with id 1001 (default)
USER 1001

ENTRYPOINT ["dotnet", "run"]
