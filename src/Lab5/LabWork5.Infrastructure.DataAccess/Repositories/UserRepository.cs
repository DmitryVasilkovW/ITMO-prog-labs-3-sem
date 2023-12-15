using Itmo.Dev.Platform.Postgres.Extensions;
using LabWork5.Application.Abstractions;
using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Models.Users;
using Npgsql;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
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

        long userid;
        using (NpgsqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read() is false)
                return null;

            userid = reader.GetInt64(0);
        }

        const string sql = """
                       select user_name
                       from users
                       where user_id = @userid
                       """;
        using var newcommand = new NpgsqlCommand(sql, connection);

        newcommand.AddParameter("userid", userid);

        using NpgsqlDataReader newreader = newcommand.ExecuteReader();
        if (newreader.Read() is false)
            return null;

        return new User(
            Id: userid,
            Username: newreader.GetString(0));
    }

    public void BillCreation(string password, User? user)
    {
        using var connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 6432,
            Username = "postgres",
            Password = "postgres",
            SslMode = SslMode.Prefer,
        }.ConnectionString);
        connection.Open();

        if (user is not null)
        {
            long userid = user.Id;

            const long balance = 0;

            const string sql = """
                       INSERT INTO bill (user_id, balance)
                        VALUES (@userid, @balance)
                        RETURNING bill_id;
                       """;

            long newbillid;
            using (var newcommand = new NpgsqlCommand(sql, connection))
            {
                newcommand.Parameters.AddWithValue("userid", userid);
                newcommand.Parameters.AddWithValue("balance", balance);

                using NpgsqlDataReader newreader = newcommand.ExecuteReader();
                newreader.Read();
                newbillid = newreader.GetInt64(0);
            }

            const string sqlforhistory = """
                        INSERT INTO history (user_id, operation)
                       VALUES (@userid, 'Bill creation');
                       """;

            using (var historycommand = new NpgsqlCommand(sqlforhistory, connection))
            {
                historycommand.Parameters.AddWithValue("userid", userid);
                historycommand.ExecuteNonQuery();
            }

            const string sqlpassword = """
                        INSERT INTO password (bill_id, billpassword)
                       VALUES (@newbillid, @password);
                       """;

            using (var passwordcommand = new NpgsqlCommand(sqlpassword, connection))
            {
                passwordcommand.Parameters.AddWithValue("newbillid", newbillid);
                passwordcommand.Parameters.AddWithValue("password", password);
                passwordcommand.ExecuteNonQuery();
            }
        }
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

        long result;
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("billid", billid);
            using NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            result = reader.GetInt64(0);
        }

        const string sqlforuserid = """
                        select user_id
                        from bill
                        where bill_id = @billid 
                       """;
        long userid;
        using (var useridcommand = new NpgsqlCommand(sqlforuserid, connection))
        {
            useridcommand.Parameters.AddWithValue("billid", billid);
            using (NpgsqlDataReader idreader = useridcommand.ExecuteReader())
            {
                idreader.Read();
                userid = idreader.GetInt64(0);
            }
        }

        const string sqlforhistory = """
                        INSERT INTO history (user_id, operation)
                       VALUES (@userid, 'View balance');
                       """;

        using (var historycommand = new NpgsqlCommand(sqlforhistory, connection))
        {
            historycommand.Parameters.AddWithValue("userid", userid);
            historycommand.ExecuteNonQuery();
        }

        return result;
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

        long checkbalance;
        using (var command = new NpgsqlCommand(sqlchecker, connection))
        {
            command.Parameters.AddWithValue("billid", billid);

            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                checkbalance = reader.GetInt64(0);
            }
        }

        if (checkbalance - withdrawals < 0)
        {
            return TransactionResults.InsufficientFunds;
        }

        const string sql = """
                       UPDATE bill
                       SET balance = balance - @withdrawals
                       WHERE bill_id = @billid;
                       """;

        using (var newcommand = new NpgsqlCommand(sql, connection))
        {
            newcommand.Parameters.AddWithValue("billid", billid);
            newcommand.Parameters.AddWithValue("withdrawals", withdrawals);
            newcommand.ExecuteNonQuery();
        }

        const string sqlforuserid = """
                        select user_id
                        from bill
                        where bill_id = @billid 
                       """;
        long userid;
        using (var useridcommand = new NpgsqlCommand(sqlforuserid, connection))
        {
            useridcommand.Parameters.AddWithValue("billid", billid);
            using (NpgsqlDataReader idreader = useridcommand.ExecuteReader())
            {
                idreader.Read();
                userid = idreader.GetInt64(0);
            }
        }

        const string sqlforhistory = """
                        INSERT INTO history (user_id, operation)
                       VALUES (@userid, 'withdrawal');
                       """;

        using (var historycommand = new NpgsqlCommand(sqlforhistory, connection))
        {
            historycommand.Parameters.AddWithValue("userid", userid);
            historycommand.ExecuteNonQuery();
        }

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

        using (var command = new NpgsqlCommand(sql, connection))
        {
        command.AddParameter("billid", billid);
        command.AddParameter("depositmoney", depositmoney);
        command.ExecuteNonQuery();
        }

        const string sqlforuserid = """
                        select user_id
                        from bill
                        where bill_id = @billid 
                       """;
        long userid;
        using (var useridcommand = new NpgsqlCommand(sqlforuserid, connection))
        {
            useridcommand.Parameters.AddWithValue("billid", billid);
            using (NpgsqlDataReader reader = useridcommand.ExecuteReader())
            {
                reader.Read();
                userid = reader.GetInt64(0);
            }
        }

        const string sqlforhistory = """
                        INSERT INTO history (user_id, operation)
                       VALUES (@userid, 'Account funding');
                       """;

        using (var historycommand = new NpgsqlCommand(sqlforhistory, connection))
        {
            historycommand.Parameters.AddWithValue("userid", userid);
            historycommand.ExecuteNonQuery();
        }
    }

    public IList<string>? TransactionHistory(User? user)
    {
        using var connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 6432,
            Username = "postgres",
            Password = "postgres",
            SslMode = SslMode.Prefer,
        }.ConnectionString);
        connection.Open();

        if (user is not null)
        {
            long userid = user.Id;

            const string sqlforhistory = """
                       select operation
                       from history
                       WHERE user_id = @userid;
                       """;

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

        return null;
    }

    public bool PasswordVerification(long billid, string inputpassword)
    {
        const string sql = """
                       select billpassword
                       from password
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

        string password;
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("billid", billid);

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