FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "PortfolioCiCdDotNet8.dll"]