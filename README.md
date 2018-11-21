## Camadas (Layers)

* **Core**: Contém a representação do Negócio;
* **Application**: Contém a orquestração entre entidades do __Core__ e possíveis integrações com serviços e infraestruturas externas;
* **Infrastructure**: Contém a implementação concreta para as abstrações criadas na camada de __Application__;
* **WebApi**: Expõe os recursos da aplicação através do protocolo HTTP;

## Tecnologias usadas

* **Microsoft Dependency Injection**: Container de Injeção de Dependência;
* **[xUnit](https://xunit.github.io/)**: Test runner;
* **[FluentAssertions](https://github.com/fluentassertions/fluentassertions)**: Assert de testes;
* **[FluentValidations](https://github.com/JeremySkinner/FluentValidation)**: Valida as entradas na aplicação;
* **[FluentMigrator](https://fluentmigrator.github.io/)**: Gerencia a versão de scripts de migração de Banco de Dados;
* **[MediatR](https://github.com/jbogard/MediatR)**: Dispatch e controle de mensagens;
* **[EntityFramework Core](https://github.com/aspnet/EntityFrameworkCore)**: ORM;
* **[Dapper](https://github.com/StackExchange/Dapper)**: Queries;
* **[Mappy](https://github.com/Dolfik1/Mappy/tree/master/Mappy)**: Hidrata um objeto dinamicamente (usado para retorno de queries mais complexas) ;
* **[Coverlet](https://github.com/tonerdo/coverlet)**: Inclui comandos no MSBuild no projeto de testes para dar saída no formato OpenCover;
* **[CakeBuild](https://cakebuild.net/)**: Contém instruções para fazer build, test e code coverage
* **[Swagger API](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)**: Expõe os endpoints da camada HTTP
* **[Resources](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-2.1)**: Traduções, I18n.