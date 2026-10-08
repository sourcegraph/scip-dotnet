FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:11.0@sha256:d0a39ca4acefe992f26030f8fb8c60e1b14ac088822cb3fdfbe536ecf843a675
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --framework net10.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet
