FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /App

COPY . ./

ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 3.1.22 \
    && dotnet restore "DescomplicaseApp.csproj" --disable-parallel \
    && dotnet publish -c Release -o out \
    && dotnet add package Microsoft.EntityFrameworkcore.design \
    && dotnet tool install -g dotnet-ef

EXPOSE 5000/tcp
EXPOSE 5001/tcp

ENTRYPOINT ["dotnet", "run"]