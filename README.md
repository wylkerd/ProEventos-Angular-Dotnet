# ProEventos 🗓️🅰️🦄
*Angular + .Net and EF Core 6*

**ProEventos é uma aplicação de ponta a ponta, feita com Angular, Dotnet (.Net) 6 e SQL Server/SQLite. Feito com o curso Seja FullStack na Udemy.** 

### Especificacoes WebApi
* sdk 6.0.201
* .Net: 6
* dotnet new globaljson --sdk-version 6.0.201
* dotnet tool install --global dotnet-ef --version 6.0.0

### Comandos em ordem para criar WebApi
* Models, Controllers, DbContext, Configuracoes DB na Startup, Migration e DB update.
* dotnet new webapi -n ProEventos.API
* dotnet run
* dotnet ef migrations add Initial -o Data/Migrations
* dotnet ef database update

--------------------------------------------
### Bibliotecas Nuget, interessantes para serem utilizadas em aplicações .Net
* Entity Framework Core : ORM para realização de consultas (crud) e manipulações do Banco de dados também (migrations, updates e etc, por meio do CLI) no banco de dados, consultas com LINQ ou Diretas por meio do fromSQL(), por exemplo.
* Dapper : Micro ORM para aplicações .Net e .Net Core, permite acessar dados do banco de forma facil, permite executar query puras com SqlRaw(), Queries puras com QueryAsync(), mapear resultados para objetos etc [Documentação oficial]([https://www.learndapper.com/]).
* EPPLUS : Serve para criação de planilhas Excel.
* Canducci.Pagination : Serve para trabalhar com paginação feita pelo backend em conjunto com envio de informações da paginação enviada pelo client.
