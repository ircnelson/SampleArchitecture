## Camadas (Layers)

* **Dominio**: Contém a representação do Negócio;
* **Infraestrutura**: Suporte ao Domínio para dependencias externas _(Ex: Abstração de Log e periféricos)_;
* **Infraestrutura.IoC**: Responsável pela injeção de dependência;
* **Dominio.Tests**: Contém os testes das entidade de negócio;
* **Infraestrutura.Tests**: Contém os testes de Integração _(Exemplo: Repositório de dados)_;
* **Infraestrutura.EntityFramework**: Implementação de Persistência de dados utilizando o ORM EntityFramework;
* **Infraestrutura.NHibernate**: Implementação de Persistência de dados utilizando o ORM NHibernate;

## Tecnologias usadas
* **Autofac**: Container de Injeção de Dependência;
* **xUnit**: Assert dos testes;
* **EntityFramework**: ORM - Implementação da abstração dos repositórios usando EntityFramework;
* **Nhibernate**: ORM - Implementação da abstração dos repositórios usando NHibernate;
* **Effort**: Banco de dados em memória para testes com EntityFramework;
* **SQLite**: Banco de dados em memória para testes com NHibernate;

## Padrões e Melhores Práticas (Patterns & Best Practices)
* **Uppercase**
  * Constants
* **PascalCase**
  * Class 
  * Methods 
  * (Public / Protected) Properties
  * (Public / Protected) Fields
  * Events
  * Enums
  * Interface
* **camelCase**
  * (Private) Properties
  * (Private) Fields
  * vars
  * params