FROM mcr.microsoft.com/dotnet/sdk:10.0@sha256:3f3cc2daa2358dea8a50d47153c87abc61d301b45606021535fd595cea0d0114
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --framework net10.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet
