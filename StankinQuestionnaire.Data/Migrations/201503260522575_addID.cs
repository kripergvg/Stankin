namespace StankinQuestionnaire.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CalculationTypes", "Indicator_ID", "dbo.Indicators");
            DropIndex("dbo.CalculationTypes", new[] { "Indicator_ID" });
            RenameColumn(table: "dbo.CalculationTypes", name: "Indicator_ID", newName: "IndicatorID");
            DropPrimaryKey("dbo.Сalculation");
            AlterColumn("dbo.Сalculation", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.CalculationTypes", "IndicatorID", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Сalculation", "ID");
            CreateIndex("dbo.CalculationTypes", "IndicatorID");
            AddForeignKey("dbo.CalculationTypes", "IndicatorID", "dbo.Indicators", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalculationTypes", "IndicatorID", "dbo.Indicators");
            DropIndex("dbo.CalculationTypes", new[] { "IndicatorID" });
            DropPrimaryKey("dbo.Сalculation");
            AlterColumn("dbo.CalculationTypes", "IndicatorID", c => c.Long());
            AlterColumn("dbo.Сalculation", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Сalculation", "ID");
            RenameColumn(table: "dbo.CalculationTypes", name: "IndicatorID", newName: "Indicator_ID");
            CreateIndex("dbo.CalculationTypes", "Indicator_ID");
            AddForeignKey("dbo.CalculationTypes", "Indicator_ID", "dbo.Indicators", "ID");
        }
    }
}
