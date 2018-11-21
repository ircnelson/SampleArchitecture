using FluentMigrator;

namespace SampleArchitecture.Data.EFCore.Migrations
{
    [Migration(1)]
    public class Migration0001 : Migration
    {
        public override void Up()
        {
            Create.Table("Ufs")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity();
            
            Create.Table("Cidades")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UfId").AsInt32().NotNullable().ForeignKey("Ufs", "Id");
            
            Create.Table("Bancos")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Codigo").AsFixedLengthString(3).NotNullable()
                .WithColumn("Nome").AsString(255).NotNullable()
                .WithColumn("NomeCurto").AsString(255).Nullable();

            Insert.IntoTable("Bancos")
                .Row(new {Codigo = "001", NomeCurto = "BB", Nome = "Banco do Brasil"})
                .Row(new {Codigo = "002", NomeCurto = "BACEN", Nome = "Banco Central do Brasil"})
                .Row(new {Codigo = "003", NomeCurto = "BASA", Nome = "Banco da Amazônia"})
                .Row(new {Codigo = "004", NomeCurto = "BNB", Nome = "Banco do Nordeste do Brasil"})
                .Row(new {Codigo = "007", NomeCurto = "BNDES", Nome = "Banco Nacional de Desenvolvimento Econômico e Social"})
                .Row(new {Codigo = "104", NomeCurto = "CEF", Nome = "Caixa Econômica Federal"})
                .Row(new {Codigo = "046", NomeCurto = "BRDE", Nome = "Banco Regional de Desenvolvimento do Extremo Sul"})
                .Row(new {Codigo = "023", NomeCurto = "BDMG", Nome = "Banco de Desenvolvimento de Minas Gerais"})
                .Row(new {Codigo = "070", NomeCurto = "BRB", Nome = "Banco de Brasília"})
                .Row(new {Codigo = "047", NomeCurto = "Banese", Nome = "Banco do Estado de Sergipe"})
                .Row(new {Codigo = "021", NomeCurto = "Banestes", Nome = "Banco do Estado do Espírito Santo"})
                .Row(new {Codigo = "037", NomeCurto = "Banpará", Nome = "Banco do Estado do Pará"})
                .Row(new {Codigo = "041", NomeCurto = "Banrisul", Nome = "Banco do Estado do Rio Grande do Sul"})
                .Row(new {Codigo = "075", NomeCurto = "ABN", Nome = "Banco ABN Amro S.A."})
                .Row(new {Codigo = "025", NomeCurto = "Alfa", Nome = "Banco Alfa"})
                .Row(new {Codigo = "719", NomeCurto = "Banif", Nome = "Banco Banif"})
                .Row(new {Codigo = "107", NomeCurto = "BBM", Nome = "Banco BBM"})
                .Row(new {Codigo = "318", NomeCurto = "BMG", Nome = "Banco BMG"})
                .Row(new {Codigo = "218", NomeCurto = "Bonsucesso", Nome = "Banco Bonsucesso"})
                .Row(new {Codigo = "208", NomeCurto = "BTG", Nome = "Banco BTG Pactual"})
                .Row(new {Codigo = "263", NomeCurto = "Cacique", Nome = "Banco Cacique"})
                .Row(new {Codigo = "745", NomeCurto = "Citibank", Nome = "Banco Citibank"})
                .Row(new {Codigo = "721", NomeCurto = "Credibel", Nome = "Banco Credibel"})
                .Row(new {Codigo = "229", NomeCurto = "Cruzeiro do Sul", Nome = "Banco Cruzeiro do Sul"})
                .Row(new {Codigo = "707", NomeCurto = "Daycoval", Nome = "Banco Daycoval"})
                .Row(new {Codigo = "265", NomeCurto = "Fator", Nome = "Banco Fator"})
                .Row(new {Codigo = "224", NomeCurto = "Fibra", Nome = "Banco Fibra"})
                .Row(new {Codigo = "121", NomeCurto = "Gerador", Nome = "Banco Gerador"})
                .Row(new {Codigo = "612", NomeCurto = "Guanabara", Nome = "Banco Guanabara"})
                .Row(new {Codigo = "604", NomeCurto = "BI", Nome = "Banco Industrial do Brasil"})
                .Row(new {Codigo = "320", NomeCurto = "BICBANCO", Nome = "Banco Industrial e Comercial"})
                .Row(new {Codigo = "630", NomeCurto = "Intercap", Nome = "Banco Intercap"})
                .Row(new {Codigo = "077", NomeCurto = "Intermedium", Nome = "Banco Intermedium"})
                .Row(new {Codigo = "389", NomeCurto = "BMB", Nome = "Banco Mercantil do Brasil"})
                .Row(new {Codigo = "746", NomeCurto = "Modal", Nome = "Banco Modal"})
                .Row(new {Codigo = "738", NomeCurto = "Morada", Nome = "Banco Morada"})
                .Row(new {Codigo = "623", NomeCurto = "Panamericano", Nome = "Banco Panamericano"})
                .Row(new {Codigo = "611", NomeCurto = "Paulista", Nome = "Banco Paulista"})
                .Row(new {Codigo = "643", NomeCurto = "Pine", Nome = "Banco Pine"})
                .Row(new {Codigo = "638", NomeCurto = "Prosper", Nome = "Banco Prosper"})
                .Row(new {Codigo = "654", NomeCurto = "Renner", Nome = "Banco Renner"})
                .Row(new {Codigo = "453", NomeCurto = "Rural", Nome = "Banco Rural"})
                .Row(new {Codigo = "422", NomeCurto = "Safra", Nome = "Banco Safra"})
                .Row(new {Codigo = "033", NomeCurto = "Santander", Nome = "Banco Santander"})
                .Row(new {Codigo = "637", NomeCurto = "Sofisa", Nome = "Banco Sofisa"})
                .Row(new {Codigo = "655", NomeCurto = "BV", Nome = "Banco Votorantim"})
                .Row(new {Codigo = "237", NomeCurto = "Bradesco", Nome = "Bradesco"})
                .Row(new {Codigo = "399", NomeCurto = "HSBC", Nome = "HSBC Bank Brasil"})
                .Row(new {Codigo = "263", NomeCurto = "Caixa geral", Nome = "Banco Caixa Geral"})
                .Row(new {Codigo = "505", NomeCurto = "", Nome = "Banco Credit Suisse"})
                .Row(new {Codigo = "184", NomeCurto = "Itaú BBA", Nome = "Banco Itaú BBA"})
                .Row(new {Codigo = "479", NomeCurto = "ItáuBank", Nome = "Banco ItaúBank"})
                .Row(new {Codigo = "741", NomeCurto = "BRP", Nome = "Banco Ribeirão Preto"})
                .Row(new {Codigo = "082", NomeCurto = "Topázio", Nome = "Banco Topázio"})
                .Row(new {Codigo = "341", NomeCurto = "Itaú", Nome = "Itaú Unibanco"});
        }

        public override void Down()
        {
        }
    }
}