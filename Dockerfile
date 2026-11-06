FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0@sha256:212fe4cb74627d5adf9817a4088906ae3edff1bd853bb27565d4b46731efe61e
RUN apt-get update && apt-get upgrade -y && rm -rf /var/lib/apt/lists/*
WORKDIR /scip-dotnet
ADD . /scip-dotnet
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet pack ScipDotnet/ScipDotnet.csproj \
    && dotnet tool install --framework net10.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet \
    && dotnet nuget locals all --clear \
    && rm -rf /scip-dotnet
WORKDIR /app
