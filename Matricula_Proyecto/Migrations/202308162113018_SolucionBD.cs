namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolucionBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        carrera_id = c.Int(nullable: false, identity: true),
                        nombre_carrera = c.String(),
                        duracion = c.Int(nullable: false),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.carrera_id);
            
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        curso_id = c.Int(nullable: false, identity: true),
                        nombre_curso = c.String(),
                        descripcion = c.String(),
                        creditos_curso = c.Int(nullable: false),
                        carrera_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.curso_id)
                .ForeignKey("dbo.Carreras", t => t.carrera_id, cascadeDelete: false)
                .Index(t => t.carrera_id);
            
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
                        carrera_id = c.Int(nullable: false),
                        usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.estudiante_id)
                .ForeignKey("dbo.Carreras", t => t.carrera_id, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id, cascadeDelete: false)
                .Index(t => t.carrera_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        usuario_id = c.Int(nullable: false, identity: true),
                        usuario_nombre = c.String(),
                        password = c.String(),
                        rol = c.String(),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.usuario_id);
            
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
                .ForeignKey("dbo.Cursos", t => t.curso_id, cascadeDelete: false)
                .ForeignKey("dbo.Profesores", t => t.profesor_id, cascadeDelete: false)
                .Index(t => t.curso_id)
                .Index(t => t.profesor_id);
            
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
                        usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.profesor_id)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id, cascadeDelete: false)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        matricula_id = c.Int(nullable: false, identity: true),
                        estudiante_id = c.Int(nullable: false),
                        horario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.matricula_id)
                .ForeignKey("dbo.Estudiantes", t => t.estudiante_id, cascadeDelete: false)
                .ForeignKey("dbo.Horarios", t => t.horario_id, cascadeDelete: false)
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
                .ForeignKey("dbo.Estudiantes", t => t.estudiante_id, cascadeDelete: false)
                .ForeignKey("dbo.Horarios", t => t.horario_id, cascadeDelete: false)
                .Index(t => t.estudiante_id)
                .Index(t => t.horario_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prematriculas", "horario_id", "dbo.Horarios");
            DropForeignKey("dbo.Prematriculas", "estudiante_id", "dbo.Estudiantes");
            DropForeignKey("dbo.Matriculas", "horario_id", "dbo.Horarios");
            DropForeignKey("dbo.Matriculas", "estudiante_id", "dbo.Estudiantes");
            DropForeignKey("dbo.Horarios", "profesor_id", "dbo.Profesores");
            DropForeignKey("dbo.Profesores", "usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.Horarios", "curso_id", "dbo.Cursos");
            DropForeignKey("dbo.Estudiantes", "usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.Estudiantes", "carrera_id", "dbo.Carreras");
            DropForeignKey("dbo.Cursos", "carrera_id", "dbo.Carreras");
            DropIndex("dbo.Prematriculas", new[] { "horario_id" });
            DropIndex("dbo.Prematriculas", new[] { "estudiante_id" });
            DropIndex("dbo.Matriculas", new[] { "horario_id" });
            DropIndex("dbo.Matriculas", new[] { "estudiante_id" });
            DropIndex("dbo.Profesores", new[] { "usuario_id" });
            DropIndex("dbo.Horarios", new[] { "profesor_id" });
            DropIndex("dbo.Horarios", new[] { "curso_id" });
            DropIndex("dbo.Estudiantes", new[] { "usuario_id" });
            DropIndex("dbo.Estudiantes", new[] { "carrera_id" });
            DropIndex("dbo.Cursos", new[] { "carrera_id" });
            DropTable("dbo.Prematriculas");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Profesores");
            DropTable("dbo.Horarios");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Cursos");
            DropTable("dbo.Carreras");
        }
    }
}
