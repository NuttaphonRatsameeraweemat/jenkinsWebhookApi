FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY JenkinsWebHook/JenkinsWebHook.csproj JenkinsWebHook/
COPY JenkinsWebHook.Bll/JenkinsWebHook.Bll.csproj JenkinsWebHook.Bll/
RUN dotnet restore JenkinsWebHook/JenkinsWebHook.csproj
COPY . .
WORKDIR /src/JenkinsWebHook
RUN dotnet build JenkinsWebHook.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish JenkinsWebHook.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JenkinsWebHook.dll"]
