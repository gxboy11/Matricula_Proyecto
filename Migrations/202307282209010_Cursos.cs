namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cursos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        curso_id = c.Int(nullable: false, identity: true),
                        nombre_curso = c.String(),
                        descripcion = c.String(),
                        creditos_curso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.curso_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cursos");
        }
    }
}
