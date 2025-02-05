FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:20767713e03a4a0d1bcd09d8a8606e8b6cfb815ddf96e1a0cf2cc059b57d55c0
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --framework net8.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet