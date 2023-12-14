using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using LabWork5.Application.Abstractions;
using LabWork5.Application.Contracts.Users;
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

    public User? FindUserByBillid(long billid)
    {
        const string sqlforusrid = """
        select user_id
        from bill
        where bill_id = @billid;
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

        using var command = new NpgsqlCommand(sqlforusrid, connection);
        command.AddParameter("billid", billid);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        long userid = reader.GetInt64(0);

        const string sql = """
                           select user_name
                           from user
                           where user_id = @userid
                           """;
        using var newcommand = new NpgsqlCommand(sql, connection);

        newcommand.AddParameter("userid", userid);

        using NpgsqlDataReader newreader = newcommand.ExecuteReader();
        return new User(
            Id: userid,
            Username: newreader.GetString(0));
    }

    public void BillCreation(long billid)
    {
        const string sqlforusrid = """
        select user_id
        from bill
        where bill_id = @billid;
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

        using var command = new NpgsqlCommand(sqlforusrid, connection);
        command.AddParameter("billid", billid);

        using NpgsqlDataReader reader = command.ExecuteReader();

        long userid = reader.GetInt64(0);
        const long balance = 0;

        const string sql = """
                           INSERT INTO bill (user_id, balance)
                           VALUES (@userid, @balance);
                           """;
        using var newcommand = new NpgsqlCommand(sql, connection);

        newcommand.AddParameter("userid", userid);
        newcommand.AddParameter("balance", balance);
        newcommand.ExecuteNonQuery();
    }

    public long ViewBalance(long billid)
    {
        const string sql = """
        select balance
        from bill
        where bill_id = @billid;
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

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("billid", billid);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.GetInt64(0);
    }

    public TransactionResults Withdrawal(long billid, long withdrawals)
    {
        const string sqlchecker = """
        select balance
        from bill
        where bill_id = @billid;
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

        using var command = new NpgsqlCommand(sqlchecker, connection);
        command.AddParameter("billid", billid);

        using NpgsqlDataReader reader = command.ExecuteReader();

        long checkbalance = reader.GetInt64(0);

        if (checkbalance - withdrawals < 0)
        {
            return TransactionResults.InsufficientFunds;
        }

        const string sql = """
                           UPDATE bill
                           SET balance = balance - @withdrawals
                           WHERE bill_id = @billid;
                           """;

        using var newcommand = new NpgsqlCommand(sql, connection);
        newcommand.AddParameter("billid", billid);
        newcommand.AddParameter("withdrawals", withdrawals);
        newcommand.ExecuteNonQuery();

        return TransactionResults.Success;
    }

    public void AccountFunding(long billid, long depositmoney)
    {
        const string sql = """
                           UPDATE bill
                           SET balance = balance + @depositmoney
                           WHERE bill_id = @billid;
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

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("billid", billid);
        command.AddParameter("depositmoney", depositmoney);
    }

    public IList<string> TransactionHistory(long billid)
    {
        const string sql = """
                           seelect user_id
                           from bill
                           WHERE bill_id = @billid;
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

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("billid", billid);

        using NpgsqlDataReader reader = command.ExecuteReader();
        long userid = reader.GetInt64(0);

        const string sqlforhistory = """
                           seelect operation
                           from history
                           WHERE user_id = userid;
                           """;

        using var newcommand = new NpgsqlCommand(sqlforhistory, connection);
        newcommand.AddParameter("userid", userid);

        using NpgsqlDataReader newreader = newcommand.ExecuteReader();

        var historyList = new List<string>();

        int index = 0;
        while (newreader.ReadAsync() is not null)
        {
            historyList.Add(reader.GetString(index));
            index++;
        }

        return historyList;
    }
}