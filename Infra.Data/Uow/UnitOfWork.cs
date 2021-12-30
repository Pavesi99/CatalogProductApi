using Domain.Interfaces.Uow;

namespace Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICatalogoProdutoUnitOfWork CatalogoProdutoUnitOfWork { get; private set; }

        public UnitOfWork( ICatalogoProdutoUnitOfWork arquiteturaProdutoUnitOfWork)
        {
            CatalogoProdutoUnitOfWork = arquiteturaProdutoUnitOfWork;
        }
    }
}
