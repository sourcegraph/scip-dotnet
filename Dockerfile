FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:11.0@sha256:59d092a889fbad09c1a0b0c5dd072c6315125b0294a5cddfa48ec892f63b2ab3
RUN apt-get update && apt-get upgrade -y && rm -rf /var/lib/apt/lists/*
WORKDIR /scip-dotnet
ADD . /scip-dotnet
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet pack ScipDotnet/ScipDotnet.csproj \
    && dotnet tool install --framework net10.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet \
    && dotnet nuget locals all --clear \
    && rm -rf /scip-dotnet
WORKDIR /app
