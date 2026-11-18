FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0@sha256:bef136a371963aaa46ec97882845ef6f54dec15728bb4b128b1c2a400ffbc9b4
RUN apt-get update && apt-get upgrade -y && rm -rf /var/lib/apt/lists/*
WORKDIR /scip-dotnet
ADD . /scip-dotnet
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet pack ScipDotnet/ScipDotnet.csproj \
    && dotnet tool install --framework net10.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet \
    && dotnet nuget locals all --clear \
    && rm -rf /scip-dotnet
WORKDIR /app
