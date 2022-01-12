using Domain.Interfaces.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;

namespace Infra.Data.Uow
{
    public class UnitOfWorkBase<TContext> : IUnitOfWorkBase where TContext : DbContext
    {
        private readonly ILogger _logger;
        private readonly TContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWorkBase(ILogger logger, TContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void BeginTransaction()
        {
            if (_context == null)
                throw new ArgumentException("Não é possível iniciar uma transação. O contexto está nulo.");

            _transaction = _context.Database.BeginTransaction();
        }

        public bool SaveTransactionChanges()
        {
            if (_context == null)
                throw new ArgumentException("Não é possível salvar a transação. O contexto está nulo.");
            else if (_transaction == null)
                throw new ArgumentException("Não é possível salvar a transação. A transação está nula.");
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return false;
            }
        }

        public bool CommitTransaction()
        {
            if (_transaction == null)
                throw new ArgumentException("Não é possível finalizar a transação.A transação está nula.");
            try
            {
                _transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return false;
            }
        }

        public void RollBackTransaction()
        {
            if (_transaction == null)
                throw new ArgumentException("Não é possível dar rollback na transação.A transação está nula.");
            try
            {
                _transaction.Rollback();
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
            }
        }

        public bool Commit()
        {
            if (_context == null)
                throw new ArgumentException("Não é possível finalizar a transação.A transação está nula.");
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                    _context.Dispose();
                if (_transaction != null)
                    _transaction.Dispose();
            }
        }
    }
}
