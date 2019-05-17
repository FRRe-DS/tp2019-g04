FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Microservicio/Microservicio.csproj", "Microservicio/"]
RUN dotnet restore "Microservicio/Microservicio.csproj"
COPY . .
WORKDIR "/src/Microservicio"
RUN dotnet build "Microservicio.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Microservicio.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservicio.dll"]