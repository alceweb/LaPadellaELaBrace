namespace LaPadellaELaBeaceMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Promoes",
                c => new
                    {
                        Promo_Id = c.Int(nullable: false, identity: true),
                        DataI = c.DateTime(nullable: false),
                        DataF = c.DateTime(nullable: false),
                        Nome = c.String(),
                        Descrizione = c.String(),
                        Attiva = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Promo_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Promoes");
        }
    }
}
