FROM registry.redhat.io/rhel8/dotnet-70:latest AS build-env

USER 0

COPY DemoWeb1/*.csproj ./

COPY DemoWeb1 ./

RUN /usr/libexec/s2i/assemble

RUN chown -R 1001:0 /opt/app-root && fix-permissions /opt/app-root

USER 1001

# build runtime image
FROM registry.redhat.io/rhel8/dotnet-70:latest

USER 0

COPY --from=build-env /opt/app-root /opt/app-root

RUN chown -R 1001:0 /opt/app-root && fix-permissions /opt/app-root

# Run container by default as user with id 1001 (default)
USER 1001

ENTRYPOINT ["/usr/libexec/s2i/run"]
 
