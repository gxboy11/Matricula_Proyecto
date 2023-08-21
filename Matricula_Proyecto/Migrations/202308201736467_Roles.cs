namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        rol_id = c.Int(nullable: false, identity: true),
                        nombre_rol = c.String(),
                        descripcion_rol = c.String(),
                    })
                .PrimaryKey(t => t.rol_id);
            
            AddColumn("dbo.Usuarios", "rol_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuarios", "rol_id");
            AddForeignKey("dbo.Usuarios", "rol_id", "dbo.Roles", "rol_id", cascadeDelete: true);
            DropColumn("dbo.Usuarios", "rol");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "rol", c => c.String());
            DropForeignKey("dbo.Usuarios", "rol_id", "dbo.Roles");
            DropIndex("dbo.Usuarios", new[] { "rol_id" });
            DropColumn("dbo.Usuarios", "rol_id");
            DropTable("dbo.Roles");
        }
    }
}
