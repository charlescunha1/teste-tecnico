# Usando a imagem base do .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diretório de trabalho
WORKDIR /app

# Copiar o arquivo .csproj e restaurar dependências
COPY ./API-Bank/API-Bank/API-Bank.csproj ./API-Bank/

# Limpar qualquer build anterior
RUN dotnet clean API-Bank/API-Bank.csproj

RUN dotnet restore ./API-Bank/API-Bank.csproj

# Copiar todos os arquivos do projeto
COPY . .

# Publicar o projeto
RUN dotnet publish ./API-Bank/API-Bank/API-Bank.csproj -c Release -o /app/publish

# Usar a imagem do .NET runtime para execução
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final

# Definir o diretório de trabalho
WORKDIR /app

# Copiar o conteúdo publicado da imagem anterior
COPY --from=build /app/publish .

# Copiar todos os arquivos do projeto
COPY ./API-Bank /app/src

RUN dotnet tool install --global dotnet-ef

# Adicionar o diretório das ferramentas dotnet ao PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Expor a porta
EXPOSE 80

# Definir o comando para rodar a aplicação
ENTRYPOINT ["dotnet", "API-Bank.dll"]