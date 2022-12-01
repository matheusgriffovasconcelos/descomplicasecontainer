FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /App

COPY . ./

RUN dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 3.1.22 \
    && dotnet add package Microsoft.EntityFrameworkcore.sqlite \
    && dotnet add package Microsoft.EntityFrameworkcore.design \
    && dotnet tool install -g dotnet-ef

EXPOSE 5000/tcp
EXPOSE 5001/tcp

ENTRYPOINT ["dotnet", "run"]
