namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Matriculas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        matricula_id = c.Int(nullable: false, identity: true),
                        estudiante_id = c.Int(nullable: false),
                        horario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.matricula_id)
                .ForeignKey("dbo.Estudiantes", t => t.estudiante_id, cascadeDelete: true)
                .ForeignKey("dbo.Horarios", t => t.horario_id, cascadeDelete: true)
                .Index(t => t.estudiante_id)
                .Index(t => t.horario_id);
            
            CreateTable(
                "dbo.Prematriculas",
                c => new
                    {
                        prematricula_id = c.Int(nullable: false, identity: true),
                        estudiante_id = c.Int(nullable: false),
                        horario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.prematricula_id)
                .ForeignKey("dbo.Estudiantes", t => t.estudiante_id, cascadeDelete: true)
                .ForeignKey("dbo.Horarios", t => t.horario_id, cascadeDelete: true)
                .Index(t => t.estudiante_id)
                .Index(t => t.horario_id);
            
            AddColumn("dbo.Cursos", "carrera", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prematriculas", "horario_id", "dbo.Horarios");
            DropForeignKey("dbo.Prematriculas", "estudiante_id", "dbo.Estudiantes");
            DropForeignKey("dbo.Matriculas", "horario_id", "dbo.Horarios");
            DropForeignKey("dbo.Matriculas", "estudiante_id", "dbo.Estudiantes");
            DropIndex("dbo.Prematriculas", new[] { "horario_id" });
            DropIndex("dbo.Prematriculas", new[] { "estudiante_id" });
            DropIndex("dbo.Matriculas", new[] { "horario_id" });
            DropIndex("dbo.Matriculas", new[] { "estudiante_id" });
            DropColumn("dbo.Cursos", "carrera");
            DropTable("dbo.Prematriculas");
            DropTable("dbo.Matriculas");
        }
    }
}
