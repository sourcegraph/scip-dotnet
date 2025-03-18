FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:d7f4691d11f610d9b94bb75517c9e78ac5799447b5b3e82af9e4625d8c8d1d53
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --framework net9.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet