using Domain.Interfaces.Uow;
using Havan.Logistica.Core.Notifications;
using Infra.Data.Context;

namespace Infra.Data.Uow
{
    public class CatalogoProdutoUnitOfWork : UnitOfWorkBase<CatalogoProdutoContext>, ICatalogoProdutoUnitOfWork
    {
        public CatalogoProdutoUnitOfWork(INotifier notifier, CatalogoProdutoContext context) : base(notifier, context)
        {
        }
    }
}
