FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:4b684e6c74ab8dff26ac54c79d8242b1dd05aba06c367de2b583bad79fd6399b
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --add-source ScipDotnet/bin/Debug/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet