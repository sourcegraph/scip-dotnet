FROM mcr.microsoft.com/dotnet/sdk:7.0@sha256:e44ea6d4cd019913b80726896e1127cd3fd6bd0f5c1d2074be02da3e54931127
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --add-source ScipDotnet/bin/Debug/ --global scip-dotnet
RUN dotnet clean
WORKDIR /app
RUN rm -rf /scip-dotnet