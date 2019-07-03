FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/YMApp.Web.Admin/YMApp.Web.Admin.csproj", "src/YMApp.Web.Admin/"]
COPY ["src/YMApp.Web.Core/YMApp.Web.Core.csproj", "src/YMApp.Web.Core/"]
COPY ["src/YMApp.Application/YMApp.Application.csproj", "src/YMApp.Application/"]
COPY ["src/YMApp.Core/YMApp.Core.csproj", "src/YMApp.Core/"]
COPY ["src/YMApp.EntityFrameworkCore/YMApp.EntityFrameworkCore.csproj", "src/YMApp.EntityFrameworkCore/"]
RUN dotnet restore "src/YMApp.Web.Admin/YMApp.Web.Admin.csproj"
COPY . .
WORKDIR "/src/src/YMApp.Web.Admin"
RUN dotnet build "YMApp.Web.Admin.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "YMApp.Web.Admin.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "YMApp.Web.Admin.dll"]