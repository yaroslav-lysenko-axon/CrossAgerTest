using System.Data;
using FluentMigrator;

namespace CrossAgerTest.Migrations;

[Migration(2)]
public class Migration002_AddClientsGroupTable() : Migration
{
    public override void Up()
    {
        Create.Table("clients_group")
            .WithColumn("id").AsInt32().Identity().PrimaryKey("clients_group_pk")
            .WithColumn("table_id").AsInt32().Nullable()
            .WithColumn("size").AsInt32().NotNullable()
            .WithColumn("state").AsString().NotNullable()
            .WithColumn("arrived_at").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime);

        Create.ForeignKey("fk_clients_group_table")
            .FromTable("clients_group").ForeignColumn("table_id")
            .ToTable("table").PrimaryColumn("id").OnDelete(Rule.SetNull);
    }

    public override void Down()
    {
        Delete.Table("clients_group");
    }
}