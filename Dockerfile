FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --add-source ScipDotnet/bin/Debug/ --global scip-dotnet
RUN rm -rf /scip-dotnet