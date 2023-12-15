using Itmo.Dev.Platform.Postgres.Connection;
using LabWork5.Application.Abstractions;
using Npgsql;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public bool PasswordVerification(string inputpassword)
    {
        const string sql = """
                       select adminpassword
                       from admin
                       """;

        using var connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 6432,
            Username = "postgres",
            Password = "postgres",
            SslMode = SslMode.Prefer,
        }.ConnectionString);
        connection.Open();

        string password;
        using (var command = new NpgsqlCommand(sql, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                password = reader.GetString(0);
            }
        }

        if (inputpassword.Equals(password, StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }
}