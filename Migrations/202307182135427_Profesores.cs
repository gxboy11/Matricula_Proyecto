namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profesores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profesores",
                c => new
                    {
                        profesor_id = c.Int(nullable: false, identity: true),
                        nombre_profesor = c.String(),
                        apellido_profesor = c.String(),
                        correo_electronico = c.String(),
                        fecha_nacimiento_profesor = c.String(),
                        direccion = c.String(),
                        telefono_profesor = c.String(),
                        area_espec = c.String(),
                    })
                .PrimaryKey(t => t.profesor_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profesores");
        }
    }
}
