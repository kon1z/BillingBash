#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Kon.BillingBash.DbMigrator/Kon.BillingBash.DbMigrator.csproj", "src/Kon.BillingBash.DbMigrator/"]
COPY ["src/Kon.BillingBash.Application.Contracts/Kon.BillingBash.Application.Contracts.csproj", "src/Kon.BillingBash.Application.Contracts/"]
COPY ["src/Kon.BillingBash.Domain.Shared/Kon.BillingBash.Domain.Shared.csproj", "src/Kon.BillingBash.Domain.Shared/"]
COPY ["src/Kon.BillingBash.EntityFrameworkCore/Kon.BillingBash.EntityFrameworkCore.csproj", "src/Kon.BillingBash.EntityFrameworkCore/"]
COPY ["src/Kon.BillingBash.Domain/Kon.BillingBash.Domain.csproj", "src/Kon.BillingBash.Domain/"]
RUN dotnet restore "./src/Kon.BillingBash.DbMigrator/Kon.BillingBash.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/Kon.BillingBash.DbMigrator"
RUN dotnet build "./Kon.BillingBash.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Kon.BillingBash.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV TZ=Asia/Shanghai
WORKDIR /app
COPY --from=publish /app/publish .
RUN /bin/bash -c "sed -i $'s/\r$//' entrypoint.sh"
RUN chmod +x ./entrypoint.sh
ENTRYPOINT ["/bin/bash", "/app/entrypoint.sh"]