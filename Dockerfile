FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:11.0@sha256:2794448a07118a6eaf00f29ab5d2bf44928517ce5ff86505a63a69230374f599
RUN apt-get update && apt-get upgrade -y && rm -rf /var/lib/apt/lists/*
WORKDIR /scip-dotnet
ADD . /scip-dotnet
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet pack ScipDotnet/ScipDotnet.csproj \
    && dotnet tool install --framework net10.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet \
    && dotnet nuget locals all --clear \
    && rm -rf /scip-dotnet
WORKDIR /app
