#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aspnet.Mal3ab/Aspnet.Mal3ab.csproj", "Aspnet.Mal3ab/"]
RUN dotnet restore "Aspnet.Mal3ab/Aspnet.Mal3ab.csproj"
COPY . .
WORKDIR "/src/Aspnet.Mal3ab"
RUN dotnet build "Aspnet.Mal3ab.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aspnet.Mal3ab.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aspnet.Mal3ab.dll"]