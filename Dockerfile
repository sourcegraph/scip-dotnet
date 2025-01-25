FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:84fd557bebc64015e731aca1085b92c7619e49bdbe247e57392a43d92276f617
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --framework net8.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet