## Camadas (Layers)

* **Dominio**: Cont&eacute;m a representa&ccedil;&atilde;o do Neg&oacute;cio;
* **Infraestrutura**: Suporte ao Dom&iacute;nio para dependencias externas _(Ex: Abstra&ccedil;&atilde;o de Log e perif&eacute;ricos)_;
* **Infraestrutura.IoC**: Respons&aacute;vel pela inje&ccedil;&atilde;o de depend&ecirc;ncia;
* **Infraestrutura.Tests**: Cont&eacute;m os testes de Integra&ccedil;&atilde;o;
* **Infraestrutura.EntityFramework**: Implementa&ccedil;&atilde;o de Persist&ecirc;ncia de dados utilizando o ORM EntityFramework;
* **Infraestrutura.NHibernate**: Implementa&ccedil;&atilde;o de Persist&ecirc;ncia de dados utilizando o ORM NHibernate;

## Tecnologias usadas
* **Autofac**: Container de Inje&ccedil;&atilde;o de Depend&ecirc;ncia;
* **NUnit**: Asser&ccedil;&atilde;o dos testes;
* **EntityFramework**: ORM;
* **Nhibernate**: ORM;
* **Effort**: Banco de dados em mem&oacute;ria para testes com EntityFramework;
* **SQLite**: Banco de dados em mem&oacute;ria para testes com NHibernate;

## Padr&otilde;es e Melhores Pr&aacute;ticas (Patterns & Best Practices)

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
* **kamelCase**
  * (Private) Properties
  * (Private) Fields
  * vars
  * params