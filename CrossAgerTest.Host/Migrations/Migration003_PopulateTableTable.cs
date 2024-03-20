using FluentMigrator;

namespace CrossAgerTest.Migrations;

[Migration(3)]
public class Migration003_PopulateTableTable() : Migration
{
    public override void Up()
    {
        Insert.IntoTable("table")
            .Row(new { size = 2, empty_chairs = 2 })
            .Row(new { size = 3, empty_chairs = 3 })
            .Row(new { size = 4, empty_chairs = 4 })
            .Row(new { size = 5, empty_chairs = 5 })
            .Row(new { size = 6, empty_chairs = 6 });
    }

    public override void Down()
    {
    }
}