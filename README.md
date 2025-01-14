# API-Bank

Duas APIs que se comunicam: Transactions e BankAccount. as duas APIs entao em um único diretório.
Transactions => Essa API foi desenvolvida para realizar as operações bancárias, tais como Credito e Débito.
BankAccount =>  Essa API foi desenvolvida para gerenciamento de contas.
OBS: As duas APIs e o banco de dados estao rodando num só container.
As Migrations são geradas automaticamente ao estartar o container.

## Tecnologias Utilizadas

* REST
* C#
* Entity Framework Core
* .Net Core
* MySQL
* Java
* Spring-boot
* Docker

## Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/pt-br/download/).
* MySQL
* Docker e Docker compose


## Configuração

1. Clone o repositório:

```
https://github.com/charlescunha1/teste-tecnico
```

2. Execute os seguintes comandos para rodar os projetos e o banco de dados no docker:

```
docker compose build
docker compose up -d
```

3. Acesse a API do C# usando o swagger em http://localhost:5000/swagger/index.html

4. Acesse a API do java em http://localhost:8080/api/v1/transactions

