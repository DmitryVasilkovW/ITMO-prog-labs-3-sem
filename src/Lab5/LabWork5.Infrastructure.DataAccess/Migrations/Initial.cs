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
        password text not null
    );

    create table atm
    (
        atm_id bigint primary key generated always as identity ,
        atm_name text not null 
    );

    create table history
    (
        user_id bigint not null,
        operation text not null
    );

    create table bill
        l
    (
        bill_id bigint primary key generated always as identity,
        user_id bigint not null,
        balance bigint not null,
        tmp text
    );

    insert into bill (user_id, balance, tmp)
    values (1, 1000, 'bimbim');
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
    drop table users;
    drop table history;
    drop table bill;
    drop table atm;
    """;
}
