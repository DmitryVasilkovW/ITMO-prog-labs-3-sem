using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace LabWork5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
    create table users
    (
        user_id bigint primary key generated always as identity,
        user_name text not null,
        user_balance bigint not null,
        user_passwords bigint not null,
    );

    create table history
    (
        user_id bigint not null,
        operation text not null,
    );

    create table admin
    (
        abmin_id bigint primary key generated always as identity,
        user_name text not null,
        admin_passwords bigint not null,
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
    drop table users;
    drop table history;
    drop table admin;
    """;
}
