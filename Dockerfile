FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:ae000be75dac94fc40e00f0eee903289e985995cc06dac3937469254ce5b60b6
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --framework net9.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet
