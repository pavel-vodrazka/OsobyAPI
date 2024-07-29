namespace OsobyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zalozeni : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bydliste",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ulice = c.String(maxLength: 100),
                        Mesto = c.String(nullable: false, maxLength: 50),
                        PSC = c.String(nullable: false, maxLength: 10),
                        Stat = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staty", t => t.Stat, cascadeDelete: true)
                .Index(t => t.Stat);
            
            CreateTable(
                "dbo.Staty",
                c => new
                    {
                        Nazev = c.String(nullable: false, maxLength: 50),
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Nazev)
                .Index(t => t.Id, unique: true);
            
            CreateTable(
                "dbo.Kontakty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypKontaktu = c.String(nullable: false, maxLength: 50),
                        Hodnota = c.String(nullable: false, maxLength: 100),
                        OsobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Osoby", t => t.OsobaId, cascadeDelete: true)
                .ForeignKey("dbo.TypyKontaktu", t => t.TypKontaktu, cascadeDelete: true)
                .Index(t => t.TypKontaktu)
                .Index(t => t.OsobaId);
            
            CreateTable(
                "dbo.Osoby",
                c => new
                    {
                        Narodnost = c.String(nullable: false, maxLength: 50),
                        Id = c.Int(nullable: false, identity: true),
                        Jmeno = c.String(nullable: false, maxLength: 50),
                        Prijmeni = c.String(nullable: false, maxLength: 50),
                        RodnePrijmeni = c.String(maxLength: 50),
                        RodneCislo = c.String(nullable: false, maxLength: 10),
                        DatumNarozeni = c.DateTime(nullable: false),
                        BydlisteFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bydliste", t => t.BydlisteFK, cascadeDelete: true)
                .ForeignKey("dbo.Narodnosti", t => t.Narodnost, cascadeDelete: true)
                .Index(t => t.Narodnost)
                .Index(t => t.BydlisteFK);
            
            CreateTable(
                "dbo.Narodnosti",
                c => new
                    {
                        Nazev = c.String(nullable: false, maxLength: 50),
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Nazev)
                .Index(t => t.Id, unique: true);
            
            CreateTable(
                "dbo.TypyKontaktu",
                c => new
                    {
                        Typ = c.String(nullable: false, maxLength: 50),
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Typ)
                .Index(t => t.Id, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kontakty", "TypKontaktu", "dbo.TypyKontaktu");
            DropForeignKey("dbo.Osoby", "Narodnost", "dbo.Narodnosti");
            DropForeignKey("dbo.Kontakty", "OsobaId", "dbo.Osoby");
            DropForeignKey("dbo.Osoby", "BydlisteFK", "dbo.Bydliste");
            DropForeignKey("dbo.Bydliste", "Stat", "dbo.Staty");
            DropIndex("dbo.TypyKontaktu", new[] { "Id" });
            DropIndex("dbo.Narodnosti", new[] { "Id" });
            DropIndex("dbo.Osoby", new[] { "BydlisteFK" });
            DropIndex("dbo.Osoby", new[] { "Narodnost" });
            DropIndex("dbo.Kontakty", new[] { "OsobaId" });
            DropIndex("dbo.Kontakty", new[] { "TypKontaktu" });
            DropIndex("dbo.Staty", new[] { "Id" });
            DropIndex("dbo.Bydliste", new[] { "Stat" });
            DropTable("dbo.TypyKontaktu");
            DropTable("dbo.Narodnosti");
            DropTable("dbo.Osoby");
            DropTable("dbo.Kontakty");
            DropTable("dbo.Staty");
            DropTable("dbo.Bydliste");
        }
    }
}
