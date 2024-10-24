using Infra.Interfaces;

namespace Infra;

public sealed class UnitOfWork(DbSession session) : IUnitOfWork
{
    private readonly DbSession _session = session;

    public void BeginTransaction() =>
        _session.Transaction = _session.Connection.BeginTransaction();

    public void Commit() =>
        _session.Transaction.Commit();

    public void Roolback() =>
        _session.Transaction.Rollback();

    public void Dispose() => _session.Transaction?.Dispose();
}
