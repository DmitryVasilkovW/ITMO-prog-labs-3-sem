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

    public IList<string> TransactionHistory(long userid)
    {
        const string sqlforhistory = """
                       select operation
                       from history
                       WHERE user_id = @userid;
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

        var historyList = new List<string>();

        using (var newcommand = new NpgsqlCommand(sqlforhistory, connection))
        {
            newcommand.Parameters.AddWithValue("userid", userid);

            using (NpgsqlDataReader newreader = newcommand.ExecuteReader())
            {
                while (newreader.Read())
                {
                    historyList.Add(newreader.GetString(0));
                }
            }
        }

        return historyList;
    }
}