namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        admin_id = c.Int(nullable: false, identity: true),
                        nombre_admin = c.String(),
                        usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.admin_id)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id, cascadeDelete: false)
                .Index(t => t.usuario_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "usuario_id", "dbo.Usuarios");
            DropIndex("dbo.Admins", new[] { "usuario_id" });
            DropTable("dbo.Admins");
        }
    }
}
