using Domain.Interfaces.Uow;
using Infra.Data.Context;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Uow
{
    public class CatalogoProdutoUnitOfWork : UnitOfWorkBase<CatalogoProdutoContext>, ICatalogoProdutoUnitOfWork
    {
        public CatalogoProdutoUnitOfWork(ILogger<CatalogoProdutoContext> logger, CatalogoProdutoContext context) : base(logger, context)
        {
        }
    }
}
