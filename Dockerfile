FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:032381bcea86fa0a408af5df63a930f1ff5b03116c940a7cd744d3b648e66749
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --framework net8.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet