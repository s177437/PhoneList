FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ENV ASPNETCORE_URLS=http://+:8080
COPY bin/Release/netcoreapp3.1/publish/ PhoneList/
WORKDIR /PhoneList
# comment
ENTRYPOINT [ "dotnet", "PhoneList.dll" ]