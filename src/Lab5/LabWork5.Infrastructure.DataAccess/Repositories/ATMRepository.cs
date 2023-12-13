using Itmo.Dev.Platform.Postgres.Connection;
using LabWork5.Application.Abstractions;
using LabWork5.Application.Models.ATMs;
using Npgsql;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class ATMRepository : IATMRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public ATMRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<ATM> GetAllATMs()
    {
        const string sql = """
        select atm_id, atm_name
        from atm
        """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider
                    .GetConnectionAsync(default)
                    .ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new ATM(
                reader.GetInt64(0),
                reader.GetString(1));
        }
    }
}