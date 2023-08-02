namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Usuarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        usuario_id = c.Int(nullable: false, identity: true),
                        usuario_nombre = c.String(),
                        password = c.String(),
                        rol = c.String(),
                    })
                .PrimaryKey(t => t.usuario_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
