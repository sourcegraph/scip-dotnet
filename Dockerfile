# Pinned by digest: the multi-arch mcr.microsoft.com/dotnet/sdk:10.0 index (10.0.402-noble, Ubuntu 24.04.5)
# ships ca-certificates 20260816ubuntu0.24.04.1, which distrusts the compromised eMudhra chains (INC-541).
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0@sha256:747cbade5bfd918a175ac32f8f1d931edec2c7d0d5397a3de72eaef1ac1f66d2
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --framework net10.0 --add-source ScipDotnet/bin/Release/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet
