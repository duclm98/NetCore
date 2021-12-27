using NetCore.Data.Context;
using NetCore.Data.Entities;
using System;
using System.Threading.Tasks;

namespace NetCore.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly NetCoreDbContext context;

        public UnitOfWork(NetCoreDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Save()
        {
            return await context.SaveChangesAsync() >= 0;
        }

        private BaseRepository<User> userRepository;
        public BaseRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new BaseRepository<User>(context);
                return userRepository;
            }
        }

        private BaseRepository<Product> productRepository;
        public BaseRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new BaseRepository<Product>(context);
                return productRepository;
            }
        }

        private BaseRepository<Category> categoryRepository;
        public BaseRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new BaseRepository<Category>(context);
                return categoryRepository;
            }
        }

        private BaseRepository<ProductInCategory> productInCategoryRepository;
        public BaseRepository<ProductInCategory> ProductInCategoryRepository
        {
            get
            {
                if (productInCategoryRepository == null)
                    productInCategoryRepository = new BaseRepository<ProductInCategory>(context);
                return productInCategoryRepository;
            }
        }

        // Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}