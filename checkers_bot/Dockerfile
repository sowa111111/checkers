FROM mcr.microsoft.com/dotnet/core/sdk:2.2.301-alpine3.9 as build

WORKDIR /build

COPY . /build

ARG SERVICE_VERSION=1.0.0

RUN dotnet build --configuration Release /p:Version=$SERVICE_VERSION
RUN dotnet publish --configuration Release --no-build --no-restore /p:Version=$SERVICE_VERSION checkers_bot/checkers_bot.csproj

# -----------------
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.6-alpine3.9

COPY --from=build --chown=nobody:nobody ./build/checkers_bot/bin/Release/netcoreapp2.2/publish /build

USER nobody

WORKDIR /build

EXPOSE 9000

CMD ["dotnet", "checkers_bot.dll"]
