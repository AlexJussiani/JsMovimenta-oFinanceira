#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Services/JsMovimentacaoFinanceira/JS.MovimentacaoConta.API/JS.MovimentacaoConta.API.csproj", "Services/JsMovimentacaoFinanceira/JS.MovimentacaoConta.API/"]
COPY ["./Services/JsMovimentacaoFinanceira/building blocks/JS.Core/JS.Core.csproj", "Services/JsMovimentacaoFinanceira/building blocks/JS.Core/"]
COPY ["./Services/JsMovimentacaoFinanceira/building blocks/JS.EventSourcing/JS.EventSourcing.csproj", "Services/JsMovimentacaoFinanceira/building blocks/JS.EventSourcing/"]
COPY ["./Services/JsMovimentacaoFinanceira/building blocks/JS.MessageBus/JS.MessageBus.csproj", "Services/JsMovimentacaoFinanceira/building blocks/JS.MessageBus/"]
COPY ["./Services/JsMovimentacaoFinanceira/building blocks/JS.WebAPI.Core/JS.WebAPI.Core.csproj", "Services/JsMovimentacaoFinanceira/building blocks/JS.WebAPI.Core/"]
COPY ["./Services/JsMovimentacaoFinanceira/JS.MovimentacaoConta.Domain/JS.MovimentacaoConta.Domain.csproj", "Services/JsMovimentacaoFinanceira/JS.MovimentacaoConta.Domain/"]
COPY ["./Services/JsMovimentacaoFinanceira/JS.MovimentacaoConta.Infra/JS.MovimentacaoConta.Infra.csproj", "Services/JsMovimentacaoFinanceira/JS.MovimentacaoConta.Infra/"]
RUN dotnet restore "Services/JsMovimentacaoFinanceira/JS.MovimentacaoConta.API/JS.MovimentacaoConta.API.csproj"
COPY . .
WORKDIR "./Services/JsMovimentacaoFinanceira/JS.MovimentacaoConta.API"
RUN dotnet build "JS.MovimentacaoConta.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JS.MovimentacaoConta.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JS.MovimentacaoConta.API.dll"]