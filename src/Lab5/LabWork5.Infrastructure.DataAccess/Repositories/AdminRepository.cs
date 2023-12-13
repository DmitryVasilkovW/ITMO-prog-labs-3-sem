using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using LabWork5.Application.Abstractions;
using LabWork5.Application.Models.Admins;
using Npgsql;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Admin? FindAdminByUsername(string adminname)
    {
        const string sql = """
        select admin_id, admin_name
        from admins
        where admin_name = :username;
        """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider
                    .GetConnectionAsync(default)
                    .ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("adminname", adminname);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Admin(
            Id: reader.GetInt64(0),
            Adminname: reader.GetString(1));
    }
}