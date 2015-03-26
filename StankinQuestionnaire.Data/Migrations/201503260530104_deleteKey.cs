namespace StankinQuestionnaire.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CalculationTypes", "IndicatorID", "dbo.Indicators");
            DropIndex("dbo.CalculationTypes", new[] { "IndicatorID" });
            RenameColumn(table: "dbo.CalculationTypes", name: "IndicatorID", newName: "Indicator_ID");
            AlterColumn("dbo.CalculationTypes", "Indicator_ID", c => c.Long());
            CreateIndex("dbo.CalculationTypes", "Indicator_ID");
            AddForeignKey("dbo.CalculationTypes", "Indicator_ID", "dbo.Indicators", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalculationTypes", "Indicator_ID", "dbo.Indicators");
            DropIndex("dbo.CalculationTypes", new[] { "Indicator_ID" });
            AlterColumn("dbo.CalculationTypes", "Indicator_ID", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.CalculationTypes", name: "Indicator_ID", newName: "IndicatorID");
            CreateIndex("dbo.CalculationTypes", "IndicatorID");
            AddForeignKey("dbo.CalculationTypes", "IndicatorID", "dbo.Indicators", "ID", cascadeDelete: true);
        }
    }
}
