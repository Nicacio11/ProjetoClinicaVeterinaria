namespace Nicacio.ClinicaVeterinaria.AcessoDados.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        IdAnimal = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Raca = c.String(nullable: false),
                        NomeDono = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdAnimal);
            
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        IdMedico = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Especialidade = c.String(nullable: false),
                        NCRV = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdMedico);
            
            CreateTable(
                "dbo.Prontuario",
                c => new
                    {
                        IdProntuario = c.Int(nullable: false, identity: true),
                        DataAtendimento = c.DateTime(nullable: false),
                        Observacao = c.String(),
                        Animal_Id = c.Int(nullable: false),
                        Medico_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProntuario)
                .ForeignKey("dbo.Animal", t => t.Animal_Id, cascadeDelete: true)
                .ForeignKey("dbo.Medico", t => t.Medico_Id, cascadeDelete: true)
                .Index(t => t.Animal_Id)
                .Index(t => t.Medico_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prontuario", "Medico_Id", "dbo.Medico");
            DropForeignKey("dbo.Prontuario", "Animal_Id", "dbo.Animal");
            DropIndex("dbo.Prontuario", new[] { "Medico_Id" });
            DropIndex("dbo.Prontuario", new[] { "Animal_Id" });
            DropTable("dbo.Prontuario");
            DropTable("dbo.Medico");
            DropTable("dbo.Animal");
        }
    }
}
