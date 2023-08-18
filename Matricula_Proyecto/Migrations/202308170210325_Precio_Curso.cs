namespace Matricula_Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Precio_Curso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cursos", "precio_curso", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cursos", "precio_curso");
        }
    }
}
