namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Estudiantes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        estudiante_id = c.Int(nullable: false, identity: true),
                        nombre_estudiante = c.String(),
                        apellido_estudiante = c.String(),
                        correo_estudiante = c.String(),
                        fecha_nacimiento_estudiante = c.String(),
                        direccion_estudiante = c.String(),
                        telefono_estudiante = c.String(),
                    })
                .PrimaryKey(t => t.estudiante_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Estudiantes");
        }
    }
}
