namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calificaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calificaciones",
                c => new
                    {
                        calificacion_id = c.Int(nullable: false, identity: true),
                        estudiante_id = c.Int(nullable: false),
                        horario_id = c.Int(nullable: false),
                        nota_curso = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.calificacion_id)
                .ForeignKey("dbo.Estudiantes", t => t.estudiante_id, cascadeDelete: true)
                .ForeignKey("dbo.Horarios", t => t.horario_id, cascadeDelete: true)
                .Index(t => t.estudiante_id)
                .Index(t => t.horario_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calificaciones", "horario_id", "dbo.Horarios");
            DropForeignKey("dbo.Calificaciones", "estudiante_id", "dbo.Estudiantes");
            DropIndex("dbo.Calificaciones", new[] { "horario_id" });
            DropIndex("dbo.Calificaciones", new[] { "estudiante_id" });
            DropTable("dbo.Calificaciones");
        }
    }
}
