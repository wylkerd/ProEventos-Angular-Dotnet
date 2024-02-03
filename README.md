# ProEventos 🗓️🅰️🦄
*Angular + .Net and EF Core 6*
**ProEventos é uma aplicação de ponta a ponta, feita com Angular, Dotnet (.Net) 6 e SQL Server/SQLite. Feito com o curso Seja FullStack na Udemy.** 

### Especificacoes WebApi
* sdk 6.0.201
* .Net: 6
* dotnet new globaljson --sdk-version 6.0.201

### Comandos em ordem para criar WebApi
* Models, Controllers, DbContext, Configuracoes DB na Startup, Migration e DB update.
* dotnet new webapi -n ProEventos.API
* dotnet run
* dotnet ef migrations add Initial -o Data/Migrations
* dotnet ef database update
