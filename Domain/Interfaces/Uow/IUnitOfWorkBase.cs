using System;

namespace Domain.Interfaces.Uow
{
    public interface IUnitOfWorkBase : IDisposable
    {
        void BeginTransaction();
        bool SaveTransactionChanges();
        bool CommitTransaction();
        void RollBackTransaction();
        bool Commit();
    }
}
