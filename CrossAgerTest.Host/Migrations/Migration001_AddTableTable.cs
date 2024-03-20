using FluentMigrator;

namespace CrossAgerTest.Migrations;

[Migration(1)]
public class Migration001_AddTableTable() : Migration
{
    public override void Up()
    {
        Create.Table("table")
            .WithColumn("id").AsInt32().Identity().PrimaryKey("table_pk")
            .WithColumn("size").AsInt32().NotNullable()
            .WithColumn("empty_chairs").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("table");
    }
}