namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creacion_Horarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        horario_id = c.Int(nullable: false, identity: true),
                        curso_id = c.Int(nullable: false),
                        profesor_id = c.Int(nullable: false),
                        dia_semana = c.String(),
                        hora_inicio = c.Time(nullable: false, precision: 7),
                        hora_final = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.horario_id)
                .ForeignKey("dbo.Cursos", t => t.curso_id, cascadeDelete: true)
                .ForeignKey("dbo.Profesores", t => t.profesor_id, cascadeDelete: true)
                .Index(t => t.curso_id)
                .Index(t => t.profesor_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Horarios", "profesor_id", "dbo.Profesores");
            DropForeignKey("dbo.Horarios", "curso_id", "dbo.Cursos");
            DropIndex("dbo.Horarios", new[] { "profesor_id" });
            DropIndex("dbo.Horarios", new[] { "curso_id" });
            DropTable("dbo.Horarios");
        }
    }
}
