namespace Nicacio.ClinicaVeterinaria.AcessoDados.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prontuario", "Animal_Id", "dbo.Animal");
            DropForeignKey("dbo.Prontuario", "Medico_Id", "dbo.Medico");
            DropIndex("dbo.Prontuario", new[] { "Animal_Id" });
            DropIndex("dbo.Prontuario", new[] { "Medico_Id" });
            DropColumn("dbo.Prontuario", "IdProntuario");
            DropColumn("dbo.Prontuario", "IdProntuario");
            RenameColumn(table: "dbo.Prontuario", name: "Animal_Id", newName: "IdProntuario");
            RenameColumn(table: "dbo.Prontuario", name: "Medico_Id", newName: "IdProntuario");
            DropPrimaryKey("dbo.Prontuario");
            AlterColumn("dbo.Prontuario", "IdProntuario", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Prontuario", "IdProntuario", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Prontuario", "IdProntuario");
            CreateIndex("dbo.Prontuario", "IdProntuario");
            AddForeignKey("dbo.Prontuario", "IdProntuario", "dbo.Animal", "IdAnimal");
            AddForeignKey("dbo.Prontuario", "IdProntuario", "dbo.Medico", "IdMedico");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prontuario", "IdProntuario", "dbo.Medico");
            DropForeignKey("dbo.Prontuario", "IdProntuario", "dbo.Animal");
            DropIndex("dbo.Prontuario", new[] { "IdProntuario" });
            DropPrimaryKey("dbo.Prontuario");
            AlterColumn("dbo.Prontuario", "IdProntuario", c => c.Int(nullable: false));
            AlterColumn("dbo.Prontuario", "IdProntuario", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Prontuario", "IdProntuario");
            RenameColumn(table: "dbo.Prontuario", name: "IdProntuario", newName: "Medico_Id");
            RenameColumn(table: "dbo.Prontuario", name: "IdProntuario", newName: "Animal_Id");
            AddColumn("dbo.Prontuario", "IdProntuario", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Prontuario", "IdProntuario", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Prontuario", "Medico_Id");
            CreateIndex("dbo.Prontuario", "Animal_Id");
            AddForeignKey("dbo.Prontuario", "Medico_Id", "dbo.Medico", "IdMedico", cascadeDelete: true);
            AddForeignKey("dbo.Prontuario", "Animal_Id", "dbo.Animal", "IdAnimal", cascadeDelete: true);
        }
    }
}
