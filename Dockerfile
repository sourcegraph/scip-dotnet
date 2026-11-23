FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0@sha256:8c6edfb26c85153f236d26efebd9ad349aec403583f343f201ee67838b23658d
RUN apt-get update && apt-get upgrade -y && rm -rf /var/lib/apt/lists/*
WORKDIR /scip-dotnet
ADD . /scip-dotnet
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet pack ScipDotnet/ScipDotnet.csproj \
    && dotnet tool install --framework net10.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet \
    && dotnet nuget locals all --clear \
    && rm -rf /scip-dotnet
WORKDIR /app
