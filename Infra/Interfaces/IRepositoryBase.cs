namespace Infra.Interfaces;

public interface IRepositoryBase
{
    Task<T?> GetFirstAsync<T>(string sql, object? parameters = null) where T : class;
    Task<List<T>> GetAllAsync<T>(string sql, object? parameters = null) where T : class;
    Task<int> UpdateAsync(string sql, object? parameters);
    Task<int> DeleteAsync(string sql, object? parameters);
}
