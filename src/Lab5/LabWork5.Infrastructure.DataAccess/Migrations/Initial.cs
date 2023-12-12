using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace LabWork5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
    create type user_role as enum
    (
        'admin',
        'user',
    );

    create type withdrawal_result_state as enum
    (
        'success',
        'Insufficient funds',
    );

    create table users
    (
        user_id bigint primary key generated always as identity ,
        user_name text not null ,
        user_role user_role not null 
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
    drop table users;
    drop table shops;
    drop table product_categories;
    drop table products;
    drop table shop_products;
    drop table orders; 
    drop table order_products;
    drop table order_results;
    drop table order_result_products;

    drop type user_role;
    drop type order_state;
    drop type order_result_state;
    """;
}
