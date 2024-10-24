using Dapper;
using Infra.Interfaces;

namespace Infra;

public class RepositoryBase(DbSession session) : IRepositoryBase
{
    private DbSession _session = session;

    public async Task<int> DeleteAsync(string sql, object? parameters) =>
        await _session.Connection.ExecuteAsync(sql: sql, param: parameters, transaction: _session.Transaction);

    public async Task<List<T>> GetAllAsync<T>(string sql, object? parameters = null) where T : class
    {
        var result = await _session.Connection.QueryAsync<T>(sql: sql, param: parameters, transaction: _session.Transaction);

        if (result == null)
            return [];

        return result.ToList();
    }

    public async Task<T?> GetFirstAsync<T>(string sql, object? parameters = null) where T : class
    {
        var result = await _session.Connection.QueryFirstOrDefaultAsync<T>(sql: sql, param: parameters, transaction: _session.Transaction);

        return result;
    }

    public async Task<int> UpdateAsync(string sql, object? parameters) =>
        await _session.Connection.ExecuteAsync(sql: sql, param: parameters, transaction: _session.Transaction);
}
