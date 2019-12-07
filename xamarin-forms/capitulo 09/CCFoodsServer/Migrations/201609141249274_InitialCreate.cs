namespace CCFoodsServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfiguracaoDispositivoes",
                c => new
                    {
                        ConfiguracaoDispositivoId = c.Long(nullable: false, identity: true),
                        EMail = c.String(),
                    })
                .PrimaryKey(t => t.ConfiguracaoDispositivoId);
            
            CreateTable(
                "dbo.Garcoms",
                c => new
                    {
                        GarcomId = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Foto = c.Binary(),
                        DispositivoId = c.Long(),
                        EntityId = c.Long(),
                        OperacaoSincronismo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GarcomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Garcoms");
            DropTable("dbo.ConfiguracaoDispositivoes");
        }
    }
}
