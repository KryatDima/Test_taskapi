using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_task.Data.Context;
using Test_task.Data.Interfaces;
using Test_task.Data.Repositories;

namespace Test_task.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Dictionary<Type, object> repositories;
        private IDbContextTransaction transaction;
        private readonly object createdRepositoryLock;
        private bool transactionClosed;
        private readonly Test_taskDbContext dbContext;
        private bool disposed = false;

        private IProductRepository productRepository;

        public UnitOfWork(Test_taskDbContext dbContext)
        {
            this.dbContext = dbContext;
            repositories = new Dictionary<Type, object>();
            createdRepositoryLock = new object();
            transactionClosed = true;
            transaction = null;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(dbContext);
                return productRepository;
            }
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
        {
            if (!repositories.ContainsKey(typeof(TEntity)))
            {
                lock (createdRepositoryLock)
                {
                    repositories.Add(typeof(TEntity), new Repository<TEntity>(dbContext));
                }
            }

            return repositories[typeof(TEntity)] as IRepository<TEntity>;
        }

        public void BeginTransaction()
        {
            if (transactionClosed || transaction == null)
            {
                transaction = dbContext.Database.BeginTransaction();
                transactionClosed = false;
            }
        }

        public void CommitTransaction()
        {
            if (!transactionClosed)
            {
                transaction?.Commit();
                transactionClosed = true;
            }
        }

        public void RollbackTransaction()
        {
            if (!transactionClosed)
            {
                transaction?.Rollback();
                transactionClosed = true;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
                dbContext.Dispose();
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

