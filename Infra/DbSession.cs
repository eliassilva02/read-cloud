using Npgsql;
using System.Data;

namespace Infra;

public sealed class DbSession : IDisposable
{
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }

    public DbSession(string? connection_string)
    {
        if (string.IsNullOrEmpty(connection_string))
            throw new NpgsqlException("Nenhuma string foi passada");

        Connection = new NpgsqlConnection(connection_string);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}
