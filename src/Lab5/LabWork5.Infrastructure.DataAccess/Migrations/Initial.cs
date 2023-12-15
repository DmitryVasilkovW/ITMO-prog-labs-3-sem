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
        user_name text not null
    );
    
    create table password
    (
        bill_id bigint not null,
        billpassword text not null
    );

    create table admin
    (
        adminpassword text not null
    );

    create table history
    (
        user_id bigint not null,
        operation text not null
    );

    create table bill
    (
        bill_id bigint primary key generated always as identity,
        user_id bigint not null,
        balance bigint not null
    );

    insert into bill (user_id, balance)
    values (1, 1000);

    insert into password (bill_id, billpassword)
    values (1, 239);

    insert into admin (adminpassword)
    values (239241);

    insert into users (user_name)
    values ('pablo');
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
    drop table users;
    drop table history;
    drop table bill;
    drop table password;
    """;
}
