FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /scip-dotnet
ADD . /scip-dotnet
RUN dotnet pack
RUN dotnet tool install --add-source ScipDotnet/bin/Debug/ --global scip-dotnet
RUN mv /root/.dotnet/tools/scip-dotnet /usr/local/bin/scip-dotnet
RUN rm -rf /scip-dotnet
WORKDIR /root