namespace Infra.Interfaces;

public interface IUnitOfWork
{
    void BeginTransaction();
    void Commit();
    void Roolback();
}
