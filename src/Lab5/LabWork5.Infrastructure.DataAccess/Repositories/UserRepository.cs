using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using LabWork5.Application.Abstractions;
using LabWork5.Application.Models.Users;
using Npgsql;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserByUsername(string username)
    {
        const string sql = """
        select user_id, user_name
        from users
        where user_name = :username;
        """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider
                    .GetConnectionAsync(default)
                    .ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1));
    }
}