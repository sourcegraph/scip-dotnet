FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:3189e564f19e016a43838a46609fc81349f07322fdf6bc3299bd13f0dca9e647
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --framework net8.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet