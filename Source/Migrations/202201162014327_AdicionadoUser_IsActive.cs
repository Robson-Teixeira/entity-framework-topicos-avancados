namespace P3.Migrations
{
    using System.Data.Entity.Migrations;

    /*Gerado por meio do Package Manager Console: PM> Add-Migration AdicionadoUser_IsActive*/
    /*Concluir por meio do Package Manager Console: PM> Update-Database*/
    public partial class AdicionadoUser_IsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsActive", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.User", "IsActive");
        }
    }
}