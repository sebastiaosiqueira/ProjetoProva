namespace Transporte.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Transportes.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.TransportesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.TransportesContext context)
        {
            context.Usuarios.AddOrUpdate(
         m => m.Nome,
            new Usuario { Nome = "SEBASTIAO VALFRIDES SIQUEIRA",  Email = "sebastiao.valfrides@gmail.com", CPF = "83848334311", Endereco="RUA DO BRAZ", Numero="100", Bairro="CONCORDIA",UF="MS", Cidade="CAMPO GRANDE" }
        );
        }
    }
}
